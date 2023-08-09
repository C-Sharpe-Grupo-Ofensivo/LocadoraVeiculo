using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.TestesIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteIntegracao.ModuloAutomovel
{


    [TestClass]
    public class RepositorioAutomovelOrmTest : TesteIntegracaoBase
    {
        [TestMethod]
        public void Deve_inserir_automovel()
        {
            //arrange
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var automovel = Builder<Automovel>.CreateNew().With(x => x.GrupoAutomovel = grupoAutomovel).Build();

            //action
            repositorioAutomovel.Inserir(automovel);

            //assert
            repositorioAutomovel.SelecionarPorId(automovel.Id).Should().Be(automovel);
        }
        [TestMethod]
        public void Deve_editar_automovel()
        {
            //arrange
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var automovel = Builder<Automovel>.CreateNew().With(x => x.GrupoAutomovel = grupoAutomovel).Persist();

            automovel.Placa = "ETA0181";

            //action
            repositorioAutomovel.Editar(automovel);

            //assert
            repositorioAutomovel.SelecionarPorId(automovel.Id).Should().Be(automovel);
        }

        [TestMethod]
        public void Deve_excluir_automovel()
        {
            //arrange
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var automovel = Builder<Automovel>.CreateNew().With(x => x.GrupoAutomovel = grupoAutomovel).Persist();

            //action
            repositorioAutomovel.Excluir(automovel);

            //assert
            repositorioAutomovel.SelecionarPorId(automovel.Id).Should().BeNull();
        }

        [TestMethod]
        public void Deve_selecionar_todos_automoveis()
        {
            //arrange
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var placa = Builder<Automovel>.CreateNew().With(x => x.Placa = "ETA0181").With(x => x.GrupoAutomovel = grupoAutomovel).Persist();
            var carro = Builder<Automovel>.CreateNew().With(x => x.Placa = "Hyundai").With(x => x.GrupoAutomovel = grupoAutomovel).Persist();

            //action
            var automovel = repositorioAutomovel.SelecionarTodos();

            //assert
            automovel.Should().ContainInOrder(placa, carro);
            automovel.Should().HaveCount(2);
        }

        [TestMethod]
        public void Deve_selecionar_automovel_por_placa()
        {
            //arrange
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var automovel = Builder<Automovel>.CreateNew().With(x => x.GrupoAutomovel = grupoAutomovel).Persist();

            //action
            var automovelsEncontrados = repositorioAutomovel.SelecionarPorPlaca(automovel.Placa);

            //assert
            automovelsEncontrados.Should().Be(automovel);
        }

        [TestMethod]
        public void Deve_selecionar_automovel_por_id()
        {
            //arrange
            var grupoAutomovel = Builder<GrupoAutomovel>.CreateNew().Persist();
            var automovel = Builder<Automovel>.CreateNew().With(x => x.GrupoAutomovel = grupoAutomovel).Persist();

            //action
            var automovelsEncontrada = repositorioAutomovel.SelecionarPorId(automovel.Id);

            //assert            
            automovelsEncontrada.Should().Be(automovel);
        }
    }
}

