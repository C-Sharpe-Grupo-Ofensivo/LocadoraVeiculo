using FluentResults;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Aplicacao.ModuloGrupoAutomovel
{
    public class ServicoGrupoAutomovel
    {

        private IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        private IValidadorGrupoAutomovel validadorGrupoAutomovel;

        public ServicoGrupoAutomovel(IRepositorioGrupoAutomovel repositorioGrupoAutomovel, IValidadorGrupoAutomovel validadorGrupoAutomovel)
        {

            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
            this.validadorGrupoAutomovel = validadorGrupoAutomovel;
        }

        public Result Inserir(GrupoAutomovel grupoAutomovel)
        {
            Log.Debug("Tentando inserir grupo...{@d}", grupoAutomovel);

            List<string> erros = ValidarGrupoAutomovel(grupoAutomovel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioGrupoAutomovel.Inserir(grupoAutomovel);

                Log.Debug("Grupo {GrupoAutomovelId} inserido com sucesso", grupoAutomovel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir grupo.";

                Log.Error(exc, msgErro + "{@d}", grupoAutomovel);

                return Result.Fail(msgErro);
            }
        }

        public Result Editar(GrupoAutomovel grupoAutomovel)
        {
            Log.Debug("Tentando editar grupo...{@d}", grupoAutomovel);

            List<string> erros = ValidarGrupoAutomovel(grupoAutomovel);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioGrupoAutomovel.Editar(grupoAutomovel);

                Log.Debug("Grupo {GrupoAutomovelId} editado com sucesso", grupoAutomovel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar grupo.";

                Log.Error(exc, msgErro + $"{grupoAutomovel.Id}");

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(GrupoAutomovel grupoAutomovel)
        {
            Log.Debug("Tentando excluir grupo...{@d}", grupoAutomovel);

            try
            {
                bool grupoAutomovelExiste = repositorioGrupoAutomovel.Existe(grupoAutomovel);

                if (grupoAutomovelExiste == false)
                {
                    Log.Warning("Grupo {GrupoAutomovelId} não encontrada para excluir", grupoAutomovel.Id);

                    return Result.Fail("Grupo não encontrada");
                }

                repositorioGrupoAutomovel.Excluir(grupoAutomovel);

                Log.Debug("Grupo {GrupoAutomovelId} excluída com sucesso", grupoAutomovel.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBAutomovel_TBGrupoAutomovel"))
                    msgErro = "Esta grupo está relacionada com um automóvel e não pode ser excluído";
                else if (ex.Message.Contains("FK_TBAluguel_TBGrupoAutomovel"))
                    msgErro = "Esta grupo está relacionada com um automóvel e não pode ser excluído";
                else
                    msgErro = "Falha ao tentar excluir grupo";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {GrupoAutomovelId}", grupoAutomovel.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarGrupoAutomovel(GrupoAutomovel grupoAutomovel)
        {
            var resultadoValidacao = validadorGrupoAutomovel.Validate(grupoAutomovel);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(grupoAutomovel))
                erros.Add($"Este nome '{grupoAutomovel.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(GrupoAutomovel grupoAutomovel)
        {
            GrupoAutomovel grupoAutomovelEncontrado = repositorioGrupoAutomovel.SelecionarPorNome(grupoAutomovel.Nome);

            if (grupoAutomovelEncontrado != null &&
                grupoAutomovelEncontrado.Id != grupoAutomovel.Id &&
                grupoAutomovelEncontrado.Nome == grupoAutomovel.Nome)
            {
                return true;
            }

            return false;
        }
    }
}
