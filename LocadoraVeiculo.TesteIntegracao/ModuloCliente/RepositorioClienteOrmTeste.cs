using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.TestesIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteIntegracao.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteOrmTeste : TesteIntegracaoBase
    {

        [TestMethod]
        public void Deve_inserir_cliente()
        {
            //arrange
            var cliente = Builder<Cliente>.CreateNew().Build();

            //action
            repositorioCliente.Inserir(cliente);

            //assert
            repositorioCliente.SelecionarPorId(cliente.Id).Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_editar_cliente()
        {
            //arrange
            var clienteId = Builder<Cliente>.CreateNew().Persist().Id;

            var cliente = repositorioCliente.SelecionarPorId(clienteId);
            cliente.Nome = "Cliente";

            //action
            repositorioCliente.Editar(cliente);

            //assert
            repositorioCliente.SelecionarPorId(cliente.Id)
                .Should().Be(cliente);
        }

        [TestMethod]
        public void Deve_excluir_cliente()
        {
            //arrange
            var cliente = Builder<Cliente>.CreateNew().Persist();

            //action
            repositorioCliente.Excluir(cliente);

            //assert
            repositorioCliente.SelecionarPorId(cliente.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_clientes()
        {
            //arrange
            var cliente1 = Builder<Cliente>.CreateNew().With(x => x.Nome = "Cliente 1").Persist();
            var cliente2 = Builder<Cliente>.CreateNew().With(x => x.Nome = "Cliente 2").Persist();

            //action
            var clientes = repositorioCliente.SelecionarTodos();

            //assert
            clientes.Should().ContainInOrder(clientes);
            clientes.Should().HaveCount(2);
        }



        [TestMethod]
        public void Deve_selecionar_cliente_por_nome()
        {
            //arrange
            var clienteTest = Builder<Cliente>.CreateNew().Persist();

            //action
            var clientesEncontrado = repositorioCliente.SelecionarPorNome(clienteTest.Nome);

            //assert
            clientesEncontrado.Should().Be(clienteTest);
        }

        [TestMethod]
        public void Deve_selecionar_cliente_por_id()
        {
            //arrange
            var ClienteTest2 = Builder<Cliente>.CreateNew().Persist();

            //action
            var clientesEncontrado = repositorioCliente.SelecionarPorId(ClienteTest2.Id);

            //assert            
            clientesEncontrado.Should().Be(ClienteTest2);
        }
    }
}
