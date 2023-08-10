using FluentResults;
using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCondutor;
using Serilog;

namespace LocadoraVeiculo.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private readonly IRepositorioCondutor repositorioCondutor;
        private readonly IValidadorCondutor validadorCondutor;
        private readonly IContextoPersistencia contextoPersistencia;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, IValidadorCondutor validadorCondutor, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.validadorCondutor = validadorCondutor;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(Condutor condutor)
        {
            Log.Debug("Tentando inserir Condutor...{@d}", condutor);

            List<string> erros = ValidarCondutor(condutor);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioCondutor.Inserir(condutor);

                contextoPersistencia.GravarDados();

                Log.Debug("Condutor {CondutorId} inserido com sucesso", condutor.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir Condutor.";

                Log.Error(exc, msgErro + "{@d}", condutor);

                return Result.Fail(msgErro);
            }
        }

        public Result Editar(Condutor condutor)
        {
            Log.Debug("Tentando editar Condutor...{@d}", condutor);

            List<string> erros = ValidarCondutor(condutor);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioCondutor.Editar(condutor);

                contextoPersistencia.GravarDados();

                Log.Debug("Condutor {condutorId} editado com sucesso", condutor.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar Condutor.";

                Log.Error(exc, msgErro + "{@d}", condutor);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Condutor condutor)
        {
            Log.Debug("Tentando excluir Condutor...{@d}", condutor);

            try
            {
                bool condutorExiste = repositorioCondutor.Existe(condutor);

                if (condutorExiste == false)
                {
                    Log.Warning("Condutor {condutorId} não encontrado para excluir", condutor.Id);

                    return Result.Fail("Condutor não encontrado");
                }

                repositorioCondutor.Excluir(condutor);

                contextoPersistencia.GravarDados();

                Log.Debug("Condutor {condutorId} excluído com sucesso", condutor.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBAluguel_TBCondutor"))
                    msgErro = "Condutor está relacionado com um automovel e não pode ser excluído";
                else
                    msgErro = "Falha ao tentar excluir Condutor";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {condutorId}", condutor.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarCondutor(Condutor condutor)
        {
            var resultadoValidacao = validadorCondutor.Validate(condutor);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(condutor))
                erros.Add($"Este nome '{condutor.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Condutor condutor)
        {
            Condutor condutorEncontrado = repositorioCondutor.SelecionarPorNome(condutor.Nome);

            if (condutorEncontrado != null &&
            condutorEncontrado.Id != condutor.Id &&
                condutorEncontrado.Nome == condutor.Nome)
            {
                return true;
            }

            return false;
        }
    }
}
