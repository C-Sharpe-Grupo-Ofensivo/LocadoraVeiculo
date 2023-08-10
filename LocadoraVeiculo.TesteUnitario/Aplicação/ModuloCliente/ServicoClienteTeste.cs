using FluentAssertions;
using FluentAssertions.Equivalency;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraVeiculo.Aplicacao.ModuloCliente;
using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloCupom;
using LocadoraVeiculo.TesteUnitario.Compartilhado;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace LocadoraVeiculo.TesteUnitario.Aplicação.ModuloCliente
{
    [TestClass]
    public class ServicoClienteTest
    {
        Mock<IRepositorioCliente> repositorioClienteMoq;
        Mock<IValidadorCliente> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoCliente servicoCliente;

        Cliente cliente;

        public ServicoClienteTest()
        {
            repositorioClienteMoq = new Mock<IRepositorioCliente>();
            validadorMoq = new Mock<IValidadorCliente>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoCliente = new ServicoCliente(repositorioClienteMoq.Object, validadorMoq.Object);

            cliente = new Cliente("alex", "alex@gmail.com", "49 99999-9999", TipoClienteEnum.CPF, "000.000.000-00", "cnpj", "SC", "Lages", "Centro", "Do arroz", 444);
        }


        [TestMethod]
        public void Deve_inserir_cliente_caso_ele_for_validp() //cenário 1
        {
            //action
            Result resultado = servicoCliente.Inserir(cliente);

            //assert 
            resultado.Should().BeSuccess();
            repositorioClienteMoq.Verify(x => x.Inserir(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_cliente_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCliente.Inserir(cliente);

            //assert 
            resultado.Should().BeFailure();
            repositorioClienteMoq.Verify(x => x.Inserir(cliente), Times.Never());
        }
        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_Cliente() //cenário 4
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
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir cliente.");
        }

        [TestMethod]
        public void Deve_editar_cliente_caso_ele_for_valido() //cenário 1
        {
            //arrange 
            cliente = new Cliente("CUPOMDEKO");

            //action
            Result resultado = servicoCliente.Editar(cliente);

            //assert 
            resultado.Should().BeSuccess();
            repositorioClienteMoq.Verify(x => x.Editar(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cliente_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Cliente>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCliente.Editar(cliente);

            //assert        
            resultado.Should().BeFailure();
            repositorioClienteMoq.Verify(x => x.Editar(cliente), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_cliente_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = Guid.NewGuid();

            repositorioClienteMoq.Setup(x => x.SelecionarPorNome("PEDRINHO"))
                 .Returns(() =>
                 {
                     return new Cliente(id, "PEDRINHO");
                 });


            Cliente outroCliente = new Cliente(id, "PEDRINHO");

            //action
            var resultado = servicoCliente.Editar(outroCliente);

            //assert 
            resultado.Should().BeSuccess();

            repositorioClienteMoq.Verify(x => x.Editar(outroCliente), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cliente_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            repositorioClienteMoq.Setup(x => x.SelecionarPorNome("PEDRINHO"))
                 .Returns(() =>
                 {
                     return new Cliente("PEDRINHO");
                 });

            Cliente novoCliente = new Cliente("PEDRINHO");

            //action
            var resultado = servicoCliente.Editar(novoCliente);

            //assert
            resultado.Should().BeFailure();

            repositorioClienteMoq.Verify(x => x.Editar(novoCliente), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_cliente() //cenário 5
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
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar cliente.");
        }

        [TestMethod]
        public void Deve_excluir_cliente_caso_ele_esteja_cadastrado() //cenário 1
        {
            //arrange
            var cliente = new Cliente("PEDRINHO");

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
            var cliente = new Cliente("PEDRINHO");

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

