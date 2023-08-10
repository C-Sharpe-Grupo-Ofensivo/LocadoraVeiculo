using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraVeiculo.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculo.TesteUnitario.Compartilhado;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Aplicação.ModuloPlanoCobranca
{
    [TestClass]
    public class ServicoCobrancaTest
    {
        Mock<IRepositorioGrupoAutomovel> repositorioGrupoAutomoveis;
        Mock<IRepositorioPlanoCobranca> repositorioCobrancaMoq;
        Mock<IValidadorPlanoCobranca> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoPlanoCobranca servicoPlanoCobranca;

        GrupoAutomovel grupoAutomovel;
        PlanoCobranca planoCobranca;

        public ServicoCobrancaTest()
        {
            repositorioCobrancaMoq = new Mock<IRepositorioPlanoCobranca>();
            validadorMoq = new Mock<IValidadorPlanoCobranca>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoPlanoCobranca = new ServicoPlanoCobranca(repositorioCobrancaMoq.Object, validadorMoq.Object);

            grupoAutomovel = new GrupoAutomovel("SUVs");
            planoCobranca = new PlanoCobranca(grupoAutomovel, "CHUCK Norris", planoCobranca.TipoPlano , 20, 0);
        }

        [TestMethod]
        public void Deve_inserir_cobranca_caso_ele_for_valida() //cenário 1
        {
            //action
            Result resultado = servicoPlanoCobranca.Inserir(planoCobranca);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCobrancaMoq.Verify(x => x.Inserir(planoCobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_cobranca_caso_ela_seja_invalida() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<PlanoCobranca>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoPlanoCobranca.Inserir(planoCobranca);

            //assert 
            resultado.Should().BeFailure();
            repositorioCobrancaMoq.Verify(x => x.Inserir(planoCobranca), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_Cobranca() //cenário 4
        {
            repositorioCobrancaMoq.Setup(x => x.Inserir(It.IsAny<PlanoCobranca>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoPlanoCobranca.Inserir(planoCobranca);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir plano de cobrança.");
        }

        [TestMethod]
        public void Deve_editar_cobranca_caso_ele_for_valido() //cenário 1
        {
            //action
            Result resultado = servicoPlanoCobranca.Editar(planoCobranca);

            //assert 
            resultado.Should().BeSuccess();
            repositorioCobrancaMoq.Verify(x => x.Editar(planoCobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_cobranca_caso_ele_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<PlanoCobranca>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Preço Diária", "Preço Diária não pode ser menor que 0."));
                    return resultado;
                });

            //action
            var resultado = servicoPlanoCobranca.Editar(planoCobranca);

            //assert        
            resultado.Should().BeFailure();
            repositorioCobrancaMoq.Verify(x => x.Editar(planoCobranca), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_cobranca() //cenário 5
        {
            repositorioCobrancaMoq.Setup(x => x.Editar(It.IsAny<PlanoCobranca>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoPlanoCobranca.Editar(planoCobranca);

            //assert
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar plano de cobrança.");
        }

        [TestMethod]
        public void Deve_excluir_cobranca_caso_ele_esteja_cadastrado() //cenário 1
        {
            //arrange
            repositorioCobrancaMoq.Setup(x => x.Existe(planoCobranca))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoPlanoCobranca.Excluir(planoCobranca);

            //assert
            resultado.Should().BeSuccess();
            repositorioCobrancaMoq.Verify(x => x.Excluir(planoCobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_cobranca_caso_ele_nao_esteja_cadastrado() //cenário 2
        {
            //arrange
            repositorioCobrancaMoq.Setup(x => x.Existe(planoCobranca))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoPlanoCobranca.Excluir(planoCobranca);

            //assert
            resultado.Should().BeFailure();
            repositorioCobrancaMoq.Verify(x => x.Excluir(planoCobranca), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_cobranca() //cenário 3
        {
            repositorioCobrancaMoq.Setup(x => x.Existe(It.IsAny<PlanoCobranca>()))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoPlanoCobranca.Excluir(planoCobranca);

            //assert
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir plano de cobrança");
        }

        [TestMethod]
        public void Nao_deve_excluir_cobranca_caso_ele_esteja_relacionado_com_aluguel() //cenário 4
        {
            repositorioCobrancaMoq.Setup(x => x.Existe(planoCobranca))
               .Returns(() =>
               {
                   return true;
               });

            repositorioCobrancaMoq.Setup(x => x.Excluir(It.IsAny<PlanoCobranca>()))
                .Throws(() =>
                {
                    return SqlExceptionCreator.NewSqlException(errorMessage: "FK_TBAluguel_TBCobranca");
                });

            //action
            Result resultado = servicoPlanoCobranca.Excluir(planoCobranca);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Este plano de cobrança está relacionado com um aluguel e não pode ser excluído");
        }
    }
}
