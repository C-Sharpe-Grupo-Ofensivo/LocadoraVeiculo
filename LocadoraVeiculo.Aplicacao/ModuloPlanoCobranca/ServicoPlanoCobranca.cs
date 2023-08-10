using FluentResults;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Aplicacao.ModuloPlanoCobranca
{
    public class ServicoPlanoCobranca
    {
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private IValidadorPlanoCobranca validadorPlanoCobranca;

        public ServicoPlanoCobranca(
            IRepositorioPlanoCobranca repositorioPlanoCobranca,
            IValidadorPlanoCobranca validadorPlanoCobranca)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.validadorPlanoCobranca = validadorPlanoCobranca;
        }

        public Result Inserir(PlanoCobranca planoCobranca)
        {
            Log.Debug("Tentando inserir planoCobranca...{@d}", planoCobranca);

            List<string> erros = ValidarPlanoCobranca(planoCobranca);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioPlanoCobranca.Inserir(planoCobranca);

                Log.Debug("PlanoCobranca {PlanoCobrancaId} inserida com sucesso", planoCobranca.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir plano de cobranca.";

                Log.Error(exc, msgErro + "{@d}", planoCobranca);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(PlanoCobranca planoCobranca)
        {
            Log.Debug("Tentando editar planoCobranca...{@d}", planoCobranca);

            List<string> erros = ValidarPlanoCobranca(planoCobranca);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioPlanoCobranca.Editar(planoCobranca);

                Log.Debug("PlanoCobranca {PlanoCobrancaId} inserida com sucesso", planoCobranca.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar plano cobranca.";

                Log.Error(exc, msgErro + "{@d}", planoCobranca);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoCobranca planoCobranca)
        {
            Log.Debug("Tentando excluir plano cobranca...{@d}", planoCobranca);

            try
            {
                bool disciplinaExiste = repositorioPlanoCobranca.Existe(planoCobranca);

                if (disciplinaExiste == false)
                {
                    Log.Warning("Plano Cobranca {PlanoCobrancaId} não encontrado para excluir", planoCobranca.Id);

                    return Result.Fail("Plano Cobranca não encontrada");
                }

                repositorioPlanoCobranca.Excluir(planoCobranca);

                Log.Debug("PlanoCobranca {PlanoCobrancaId} excluido com sucesso", planoCobranca.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;


                msgErro = "Falha ao tentar excluir planoCobranca";



                Log.Error(ex, msgErro + " {PlanoCobrancaId}", planoCobranca.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarPlanoCobranca(PlanoCobranca planoCobranca)
        {
            var resultadoValidacao = validadorPlanoCobranca.Validate(planoCobranca);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            

            return erros;
        }

       
    }
}
