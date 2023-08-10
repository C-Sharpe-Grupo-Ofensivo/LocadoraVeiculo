using FluentResults;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Aplicacao.ModuloConfiguracaoPreco
{
    public class ServicoConfiguracaoPreco
    {
        private IRepositorioConfiguracaoPreco repositorioConfiguracaoPreco;
        private IValidadorConfiguracaoPreco validadorConfiguracaoPreco;

        public ServicoConfiguracaoPreco(IRepositorioConfiguracaoPreco repositorioConfiguracaoPreco, IValidadorConfiguracaoPreco validadorConfiguracaoPreco)
        {
            this.repositorioConfiguracaoPreco = repositorioConfiguracaoPreco;
            this.validadorConfiguracaoPreco = validadorConfiguracaoPreco;
        }

        public Result Inserir(ConfiguracaoPreco configuracaoPreco)
        {
            Log.Debug("Tentando inserir preço...{@d}", configuracaoPreco);

            List<string> erros = ValidarConfiguracaoPreco(configuracaoPreco);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioConfiguracaoPreco.Inserir(configuracaoPreco);

                Log.Debug("Preco {PrecoId} inserida com sucesso", configuracaoPreco.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir preco.";

                Log.Error(exc, msgErro + "{@d}", configuracaoPreco);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(ConfiguracaoPreco configuracaoPreco)
        {
            Log.Debug("Tentando editar preco...{@d}", configuracaoPreco);

            List<string> erros = ValidarConfiguracaoPreco(configuracaoPreco);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioConfiguracaoPreco.Editar(configuracaoPreco);

                Log.Debug("Preco {PrecoId} editada com sucesso", configuracaoPreco.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar preco.";

                Log.Error(exc, msgErro + "{@d}", configuracaoPreco);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(ConfiguracaoPreco configuracaoPreco)
        {
            Log.Debug("Tentando excluir preco...{@d}", configuracaoPreco);

            try
            {
                bool configuraPrecoExiste = repositorioConfiguracaoPreco.Existe(configuracaoPreco);

                if (configuraPrecoExiste == false)
                {
                    Log.Warning("Preco {PrecoId} não encontrada para excluir", configuracaoPreco.Id);

                    return Result.Fail("Preco não encontrada");
                }

                repositorioConfiguracaoPreco.Excluir(configuracaoPreco);

                Log.Debug("Preco {PrecoId} excluido com sucesso", configuracaoPreco.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;


                msgErro = "Falha ao tentar excluir preco";



                Log.Error(ex, msgErro + " {PrecoId}", configuracaoPreco.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarConfiguracaoPreco(ConfiguracaoPreco configuracaoPreco)
        {
            var resultadoValidacao = validadorConfiguracaoPreco.Validate(configuracaoPreco);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

           

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

      
    }
}