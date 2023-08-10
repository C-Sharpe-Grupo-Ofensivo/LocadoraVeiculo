using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using LocadoraVeiculo.TestesIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteIntegracao.ModuloTaxaServico
{
    [TestClass]
    public class RepositorioTaxasServicosEmOrmTest : TesteIntegracaoBase
    {
        [TestMethod]
        public void Deve_Inserir_Taxas_ou_Servicos()
        {
            //arrange
            var taxa = Builder<TaxaServico>.CreateNew().Build();

            //action
            repositorioTaxaServico.Inserir(taxa);

            //Assert
            repositorioTaxaServico.SelecionarPorId(taxa.Id).Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_Editar_Taxas_ou_Servicos()
        {
            var taxaId = Builder<TaxaServico>.CreateNew().Persist().Id;

            var taxa = repositorioTaxaServico.SelecionarPorId(taxaId);
            taxa.Nome = "Taxa";

            repositorioTaxaServico.Editar(taxa);

            repositorioTaxaServico.SelecionarPorId(taxa.Id)
            .Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_excluir_Taxas_ou_Servicos()
        {
            var taxa = Builder<TaxaServico>.CreateNew().Persist();
            repositorioTaxaServico.Excluir(taxa);

            repositorioTaxaServico.SelecionarPorId(taxa.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_Taxas_ou_Servicos()
        {
            var taxa1 = Builder<TaxaServico>.CreateNew().Persist();
            var taxa2 = Builder<TaxaServico>.CreateNew().Persist();

            var taxas = repositorioTaxaServico.SelecionarTodos();

            taxas.Should().ContainInOrder(taxa1, taxa2);
            taxas.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_Taxas_ou_Servicos_por_nome()
        {
            var taxa = Builder<TaxaServico>.CreateNew().Persist();

            var taxaEncontrada = repositorioTaxaServico.SelecionarPorNome(taxa.Nome);

            taxaEncontrada.Should().Be(taxa);
        }

        [TestMethod]
        public void Deve_selecionar_Taxas_ou_Servicos_por_id()
        {
            var taxa = Builder<TaxaServico>.CreateNew().Persist();

            var taxaEncontrada = repositorioTaxaServico.SelecionarPorId(taxa.Id);

            taxaEncontrada.Should().Be(taxa);
        }
    }
}
