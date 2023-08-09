using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using LocadoraVeiculo.TestesIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteIntegracao.ModuloParceiro
{
    [TestClass]
    public class RepositorioParceiroOrmTest : TesteIntegracaoBase
    {

        [TestMethod]
        public void Deve_inserir_parceiro()
        {
            //arrange
            var parceiro = Builder<Parceiro>.CreateNew().Build();

            //action
            repositorioParceiro.Inserir(parceiro);

            //assert
            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().Be(parceiro);
        }

        [TestMethod]
        public void Deve_editar_parceiro()
        {
            //arrange
            var parceiroId = Builder<Parceiro>.CreateNew().Persist().Id;

            var parceiro = repositorioParceiro.SelecionarPorId(parceiroId);
            parceiro.Nome = "Deko";

            //action
            repositorioParceiro.Editar(parceiro);

            //assert
            repositorioParceiro.SelecionarPorId(parceiro.Id)
                .Should().Be(parceiro);
        }

        [TestMethod]
        public void Deve_excluir_parceiro()
        {
            //arrange
            var parceiro = Builder<Parceiro>.CreateNew().Persist();

            //action
            repositorioParceiro.Excluir(parceiro);

            //assert
            repositorioParceiro.SelecionarPorId(parceiro.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todas_parceiros()
        {
            //arrange
            var matematica = Builder<Parceiro>.CreateNew().With(x => x.Nome = "Matemática").Persist();
            var portugues = Builder<Parceiro>.CreateNew().With(x => x.Nome = "Português").Persist();

            //action
            var parceiros = repositorioParceiro.SelecionarTodos();

            //assert
            parceiros.Should().ContainInOrder(matematica, portugues);
            parceiros.Should().HaveCount(2);
        }



        [TestMethod]
        public void Deve_selecionar_parceiro_por_nome()
        {
            //arrange
            var deko = Builder<Parceiro>.CreateNew().Persist();

            //action
            var parceirosEncontrado = repositorioParceiro.SelecionarPorNome(deko.Nome);

            //assert
            parceirosEncontrado.Should().Be(deko);
        }

        [TestMethod]
        public void Deve_selecionar_parceiro_por_id()
        {
            //arrange
            var deko = Builder<Parceiro>.CreateNew().Persist();

            //action
            var parceirosEncontrado = repositorioParceiro.SelecionarPorId(deko.Id);

            //assert            
            parceirosEncontrado.Should().Be(deko);
        }

    }
}
