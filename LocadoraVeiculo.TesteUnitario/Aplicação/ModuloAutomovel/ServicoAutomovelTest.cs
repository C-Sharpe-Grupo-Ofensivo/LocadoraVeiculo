using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraVeiculo.Aplicacao.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
//Id = id;
//Placa = placa;
//Modelo = modelo;
//Marca = marca;
//Cor = cor;
//TipoCombustivel = tipoCombustivel;
//CapacidadeLitros = capacidadeLitros;
//Quilometragem = quilometragem;

namespace LocadoraVeiculo.TesteUnitario.Aplicação.ModuloAutomovel
{
    [TestClass]
    public class ServicoAutomovelTest
    {
        Mock<IRepositorioAutomovel> repositorioAutomovelMoq;
        Mock<IValidadorAutomovel> validadorMoq;

        private ServicoAutomovel servicoAutomovel;

        Automovel automovel;

        public ServicoAutomovelTest()
        {
            repositorioAutomovelMoq = new Mock<IRepositorioAutomovel>();
            validadorMoq = new Mock<IValidadorAutomovel>(); ;
            servicoAutomovel = new ServicoAutomovel(repositorioAutomovelMoq.Object, validadorMoq.Object);
            automovel = new("ETA0181", "1", "1", "1", TipoCombustivelEnum.Gas, 10, 10);
        }

        [TestMethod]
        public void Deve_inserir_automovel_caso_ele_for_valido() //cenário 1
        {
            //arrange
            automovel = new Automovel("ETA0181", "1", "1", "1", TipoCombustivelEnum.Gas, 10, 10);

            //action
            Result resultado = servicoAutomovel.Inserir(automovel);

            //assert 
            resultado.Should().BeSuccess();
            repositorioAutomovelMoq.Verify(x => x.Inserir(automovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_automovel_caso_o_nome_ja_esteja_cadastrado() //cenário 2
        {
            //arrange
            string placa = "ETA0181";
            repositorioAutomovelMoq.Setup(x => x.SelecionarPorPlaca(placa))
                .Returns(() =>
                {
                    return new Automovel(placa, "1", "1", "1", TipoCombustivelEnum.Gas, 10, 10);
                });

            //action
            var resultado = servicoAutomovel.Inserir(automovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Esta placa '{placa}' já está sendo utilizada");
            repositorioAutomovelMoq.Verify(x => x.Inserir(automovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_automovel() //cenário 3
        {
            repositorioAutomovelMoq.Setup(x => x.Inserir(It.IsAny<Automovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoAutomovel.Inserir(automovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir automóvel.");
        }

        [TestMethod]
        public void Deve_editar_automovel_caso_ele_for_valido() //cenário 1
        {
            //arrange           
            automovel = new Automovel("ETA0181", "1", "1", "1", TipoCombustivelEnum.Gas, 10, 10);

            //action
            Result resultado = servicoAutomovel.Editar(automovel);

            //assert 
            resultado.Should().BeSuccess();
            repositorioAutomovelMoq.Verify(x => x.Editar(automovel), Times.Once());
        }

        [TestMethod]
        public void Deve_editar_automovel_com_o_mesmo_nome() //cenário 2
        {
            //arrange

            Guid id = new Guid();
            repositorioAutomovelMoq.Setup(x => x.SelecionarPorPlaca("ETA0181"))
                 .Returns(() =>
                 {
                     return new Automovel("ETA0181", "1", "1", "1", TipoCombustivelEnum.Gas, 10, 10);
                 });

            Automovel outroAutomovel = new Automovel("ETA0181", "1", "1", "1", TipoCombustivelEnum.Gas, 10, 10);

            //action
            var resultado = servicoAutomovel.Editar(outroAutomovel);

            //assert 
            resultado.Should().BeSuccess();

            repositorioAutomovelMoq.Verify(x => x.Editar(outroAutomovel), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_automovel_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            repositorioAutomovelMoq.Setup(x => x.SelecionarPorPlaca("ETA0181"))
                 .Returns(() =>
                 {
                     return new Automovel("ETA0181", "1", "1", "1", TipoCombustivelEnum.Gas, 10, 10);
                 });

            Automovel novoAutomovel = new Automovel("ETA0181", "1", "1", "1", TipoCombustivelEnum.Gas, 10, 10);

            //action
            var resultado = servicoAutomovel.Editar(novoAutomovel);

            //assert 
            resultado.Should().BeFailure();

            repositorioAutomovelMoq.Verify(x => x.Editar(novoAutomovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_automovel() //cenário 4
        {
            repositorioAutomovelMoq.Setup(x => x.Editar(It.IsAny<Automovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoAutomovel.Editar(automovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar automóvel.");
        }
    }
}
