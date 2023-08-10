using FluentResults;
using LocadoraVeiculo.Dominio.Compartilhado;
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
    public class ServicoTaxasServicos
    {
        private IRepositorioTaxaServico repositorioTaxasServicos;
        private IValidadorTaxaServico validadorTaxasServicos;
       

        public ServicoTaxasServicos(IRepositorioTaxaServico repositorioTaxasServicos, IValidadorTaxaServico validadorTaxasServicos)
        {
            this.repositorioTaxasServicos = repositorioTaxasServicos;
            this.validadorTaxasServicos = validadorTaxasServicos;
        }

        public Result Inserir(TaxaServico taxasServicos)
        {
            Log.Debug("Tentando inserir serviço...{@d}", taxasServicos);

            List<string> erros = ValidarTaxasServicos(taxasServicos);

            if (erros.Count() > 0)
            {
               

                return Result.Fail(erros);
            }

            try
            {
                repositorioTaxasServicos.Inserir(taxasServicos);

               

                Log.Debug("Serviço {TaxasServicosId} inserida com sucesso", taxasServicos.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
               

                string msgErro = "Falha ao tentar inserir serviço.";

                Log.Error(exc, msgErro + "{@d}", taxasServicos);

                return Result.Fail(msgErro);
            }
        }

        public Result Editar(TaxaServico taxasServicos)
        {
            Log.Debug("Tentando editar serviço...{@d}", taxasServicos);

            List<string> erros = ValidarTaxasServicos(taxasServicos);

            if (erros.Count() > 0)
            {
                

                return Result.Fail(erros);
            }

            try
            {
                repositorioTaxasServicos.Editar(taxasServicos);

               

                Log.Debug("Serviço {TaxasServicosId} editado com sucesso", taxasServicos.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
              

                string msgErro = "Falha ao tentar editar serviço.";

                Log.Error(exc, msgErro + "{@d}", taxasServicos);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(TaxaServico taxasServicos)
        {
            Log.Debug("Tentando excluir serviço...{@d}", taxasServicos);

            try
            {
                bool taxasServicosExiste = repositorioTaxasServicos.Existe(taxasServicos);

                if (taxasServicosExiste == false)
                {
                    Log.Warning("Serviço {TaxasServicosId} não encontrado para excluir", taxasServicos.Id);

                    return Result.Fail("Serviço não encontrada");
                }

                repositorioTaxasServicos.Excluir(taxasServicos);

               

                Log.Debug("Serviço {TaxasServicosId} excluído com sucesso", taxasServicos.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
               

                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBAluguel_TBTaxasServicos"))
                    msgErro = "Este serviço está relacionado com um aluguel e não pode ser excluído !";
                else
                    msgErro = "Falha ao tentar excluir serviço";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {TaxasServicosId}", taxasServicos.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarTaxasServicos(TaxaServico taxasServicos)
        {
            var resultadoValidacao = validadorTaxasServicos.Validate(taxasServicos);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(taxasServicos))
                erros.Add($"Este nome '{taxasServicos.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(TaxaServico taxasServicos)
        {
            TaxaServico taxasServicosEncontrado = repositorioTaxasServicos.SelecionarPorNome(taxasServicos.Nome);

            if (taxasServicosEncontrado != null &&
                taxasServicosEncontrado.Id != taxasServicos.Id &&
                taxasServicosEncontrado.Nome == taxasServicos.Nome)
            {
                return true;
            }

            return false;
        }
    }
}