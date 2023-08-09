using FluentResults;
using LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Aplicacao.ModuloConfiguracaoPreco
{
    internal class ServicoConfiguracaoPreco
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
            Log.Debug($"Tentando configurar preço...{configuracaoPreco}");

            List<string> erros = ValidarConfiguracaoPreco(configuracaoPreco);

            repositorioConfiguracaoPreco.ObterConfiguracaoPreco();

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioConfiguracaoPreco.GravarConfiguracaoPrecoEmArquivoJson(configuracaoPreco);

                Log.Debug("Preços configurados com sucesso");

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar configurar os preços.";

                Log.Error(exc, msgErro + $"{configuracaoPreco}");

                return Result.Fail(msgErro); //cenário 3
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