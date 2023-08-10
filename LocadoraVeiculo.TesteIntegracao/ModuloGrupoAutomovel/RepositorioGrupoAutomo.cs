using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculo.TestesIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteIntegracao.ModuloGrupoAutomovel
{
    [TestClass]
    public class RepositorioGrupoAutomoveisEmOrmTeste : TesteIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_grupoAutomoveis()
        {
            //arrange
            var grupoAutomoveis = Builder<GrupoAutomovel>.CreateNew().Build();

            //action
            repositorioGrupoAutomovel.Inserir(grupoAutomoveis);

            //assert
            repositorioGrupoAutomovel.SelecionarPorId(grupoAutomoveis.Id).Should().Be(grupoAutomoveis);
        }

        [TestMethod]
        public void Deve_editar_grupoAutomoveis()
        {
            //arrange
            var grupoAutomoveisId = Builder<GrupoAutomovel>.CreateNew().Persist().Id;

            var grupoAutomoveis = repositorioGrupoAutomovel.SelecionarPorId(grupoAutomoveisId);
            grupoAutomoveis.Nome = "SUVs";

            //action
            repositorioGrupoAutomovel.Editar(grupoAutomoveis);

            //assert
            repositorioGrupoAutomovel.SelecionarPorId(grupoAutomoveis.Id)
            .Should().Be(grupoAutomoveis);
        }

        [TestMethod]
        public void Deve_excluir_grupoAutomoveis()
        {
            //arrange
            var grupoAutomoveis = Builder<GrupoAutomovel>.CreateNew().Persist();

            //action
            repositorioGrupoAutomovel.Excluir(grupoAutomoveis);

            //assert
            repositorioGrupoAutomovel.SelecionarPorId(grupoAutomoveis.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_grupoAutomoveis()
        {
            //arrange
            var grupo01 = Builder<GrupoAutomovel>.CreateNew().Persist();
            var grupo02 = Builder<GrupoAutomovel>.CreateNew().Persist();

            //action
            var grupoAutomoveis = repositorioGrupoAutomovel.SelecionarTodos();

            //assert
            grupoAutomoveis.Should().ContainInOrder(grupo01, grupo02);
            grupoAutomoveis.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_grupoAutomoveis_com_automoveis()
        {
            //arrange
            var grupoAutomoveis01 = Builder<GrupoAutomovel>.CreateNew().Persist();

            var fordK = Builder<Automovel>.CreateNew().With(x => x.GrupoAutomovel = grupoAutomoveis01).Persist();
            var camaro = Builder<Automovel>.CreateNew().With(x => x.GrupoAutomovel = grupoAutomoveis01).Persist();

            //action
            var listGrupoAutomoveis = repositorioGrupoAutomovel.SelecionarTodos(incluirAutomovel: true);

            //assert
            listGrupoAutomoveis[0].listaDeAutomovel.Should().ContainInOrder(fordK, camaro);
            listGrupoAutomoveis[0].listaDeAutomovel.Count.Should().Be(2);
        }

        [TestMethod]
        public void Deve_selecionar_grupoAutomoveis_com_cobrancas()
        {
            //arrange
            var grupoAutomoveis01 = Builder<GrupoAutomovel>.CreateNew().Persist();

            var cobranca01 = Builder<PlanoCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupoAutomoveis01).Persist();
            var cobranca02 = Builder<PlanoCobranca>.CreateNew().With(x => x.GrupoAutomovel = grupoAutomoveis01).Persist();

            //action
            var listGrupoAutomoveis = repositorioGrupoAutomovel.SelecionarTodos(incluirAutomovel: false, incluirCobrancas: true);

            //assert
            listGrupoAutomoveis[0].listaDeCobrancas.Should().ContainInOrder(cobranca01, cobranca02);
            listGrupoAutomoveis[0].listaDeCobrancas.Count.Should().Be(2);
        }
        
       [TestMethod]
        public void Deve_selecionar_grupoAutomoveis_por_nome()
        {
            //arrange
            var grupo01 = Builder<GrupoAutomovel>.CreateNew().Persist();

            //action
            var grupoAutomoveisEncontrado = repositorioGrupoAutomovel.SelecionarPorNome(grupo01.Nome);

            //assert
            grupoAutomoveisEncontrado.Should().Be(grupo01);
        }

        [TestMethod]
        public void Deve_selecionar_grupoAutomoveis_por_id()
        {
            //arrange
            var grupo01 = Builder<GrupoAutomovel>.CreateNew().Persist();

            //action
            var grupoAutomoveisEncontrado = repositorioGrupoAutomovel.SelecionarPorId(grupo01.Id);

            //assert            
            grupoAutomoveisEncontrado.Should().Be(grupo01);
        }
    }
}
