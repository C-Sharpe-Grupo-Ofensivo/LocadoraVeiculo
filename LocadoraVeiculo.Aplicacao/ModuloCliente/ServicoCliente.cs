using FluentResults;
using LocadoraVeiculo.Dominio.ModuloCliente;
using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;
        private IValidadorCliente validadorCliente;

        public ServicoCliente(
            IRepositorioCliente repositorioCliente,
            IValidadorCliente validadorCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.validadorCliente = validadorCliente;
        }

        public Result Inserir(Cliente cliente)
        {
            Log.Debug("Tentando inserir cliente...{@d}", cliente);

            List<string> erros = ValidarCliente(cliente);

            if (erros.Count() > 0)
                return Result.Fail(erros); //cenário 2

            try
            {
                repositorioCliente.Inserir(cliente);

                Log.Debug("Cliente {ClienteId} inserida com sucesso", cliente.Id);

                return Result.Ok(); //cenário 1
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar inserir cliente.";

                Log.Error(exc, msgErro + "{@d}", cliente);

                return Result.Fail(msgErro); //cenário 3
            }
        }

        public Result Editar(Cliente cliente)
        {
            Log.Debug("Tentando editar cliente...{@d}", cliente);

            List<string> erros = ValidarCliente(cliente);

            if (erros.Count() > 0)
                return Result.Fail(erros);

            try
            {
                repositorioCliente.Editar(cliente);

                Log.Debug("Cliente {ClienteId} editada com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                string msgErro = "Falha ao tentar editar cliente.";

                Log.Error(exc, msgErro + "{@d}", cliente);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Cliente cliente)
        {
            Log.Debug("Tentando excluir cliente...{@d}", cliente);

            try
            {
                bool disciplinaExiste = repositorioCliente.Existe(cliente);

                if (disciplinaExiste == false)
                {
                    Log.Warning("Cliente {ClienteId} não encontrada para excluir", cliente.Id);

                    return Result.Fail("Cliente não encontrada");
                }

                repositorioCliente.Excluir(cliente);

                Log.Debug("Cliente {ClienteId} excluido com sucesso", cliente.Id);

                return Result.Ok();
            }
            catch (SqlException ex)
            {
                List<string> erros = new List<string>();

                string msgErro;

             
                msgErro = "Falha ao tentar excluir cliente";

              

                Log.Error(ex, msgErro + " {ClienteId}", cliente.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarCliente(Cliente cliente)
        {
            var resultadoValidacao = validadorCliente.Validate(cliente);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(cliente))
                erros.Add($"Este nome '{cliente.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Cliente cliente)
        {
            Cliente clienteEncontrada = repositorioCliente.SelecionarPorNome(cliente.Nome);

            if (clienteEncontrada != null &&
                clienteEncontrada.Id != cliente.Id &&
                clienteEncontrada.Nome == cliente.Nome)
            {
                return true;
            }

            return false;
        }
        //***************FAZER CPF DUPLICADO*******************

        //private bool CpfDuplicado(Cliente cliente) ########################CPF
        //{
        //    Cliente clienteEncontrada = repositorioCliente.SelecionarPorNome(cliente.Nome);

        //    if (clienteEncontrada != null &&
        //        clienteEncontrada.Id != cliente.Id &&
        //        clienteEncontrada.Nome == cliente.Nome)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
