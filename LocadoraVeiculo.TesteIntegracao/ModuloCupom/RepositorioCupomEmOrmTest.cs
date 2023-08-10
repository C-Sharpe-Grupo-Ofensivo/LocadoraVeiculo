using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraVeiculo.Dominio.ModuloCupom;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using LocadoraVeiculo.TestesIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteIntegracao.ModuloCupom
{
    [TestClass]
    public class RepositorioCupomEmOrmTest : TesteIntegracaoBase
    {
        [TestMethod]
        public void Deve_Inserir_cupom()
        {
            //Arrange
            var cupom = Builder<Cupom>.CreateNew().Build();
            cupom.Parceiro = Builder<Parceiro>.CreateNew().Build();

            //Action
            repositorioCupom.Inserir(cupom);

            //Assert
            repositorioCupom.SelecionarPorId(cupom.Id).Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_Editar_cupom()
        {
            var parceiroId = Builder<Parceiro>.CreateNew().Persist();

            var cupom = Builder<Cupom>.CreateNew()
            .With(c => c.Parceiro = parceiroId)
                .Persist();

            cupom.Nome = "CUPOM10";
            repositorioCupom.Editar(cupom);

            var cupomEditado = repositorioCupom.SelecionarPorId(cupom.Id);
            cupomEditado.Should().BeEquivalentTo(cupom);
        }

        

        [TestMethod]
        public void Deve_selecionar_todos_cupons()
        {
            var parceiroId = Builder<Parceiro>.CreateNew().Persist();

            var cupom1 = Builder<Cupom>.CreateNew()
                .With(c => c.Parceiro = parceiroId)
            .Persist();

            var cupom2 = Builder<Cupom>.CreateNew()
                .With(c => c.Parceiro = parceiroId)
                .Persist();

            var cupons = repositorioCupom.SelecionarTodos();

            cupons.Should().ContainInOrder(cupom1, cupom2);
            cupons.Should().HaveCount(2);
        }

        

        [TestMethod]
        public void Deve_selecionar_cupom_por_id()
        {
            var parceiroId = Builder<Parceiro>.CreateNew().Persist();
            var cupom = Builder<Cupom>.CreateNew()
                .With(c => c.Parceiro = parceiroId)
                .Persist();

            var cupomEncontrado = repositorioCupom.SelecionarPorId(cupom.Id);

            cupomEncontrado.Should().Be(cupom);
        }
        [TestMethod]
        public void Deve_selecionar_cupom_por_nome()
        {
            var parceiroId = Builder<Parceiro>.CreateNew().Persist();
            var cupom = Builder<Cupom>.CreateNew()
                .With(c => c.Parceiro = parceiroId)
                .Persist();

            var cupomEncontrado = repositorioCupom.SelecionarPorNome(cupom.Nome);

            cupomEncontrado.Should().Be(cupom);
        }
        [TestMethod]
        public void Deve_excluir_cupom()
        {
            var parceiroId = Builder<Parceiro>.CreateNew().Persist();

            var cupom = Builder<Cupom>.CreateNew()
                .With(c => c.Parceiro = parceiroId)
                .Persist();

            repositorioCupom.Excluir(cupom);

            repositorioCupom.SelecionarPorId(cupom.Id).Should().BeNull();
        }
    }
}
