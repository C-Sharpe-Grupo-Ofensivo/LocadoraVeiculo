using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraVeiculo.Aplicacao.ModuloCondutor;
using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloCondutor;
using LocadoraVeiculo.TesteUnitario.Compartilhado;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Aplicação.ModuloCondutor
{
    [TestClass]
    public class ServicoCondutorTest
    {
        Mock<IRepositorioCondutor> repositorioCondutorMoq;
        Mock<IValidadorCondutor> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoCondutor servicoCondutor;
        Condutor condutor;
        Cliente cliente;

        public ServicoCondutorTest()
        {
            repositorioCondutorMoq = new Mock<IRepositorioCondutor>();
            validadorMoq = new Mock<IValidadorCondutor>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoCondutor = new ServicoCondutor(repositorioCondutorMoq.Object, validadorMoq.Object, contextoMoq.Object);

            cliente = new Cliente("Pedrita");

            condutor = new Condutor(cliente, true, "Pedrita", "Pedrita@gmail.com", "49 99999-9999", "999.999.99-99", "9999999", DateTime.Now);
        }


        [TestMethod]
        public void Deve_inserir_condutor_caso_ele_for_valido() //cenário 1
        {
            //action
            Result resultado = servicoCondutor.Inserir(condutor);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCondutorMoq.Verify(x => x.Inserir(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_condutor_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Condutor>()))
                .Returns(() =>
                {
                    var resultado = new FluentValidation.Results.ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCondutor.Inserir(condutor);

            //assert 
            resultado.Should().BeFailure();
            repositorioCondutorMoq.Verify(x => x.Inserir(condutor), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_condutor_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeCondutor = "Pedrita mae";
            repositorioCondutorMoq.Setup(x => x.SelecionarPorNome(nomeCondutor))
                .Returns(() =>
                {
                    return new Condutor(nomeCondutor);
                });

            //action
            var resultado = servicoCondutor.Inserir(condutor);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{condutor.Nome}' já está sendo utilizado");
            repositorioCondutorMoq.Verify(x => x.Inserir(condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_Condutor() //cenário 4
        {
            repositorioCondutorMoq.Setup(x => x.Inserir(It.IsAny<Condutor>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCondutor.Inserir(condutor);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir Condutor.");
        }

        [TestMethod]
        public void Deve_editar_condutor_caso_ele_for_valido() //cenário 1
        {
            //arrange 
            condutor = new Condutor(cliente, true, "buiu", "buiu@gmail.com", "49 11111-1111", "11.111.111-11", "111111111", DateTime.Now);

            //action
            Result resultado = servicoCondutor.Editar(condutor);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCondutorMoq.Verify(x => x.Editar(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_condutor_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Condutor>()))
                .Returns(() =>
                {
                    var resultado = new FluentValidation.Results.ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCondutor.Editar(condutor);

            //assert        
            resultado.Should().BeFailure();
            repositorioCondutorMoq.Verify(x => x.Editar(condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_condutor_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            string nomeCondutor = "defante";
            Guid id = Guid.NewGuid();

            repositorioCondutorMoq.Setup(x => x.SelecionarPorNome(nomeCondutor))
                .Returns(() =>
                {
                    return new Condutor(id, nomeCondutor);
                });

            Condutor outroCondutor = new Condutor(id, nomeCondutor);

            //action
            var resultado = servicoCondutor.Editar(outroCondutor);

            //assert 
            resultado.Should().BeSuccess();

            repositorioCondutorMoq.Verify(x => x.Editar(outroCondutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_condutor_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            string nomeCondutor = "defante";

            repositorioCondutorMoq.Setup(x => x.SelecionarPorNome(nomeCondutor))
                .Returns(() =>
                {
                    return new Condutor(nomeCondutor);
                });

            Condutor novoCondutor = new Condutor(nomeCondutor);

            //action
            var resultado = servicoCondutor.Editar(novoCondutor);

            //assert
            resultado.Should().BeFailure();

            repositorioCondutorMoq.Verify(x => x.Editar(novoCondutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_condutor() //cenário 5
        {
            repositorioCondutorMoq.Setup(x => x.Editar(It.IsAny<Condutor>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCondutor.Editar(condutor);

            //assert
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar Condutor.");
        }

        [TestMethod]
        public void Deve_excluir_condutor_caso_ele_esteja_cadastrado() //cenário 1
        {
            //arrange
            var condutor = new Condutor(cliente, true, "casemiro", "casel@gmail.com", "49 444444444", "444.444.444-44", "44444444", DateTime.Now);

            repositorioCondutorMoq.Setup(x => x.Existe(condutor))
                .Returns(() =>
                {
                    return true;
                });

            //action
            var resultado = servicoCondutor.Excluir(condutor);

            //assert
            resultado.Should().BeSuccess();
            repositorioCondutorMoq.Verify(x => x.Excluir(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_condutor_caso_ele_nao_esteja_cadastrado() //cenário 2
        {
            //arrange
            var condutor = new Condutor(cliente, true, "gaules", "gaulesl@gmail.com", "22 22222-2222", "222.222.222-22", "22222222", DateTime.Now);

            repositorioCondutorMoq.Setup(x => x.Existe(condutor))
                .Returns(() =>
                {
                    return false;
                });

            //action
            var resultado = servicoCondutor.Excluir(condutor);

            //assert
            resultado.Should().BeFailure();
            repositorioCondutorMoq.Verify(x => x.Excluir(condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_condutor() //cenário 3
        {
            var condutor = new Condutor(cliente, true, "gaules", "gaules@gmail.com", "22 22222-2222", "222.222.222-22", "22222222", DateTime.Now);

            repositorioCondutorMoq.Setup(x => x.Existe(It.IsAny<Condutor>()))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException();
                });

            //action
            Result resultado = servicoCondutor.Excluir(condutor);

            //assert
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir Condutor");
        }

     
    }
}
