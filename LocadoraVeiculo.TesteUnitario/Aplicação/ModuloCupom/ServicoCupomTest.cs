using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraVeiculo.Aplicacao.ModuloCupom;
using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCupom;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using LocadoraVeiculo.TesteUnitario.Compartilhado;
using Moq;

namespace LocadoraVeiculo.TesteUnitario.Aplicação.ModuloCupom
{
    [TestClass]
    public class ServicoCupomTest
    {
        Mock<IRepositorioCupom> repositorioCupomMoq;
        Mock<IValidadorCupom> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoCupom servicoCupom;

        Cupom cupom;
        Parceiro parceiro;

        public ServicoCupomTest()
        {
            repositorioCupomMoq = new Mock<IRepositorioCupom>();
            validadorMoq = new Mock<IValidadorCupom>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoCupom = new ServicoCupom(repositorioCupomMoq.Object, validadorMoq.Object);
            parceiro = new Parceiro("Arthur");

            cupom = new Cupom("CUPOMDODEKO", 200, new DateTime(24 / 02 / 2024), parceiro);
        }

        [TestMethod]
        public void Deve_inserir_cupom_caso_ele_for_validp() //cenário 1
        {
            //action
            Result resultado = servicoCupom.Inserir(cupom);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCupomMoq.Verify(x => x.Inserir(cupom), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_cupom_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Cupom>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCupom.Inserir(cupom);

            //assert 
            resultado.Should().BeFailure();
            repositorioCupomMoq.Verify(x => x.Inserir(cupom), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_cupom_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeCupom = "CUPOMDODEKO";
            repositorioCupomMoq.Setup(x => x.SelecionarPorNome(nomeCupom))
                .Returns(() =>
                {
                    return new Cupom(nomeCupom);
                });

            //action
            var resultado = servicoCupom.Inserir(cupom);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeCupom}' já está sendo utilizado");
            repositorioCupomMoq.Verify(x => x.Inserir(cupom), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_Cupom() //cenário 4
        {
            repositorioCupomMoq.Setup(x => x.Inserir(It.IsAny<Cupom>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCupom.Inserir(cupom);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir cupom.");
        }

        [TestMethod]
        public void Deve_editar_cupom_caso_ele_for_valido() //cenário 1
        {
            //arrange 
            cupom = new Cupom("CUPOMDODEKO");

            //action
            Result resultado = servicoCupom.Editar(cupom);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCupomMoq.Verify(x => x.Editar(cupom), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cupom_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<Cupom>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoCupom.Editar(cupom);

            //assert        
            resultado.Should().BeFailure();
            repositorioCupomMoq.Verify(x => x.Editar(cupom), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_cupom_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = Guid.NewGuid();

            repositorioCupomMoq.Setup(x => x.SelecionarPorNome("CUPOMDODEKO"))
                 .Returns(() =>
                 {
                     return new Cupom(id, "CUPOMDODEKO");
                 });


            Cupom outroCupom = new Cupom(id, "CUPOMDODEKO");

            //action
            var resultado = servicoCupom.Editar(outroCupom);

            //assert 
            resultado.Should().BeSuccess();

            repositorioCupomMoq.Verify(x => x.Editar(outroCupom), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cupom_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            //arrange
            repositorioCupomMoq.Setup(x => x.SelecionarPorNome("CUPOMDODEKO"))
                 .Returns(() =>
                 {
                     return new Cupom("CUPOMDODEKO");
                 });

            Cupom novoCupom = new Cupom("CUPOMDODEKO");

            //action
            var resultado = servicoCupom.Editar(novoCupom);

            //assert
            resultado.Should().BeFailure();

            repositorioCupomMoq.Verify(x => x.Editar(novoCupom), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_cupom() //cenário 5
        {
            repositorioCupomMoq.Setup(x => x.Editar(It.IsAny<Cupom>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoCupom.Editar(cupom);

            //assert
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar Cupom.");
        }

        [TestMethod]
        public void Deve_excluir_cupom_caso_ele_esteja_cadastrado() //cenário 1
        {
            //arrange
            var cupom = new Cupom("CUPOM10");

            repositorioCupomMoq.Setup(x => x.Existe(cupom))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoCupom.Excluir(cupom);

            //assert
            resultado.Should().BeSuccess();
            repositorioCupomMoq.Verify(x => x.Excluir(cupom), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_cupom_caso_ele_nao_esteja_cadastrado() //cenário 2
        {
            //arrange
            var cupom = new Cupom("CUPOM10");

            repositorioCupomMoq.Setup(x => x.Existe(cupom))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoCupom.Excluir(cupom);

            //assert
            resultado.Should().BeFailure();
            repositorioCupomMoq.Verify(x => x.Excluir(cupom), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_cupom() //cenário 3
        {
            var cupom = new Cupom("CUPOM10");

            repositorioCupomMoq.Setup(x => x.Existe(It.IsAny<Cupom>()))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoCupom.Excluir(cupom);

            //assert
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir cupom");
        }

     
    }
}
