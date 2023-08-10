using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraVeiculo.Aplicacao.ModuloFuncionario;
using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using LocadoraVeiculo.TesteUnitario.Compartilhado;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Aplicação.ModuloFuncionario
{
    [TestClass]
    public class ServicoFuncionarioTeste
    {
        Mock<IRepositorioFuncionario> repositorioFuncionarioMoq;
        Mock<IValidadorFuncionario> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoFuncionario servicoFuncionario;

        Funcionario funcionario;
       
        public ServicoFuncionarioTeste()
        {
            repositorioFuncionarioMoq = new Mock<IRepositorioFuncionario>();
            validadorMoq = new Mock<IValidadorFuncionario>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoFuncionario = new ServicoFuncionario(repositorioFuncionarioMoq.Object, validadorMoq.Object);
            funcionario = new Funcionario (new Guid(),"Dandy", DateTime.Now, 2000);
        }

        [TestMethod]
        public void Deve_funcionario_caso_for_valido() //cenário 1
        {
            //action
            Result resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_funcionario_caso_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Funcionario>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoFuncionario.Inserir(funcionario);

            //assert             
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_funcionario_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            Guid id = Guid.NewGuid();
            //arrange
            string nomeFuncionario = "Dandy";
            float salarioFuncionario = 1500;
            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome(nomeFuncionario))
                .Returns(() =>
                {
                    return new Funcionario(id,nomeFuncionario);
                });

            //action
            var resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeFuncionario}' já está sendo utilizado");
            repositorioFuncionarioMoq.Verify(x => x.Inserir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_funcionario() //cenário 4
        {
            repositorioFuncionarioMoq.Setup(x => x.Inserir(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoFuncionario.Inserir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir funcionario.");
        }

        [TestMethod]
        public void Deve_editar_funcionario_caso_seja_valido() //cenário 1
        {
            Guid id = Guid.NewGuid();
            //arrange           
            funcionario = new Funcionario(id, "Dandy");

            //action
            Result resultado = servicoFuncionario.Editar(funcionario);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Editar(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_funcionario_caso_ela_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Funcionario>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoFuncionario.Editar(funcionario);

            //assert             
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Editar(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_funcionario_com_o_mesmo_nome() //cenário 3
        {
            Guid id = Guid.NewGuid();
            //arrange
            repositorioFuncionarioMoq.Setup(x => x.SelecionarPorNome("Dandy"))
                 .Returns(() =>
                 {
                     return new Funcionario(id, "Dandy");
                 });

            Funcionario outraFuncionario = new Funcionario(id, "Dandy");

            //action
            var resultado = servicoFuncionario.Editar(outraFuncionario);

            //assert 
            resultado.Should().BeSuccess();

            repositorioFuncionarioMoq.Verify(x => x.Editar(outraFuncionario), Times.Once());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_funcionario() //cenário 5
        {
            repositorioFuncionarioMoq.Setup(x => x.Editar(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoFuncionario.Editar(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar funcionario.");
        }

        [TestMethod]
        public void Deve_excluir_funcionario_caso_ela_esteja_cadastrada() //cenário 1
        {
            Guid id = Guid.NewGuid();
            //arrange
            var funcionario = new Funcionario(id, "Dandy");

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeSuccess();
            repositorioFuncionarioMoq.Verify(x => x.Excluir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_funcionario_caso_ela_nao_esteja_cadastrada() //cenário 2
        {
            Guid id = Guid.NewGuid();
            //arrange

            var funcionario = new Funcionario(id, "Dandy");

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            repositorioFuncionarioMoq.Verify(x => x.Excluir(funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_disciplina() //cenário 4
        {
            Guid id = Guid.NewGuid();

            var funcionario = new Funcionario(id, "Dandy");

            repositorioFuncionarioMoq.Setup(x => x.Existe(funcionario))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoFuncionario.Excluir(funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir funcionario");
        }
    }
}
        
    

