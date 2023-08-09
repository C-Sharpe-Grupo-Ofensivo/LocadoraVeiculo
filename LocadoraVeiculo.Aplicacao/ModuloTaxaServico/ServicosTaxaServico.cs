using FluentResults;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Aplicacao.ModuloTaxaServico
{
    public class ServicosTaxaServico
    {
        IRepositorioTaxaServico repositorioTaxaServico;
        IValidadorTaxaServico validadorTaxaServico;

        public ServicosTaxaServico(IRepositorioTaxaServico repositorioTaxaServico, IValidadorTaxaServico validadorTaxaServico)
        {
            this.repositorioTaxaServico = repositorioTaxaServico;
            this.validadorTaxaServico = validadorTaxaServico;
        }

        public Result Inserir(TaxaServico taxaServico)
        {
            Log.Debug($"Tentando inserir taxa...{taxaServico}"); //não seria taxaServico.Nome?

            List<string> erros = ValidarTaxaServico(taxaServico);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioTaxaServico.Inserir(taxaServico);

                Log.Debug($"Taxa {taxaServico.Id} inserida com sucesso");

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string mensagemErro = "Falha ao tentar inserir taxa.";

                Log.Error(exc, mensagemErro + $"{taxaServico}");

                return Result.Fail(mensagemErro); //continuação cenário 2
            }
        }

        public Result Editar(TaxaServico taxaServico)
        {
            Log.Debug($"Tentando editar taxa...{taxaServico}");

            List<string> erros = ValidarTaxaServico(taxaServico);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioTaxaServico.Editar(taxaServico);

                Log.Debug($"Taxa {taxaServico.Id} editada com sucesso");

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string mensagemErro;

                //Conferir depois quais bancos utilizam taxa ??
                if (ex.Message.Contains("FK_TBAluguel_TBTaxaServico"))
                    mensagemErro = "Esta taxa está relacionada com um aluguel em aberto e não pode ser editada";
                else
                    mensagemErro = "Falha ao tentar editar taxa";

                Log.Error(ex, mensagemErro + $"{taxaServico.Id}");

                return Result.Fail(mensagemErro);
            }
        }

        public Result Excluir(TaxaServico taxaServico)
        {
            Log.Debug($"Tentando excluir taxa...{taxaServico}");

            try
            {
                bool taxaServicoExiste = repositorioTaxaServico.Existe(taxaServico);

                if (taxaServicoExiste == false)
                {
                    Log.Warning($"Taxa {taxaServico.Id} não encontrada para excluir");

                    return Result.Fail("Taxa não encontrada");
                }

                repositorioTaxaServico.Excluir(taxaServico);

                Log.Debug($"Taxa {taxaServico.Id} excluída com sucesso");

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

                //Conferir depois quais bancos utilizam taxa
                if (ex.Message.Contains("FK_TBAluguel_TBTaxaServico"))
                    msgErro = "Esta taxa está relacionada com um aluguel em aberto e não pode ser excluída";
                else
                    msgErro = "Falha ao tentar excluir taxa";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + $" {taxaServico.Id}");

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarTaxaServico(TaxaServico taxaServico)
        {
            var resultadoValidacao = validadorTaxaServico.Validate(taxaServico);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(taxaServico))
                erros.Add($"Este nome '{taxaServico.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(TaxaServico taxaServico)
        {
            TaxaServico taxaServicoEncontrada = repositorioTaxaServico.SelecionarPorNome(taxaServico.Nome);

            if (taxaServicoEncontrada != null &&
                taxaServicoEncontrada.Id != taxaServico.Id &&
                taxaServicoEncontrada.Nome == taxaServico.Nome)
            {
                return true;
            }

            return false;
        }
    }
}