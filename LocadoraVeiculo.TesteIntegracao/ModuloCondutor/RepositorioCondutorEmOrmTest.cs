using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloCondutor;
using LocadoraVeiculo.TestesIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteIntegracao.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmOrmTest : TesteIntegracaoBase
    {
        [TestMethod]
        public void Deve_Inserir_condutor()
        {
            //Arrange
            var condutor = Builder<Condutor>.CreateNew().Build();
            condutor.Cliente = Builder<Cliente>.CreateNew().Build();

            //Action
            repositorioCondutor.Inserir(condutor);

            //Assert
            repositorioCondutor.SelecionarPorId(condutor.Id).Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_Editar_condutor()
        {
            var cliente = Builder<Cliente>.CreateNew().Persist();

            var condutor = Builder<Condutor>.CreateNew()
            .With(c => c.Cliente = cliente)
            .Persist();

            condutor.Nome = "Cleiton";
            repositorioCondutor.Editar(condutor);

            var cupomEditado = repositorioCondutor.SelecionarPorId(condutor.Id);
            cupomEditado.Should().BeEquivalentTo(condutor);
        }

        [TestMethod]
        public void Deve_excluir_condutor()
        {
            var cliente = Builder<Cliente>.CreateNew().Persist();

            var condutor = Builder<Condutor>.CreateNew()
            .With(c => c.Cliente = cliente)
            .Persist();

            repositorioCondutor.Excluir(condutor);

            repositorioCondutor.SelecionarPorId(condutor.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_condutores()
        {
            var cliente = Builder<Cliente>.CreateNew().Persist();

            var condutor1 = Builder<Condutor>.CreateNew()
                .With(c => c.Cliente = cliente)
            .Persist();

            var condutor2 = Builder<Condutor>.CreateNew()
                .With(c => c.Cliente = cliente)
                .Persist();

            var condutores = repositorioCondutor.SelecionarTodos();

            condutores.Should().ContainInOrder(condutor1, condutor2);
            condutores.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_condutor_por_nome()
        {
            var cliente = Builder<Cliente>.CreateNew().Persist();

            var condutor = Builder<Condutor>.CreateNew()
            .With(c => c.Cliente = cliente)
            .Persist();

            var condutorEncontrado = repositorioCondutor.SelecionarPorNome(condutor.Nome);

            condutorEncontrado.Should().Be(condutor);
        }

        [TestMethod]
        public void Deve_selecionar_cupom_por_id()
        {
            var cliente = Builder<Cliente>.CreateNew().Persist();

            var condutor = Builder<Condutor>.CreateNew()
            .With(c => c.Cliente = cliente)
            .Persist();

            var condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().Be(condutor);
        }
    }
}
