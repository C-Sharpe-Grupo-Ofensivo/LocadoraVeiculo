using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraVeiculo.Aplicacao.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloCliente;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Aplicação.ModuloCliente
{
    [TestClass]
    public class ServicoClienteTeste
    {

        Mock<IRepositorioCliente> repositorioClienteMoq;
        Mock<IValidadorCliente> validadorMoq;

        private ServicoCliente servicoCliente;

        Cliente cliente;

        public ServicoClienteTeste()
        {
            repositorioClienteMoq = new Mock<IRepositorioCliente>();
            validadorMoq = new Mock<IValidadorCliente>();
            servicoCliente = new ServicoCliente(repositorioClienteMoq.Object, validadorMoq.Object);
            cliente = new Cliente("Nome do Cliente");
        }

        [TestMethod]
        public void Deve_inserir_cliente_caso_ele_for_valido() //cenário 1
        {
            //arrange
            cliente = new Cliente("Nome do Cliente");

            //action
            Result resultado = servicoCliente.Inserir(cliente);

            //assert 
            resultado.Should().BeSuccess();
            repositorioClienteMoq.Verify(x => x.Inserir(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_cliente_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeCliente = "Nome do Cliente";
            repositorioClienteMoq.Setup(x => x.SelecionarPorNome(nomeCliente))
                .Returns(() =>
                {
                    return new Cliente(nomeCliente);
                });

            //action
            var resultado = servicoCliente.Inserir(cliente);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeCliente}' já está sendo utilizado");
            repositorioClienteMoq.Verify(x => x.Inserir(cliente), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_cliente() //cenário 4
        {
            repositorioClienteMoq.Setup(x => x.Inserir(It.IsAny<Cliente>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCliente.Inserir(cliente);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir Cliente");
        }

        [TestMethod]
        public void Deve_editar_cliente_caso_ele_for_valido() //cenário 1
        {
            //arrange           
            cliente = new Cliente("Nome do Cliente");

            //action
            Result resultado = servicoCliente.Editar(cliente);

            //assert 
            resultado.Should().BeSuccess();
            repositorioClienteMoq.Verify(x => x.Editar(cliente), Times.Once());
        }

        [TestMethod]
        public void Deve_editar_Cliente_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = new Guid();
            repositorioClienteMoq.Setup(x => x.SelecionarPorNome("Nome do Cliente"))
                 .Returns(() =>
                 {
                     return new Cliente ("nome", TipoClienteEnum.CPF,"cpf");
                 });


            Cliente outroCliente = new Cliente();
            //action
            var resultado = servicoCliente.Editar(outroCliente);

            //assert 
            resultado.Should().BeSuccess();

            repositorioClienteMoq.Verify(x => x.Editar(outroCliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_Cliente_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            repositorioClienteMoq.Setup(x => x.SelecionarPorNome("Nome do Cliente"))
                 .Returns(() =>
                 {
                     return new Cliente("Nome do Cliente");
                 });

            Cliente novoCliente = new Cliente("Nome do Cliente");

            //action
            var resultado = servicoCliente.Editar(novoCliente);

            //assert 
            resultado.Should().BeFailure();

            repositorioClienteMoq.Verify(x => x.Editar(novoCliente), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_Cliente() //cenário 5
        {
            repositorioClienteMoq.Setup(x => x.Editar(It.IsAny<Cliente>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCliente.Editar(cliente);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar Cliente");
        }

        [TestMethod]
        public void Deve_excluir_cliente_caso_ele_esteja_cadastrado() //cenário 1
        {
            //arrange
            var cliente = new Cliente("Nome do Cliente");

            repositorioClienteMoq.Setup(x => x.Existe(cliente))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoCliente.Excluir(cliente);

            //assert 
            resultado.Should().BeSuccess();
            repositorioClienteMoq.Verify(x => x.Excluir(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_cliente_caso_ele_nao_esteja_cadastrado() //cenário 2
        {
            //arrange

            var cliente = new Cliente("Nome do Cliente");

            repositorioClienteMoq.Setup(x => x.Existe(cliente))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoCliente.Excluir(cliente);

            //assert 
            resultado.Should().BeFailure();
            repositorioClienteMoq.Verify(x => x.Excluir(cliente), Times.Never());
        }
    }
}
