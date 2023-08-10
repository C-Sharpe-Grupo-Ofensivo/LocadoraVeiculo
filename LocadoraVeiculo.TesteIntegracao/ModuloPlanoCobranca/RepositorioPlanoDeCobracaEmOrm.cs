using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculo.TestesIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteIntegracao.ModuloPlanoCobranca
{
    [TestClass]
    public class RepositorioPlanoDeCobrancaEmOrmTest : TesteIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_PlanoDeCobranca()
        {
            //arrange
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Build();

            planoCobranca.GrupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Build();

            //action
            repositorioPlanoCobranca.Inserir(planoCobranca);

            //assert
            repositorioPlanoCobranca.SelecionarPorId(planoCobranca.Id).Should().Be(planoCobranca);
        }
        [TestMethod]
        public void Deve_editar_cobranca()
        {
            //arrange
            var grupoAutomoveis = Builder<GrupoAutomovel>.CreateNew().Persist();

            var cobrancaId = Builder<PlanoCobranca>.CreateNew()
                .With(c => c.GrupoAutomovel = grupoAutomoveis)
                .Persist();

            cobrancaId.KmDisponivel = 50;

            //action
            repositorioPlanoCobranca.Editar(cobrancaId);

            //assert
            repositorioPlanoCobranca.SelecionarPorId(cobrancaId.Id)
                .Should().Be(cobrancaId);
        }
        [TestMethod]
        public void Deve_excluir_cobranca()
        {
            //arrange
            var grupoAutomoveis = Builder<GrupoAutomovel>.CreateNew().Persist();

            var cobranca = Builder<PlanoCobranca>.CreateNew()
                .With(c => c.GrupoAutomovel = grupoAutomoveis)
                .Persist();

            //action
            repositorioPlanoCobranca.Excluir(cobranca);

            //assert
            repositorioPlanoCobranca.SelecionarPorId(cobranca.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todas_cobrancas()
        {
            //arrange
            var grupoAutomoveis = Builder<GrupoAutomovel>.CreateNew().Persist();

            var cobranca01 = Builder<PlanoCobranca>.CreateNew()
                .With(c => c.GrupoAutomovel = grupoAutomoveis)
                .Persist();

            var cobranca02 = Builder<PlanoCobranca>.CreateNew()
                .With(c => c.GrupoAutomovel = grupoAutomoveis)
                .Persist();

            //action
            var cobrancas = repositorioPlanoCobranca.SelecionarTodos();

            //assert
            cobrancas.Should().ContainInOrder(cobranca01, cobranca02);
            cobrancas.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_cobranca_por_id()
        {
            var grupoAutomoveis = Builder<GrupoAutomovel>.CreateNew().Persist();

            var cobranca = Builder<PlanoCobranca>.CreateNew()
                .With(c => c.GrupoAutomovel = grupoAutomoveis)
                .Persist();

            var cobrancaEncontrada = repositorioPlanoCobranca.SelecionarPorId(cobranca.Id);

            cobrancaEncontrada.Should().Be(cobranca);
        }
    }
}
