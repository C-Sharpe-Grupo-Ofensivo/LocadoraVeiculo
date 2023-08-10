using FluentAssertions;
using FluentResults;
using FluentValidation.Results;
using FluentResults.Extensions.FluentAssertions;
using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using LocadoraVeiculo.TesteUnitario.Compartilhado;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculo.Aplicacao.ModuloTaxaServico;

namespace LocadoraVeiculo.TesteUnitario.Aplicação.ModuloTaxaServico
{
    [TestClass]
    public class ServicoTaxasServicosTest
    {
        Mock<IRepositorioTaxaServico> repositorioTaxasServicosMoq;
        Mock<IValidadorTaxaServico> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;

        private ServicoTaxasServicos servicoTaxasServicos;
        TaxaServico taxasServicos;

        public ServicoTaxasServicosTest()
        {
            repositorioTaxasServicosMoq = new Mock<IRepositorioTaxaServico>();
            validadorMoq = new Mock<IValidadorTaxaServico>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoTaxasServicos = new ServicoTaxasServicos(repositorioTaxasServicosMoq.Object, validadorMoq.Object);

            taxasServicos = new TaxaServico(new Guid(), "teste", 12, TipoPlanoCalculoEnum.CobrancaDiaria);
        }


        [TestMethod]
        public void Deve_inserir_taxasServicos_caso_ela_for_valida()
        {
            //action
            Result resultado = servicoTaxasServicos.Inserir(taxasServicos);

            //assert
            resultado.Should().BeSuccess();
            repositorioTaxasServicosMoq.Verify(x => x.Inserir(taxasServicos), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_taxasServicos_caso_ela_seja_invalida()
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<TaxaServico>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoTaxasServicos.Inserir(taxasServicos);

            //assert
            resultado.Should().BeFailure();
            repositorioTaxasServicosMoq.Verify(x => x.Inserir(taxasServicos), Times.Never());
        }


        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_taxasServicos()
        {
            repositorioTaxasServicosMoq.Setup(x => x.Inserir(It.IsAny<TaxaServico>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoTaxasServicos.Inserir(taxasServicos);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir serviço.");
        }

        [TestMethod]
        public void Deve_editar_taxasServicos_caso_ela_for_valido()
        {
            //arrange 
            taxasServicos = new TaxaServico(new Guid(), "teste", 12, TipoPlanoCalculoEnum.CobrancaDiaria);

            //action
            Result resultado = servicoTaxasServicos.Editar(taxasServicos);

            //assert 
            resultado.Should().BeSuccess();
            repositorioTaxasServicosMoq.Verify(x => x.Editar(taxasServicos), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_taxasServicos_caso_ele_seja_invalido()
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<TaxaServico>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoTaxasServicos.Editar(taxasServicos);

            //assert        
            resultado.Should().BeFailure();
            repositorioTaxasServicosMoq.Verify(x => x.Editar(taxasServicos), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_editar_taxasServicos_caso_o_nome_ja_esteja_cadastrado()
        {
            //arrange
            repositorioTaxasServicosMoq.Setup(x => x.SelecionarPorNome("TESTE01"))
            .Returns(() =>
            {
                return new TaxaServico(new Guid(), "teste", 12, TipoPlanoCalculoEnum.CobrancaDiaria);
            });

            TaxaServico novoTaxaServico = new TaxaServico(new Guid(), "teste", 12, TipoPlanoCalculoEnum.CobrancaDiaria);

            //action
            var resultado = servicoTaxasServicos.Editar(novoTaxaServico);

            //assert
            resultado.Should().BeFailure();

            repositorioTaxasServicosMoq.Verify(x => x.Editar(novoTaxaServico), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_taxasServicos()
        {
            repositorioTaxasServicosMoq.Setup(x => x.Editar(It.IsAny<TaxaServico>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoTaxasServicos.Editar(taxasServicos);

            //assert
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar serviço.");
        }

        [TestMethod]
        public void Deve_excluir_taxasServicos_caso_ele_esteja_cadastrado()
        {
            //arrange
            var taxaServico = new TaxaServico(new Guid(), "teste", 12, TipoPlanoCalculoEnum.CobrancaDiaria);

            repositorioTaxasServicosMoq.Setup(x => x.Existe(taxasServicos))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoTaxasServicos.Excluir(taxasServicos);

            //assert
            resultado.Should().BeSuccess();
            repositorioTaxasServicosMoq.Verify(x => x.Excluir(taxasServicos), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_taxasServicos_caso_ela_nao_esteja_cadastrada()
        {
            //arrange
            var taxasServico = new TaxaServico(new Guid(), "teste", 12, TipoPlanoCalculoEnum.CobrancaDiaria);

            repositorioTaxasServicosMoq.Setup(x => x.Existe(taxasServicos))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoTaxasServicos.Excluir(taxasServicos);

            //assert
            resultado.Should().BeFailure();
            repositorioTaxasServicosMoq.Verify(x => x.Excluir(taxasServicos), Times.Never());
        }


        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_excluir_taxasServicos()
        {
            var taxaServico = new TaxaServico(new Guid(), "teste", 12, TipoPlanoCalculoEnum.CobrancaDiaria);

            repositorioTaxasServicosMoq.Setup(x => x.Existe(It.IsAny<TaxaServico>()))
              .Throws(() =>
              {
                  return SqlExceptionCreator.NewSqlException();
              });

            //action
            Result resultado = servicoTaxasServicos.Excluir(taxasServicos);

            //assert
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar excluir serviço");
        }

    }
}
