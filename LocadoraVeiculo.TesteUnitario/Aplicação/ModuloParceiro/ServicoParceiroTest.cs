using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraVeiculo.Aplicacao.ModuloParceiro;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Aplicação.ModuloParceiro
{
    [TestClass]
    public class ServicoParceiroTest
    {

        Mock<IRepositorioParceiro> repositorioParceiroMoq;
        Mock<IValidadorParceiro> validadorMoq;

        private ServicoParceiro servicoParceiro;

        Parceiro parceiro;

        public ServicoParceiroTest()
        {
            repositorioParceiroMoq = new Mock<IRepositorioParceiro>();
            validadorMoq = new Mock<IValidadorParceiro>();
            servicoParceiro = new ServicoParceiro(repositorioParceiroMoq.Object, validadorMoq.Object);
            parceiro = new Parceiro("Desconto do Deko");
        }

        [TestMethod]
        public void Deve_inserir_parceiro_caso_ela_for_valido() //cenário 1
        {
            //arrange
            parceiro = new Parceiro("Desconto do Deko");

            //action
            Result resultado = servicoParceiro.Inserir(parceiro);

            //assert 
            resultado.Should().BeSuccess();
            repositorioParceiroMoq.Verify(x => x.Inserir(parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_parceiro_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeParceiro = "Desconto do Deko";
            repositorioParceiroMoq.Setup(x => x.SelecionarPorNome(nomeParceiro))
                .Returns(() =>
                {
                    return new Parceiro(nomeParceiro);
                });

            //action
            var resultado = servicoParceiro.Inserir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeParceiro}' já está sendo utilizado");
            repositorioParceiroMoq.Verify(x => x.Inserir(parceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_parceiro() //cenário 4
        {
            repositorioParceiroMoq.Setup(x => x.Inserir(It.IsAny<Parceiro>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoParceiro.Inserir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir parceiro.");
        }

        [TestMethod]
        public void Deve_editar_parceiro_caso_ele_for_valido() //cenário 1
        {
            //arrange           
            parceiro = new Parceiro("iFood");

            //action
            Result resultado = servicoParceiro.Editar(parceiro);

            //assert 
            resultado.Should().BeSuccess();
            repositorioParceiroMoq.Verify(x => x.Editar(parceiro), Times.Once());
        }

        [TestMethod]
        public void Deve_editar_disciplina_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = new Guid();
            repositorioParceiroMoq.Setup(x => x.SelecionarPorNome("Desconto do Deko"))
                 .Returns(() =>
                 {
                     return new Parceiro(id, "Desconto do Deko");
                 });

            Parceiro outroParceiro = new Parceiro(id, "Desconto do Deko");

            //action
            var resultado = servicoParceiro.Editar(outroParceiro);

            //assert 
            resultado.Should().BeSuccess();

            repositorioParceiroMoq.Verify(x => x.Editar(outroParceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_parceiro_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            repositorioParceiroMoq.Setup(x => x.SelecionarPorNome("Desconto do Deko"))
                 .Returns(() =>
                 {
                     return new Parceiro("Desconto do Deko");
                 });

            Parceiro novoParceiro = new Parceiro("Desconto do Deko");

            //action
            var resultado = servicoParceiro.Editar(novoParceiro);

            //assert 
            resultado.Should().BeFailure();

            repositorioParceiroMoq.Verify(x => x.Editar(novoParceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_parceiro() //cenário 5
        {
            repositorioParceiroMoq.Setup(x => x.Editar(It.IsAny<Parceiro>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoParceiro.Editar(parceiro);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar parceiro.");
        }

        [TestMethod]
        public void Deve_excluir_parceiro_caso_ele_esteja_cadastrado() //cenário 1
        {
            //arrange
            var parceiro = new Parceiro("Desconto do Deko");

            repositorioParceiroMoq.Setup(x => x.Existe(parceiro))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoParceiro.Excluir(parceiro);

            //assert 
            resultado.Should().BeSuccess();
            repositorioParceiroMoq.Verify(x => x.Excluir(parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_parceiro_caso_ele_nao_esteja_cadastrado() //cenário 2
        {
            //arrange

            var parceiro = new Parceiro("Desconto do Deko");

            repositorioParceiroMoq.Setup(x => x.Existe(parceiro))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoParceiro.Excluir(parceiro);

            //assert 
            resultado.Should().BeFailure();
            repositorioParceiroMoq.Verify(x => x.Excluir(parceiro), Times.Never());
        }
    }
}
