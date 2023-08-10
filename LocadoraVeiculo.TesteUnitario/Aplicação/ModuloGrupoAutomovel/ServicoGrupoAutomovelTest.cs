using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraVeiculo.Aplicacao.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Aplicação.ModuloGrupoAutomovel
{
    [TestClass]
    public class ServicoGrupoAutomoveisTeste
    {
        Mock<IRepositorioGrupoAutomovel> repositorioGrupoAutomoveisMoq;
        Mock<IValidadorGrupoAutomovel> validadorMoq;
        Mock<IContextoPersistencia> contextoMoq;
        private ServicoGrupoAutomovel servicoGrupoAutomoveis;
        GrupoAutomovel grupoAutomoveis;

        public ServicoGrupoAutomoveisTeste()
        {
            repositorioGrupoAutomoveisMoq = new Mock<IRepositorioGrupoAutomovel>();
            validadorMoq = new Mock<IValidadorGrupoAutomovel>();
            contextoMoq = new Mock<IContextoPersistencia>();
            servicoGrupoAutomoveis = new ServicoGrupoAutomovel(repositorioGrupoAutomoveisMoq.Object, validadorMoq.Object);
            grupoAutomoveis = new GrupoAutomovel("GrupoDeAutomovel");
        }

        [TestMethod]
        public void Deve_inserir_GrupoAutomoveis_caso_seja_valido() //cenário 1
        {
            //arrange
            grupoAutomoveis = new GrupoAutomovel("GrupoDeAutomovel2");

            //action
            Result resultado = servicoGrupoAutomoveis.Inserir(grupoAutomoveis);

            //assert 
            resultado.Should().BeSuccess();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Inserir(grupoAutomoveis), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_inserir_GrupoAutomoveis_caso_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<GrupoAutomovel>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoGrupoAutomoveis.Inserir(grupoAutomoveis);

            //assert             
            resultado.Should().BeFailure();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Inserir(grupoAutomoveis), Times.Never());
        }

        [TestMethod]
        public void Nao_deve_inserir_GrupoAutomoveis_caso_o_nome_ja_esteja_cadastrado() //cenário 3
        {
            //arrange
            string nomeGrupoAutomovel = "GrupoDeAutomovel";
            repositorioGrupoAutomoveisMoq.Setup(x => x.SelecionarPorNome(nomeGrupoAutomovel))
                .Returns(() =>
                {
                    return new GrupoAutomovel(nomeGrupoAutomovel);
                });

            //action
            var resultado = servicoGrupoAutomoveis.Inserir(grupoAutomoveis);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be($"Este nome '{nomeGrupoAutomovel}' já está sendo utilizado");
            repositorioGrupoAutomoveisMoq.Verify(x => x.Inserir(grupoAutomoveis), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_inserir_grupoAutomoveis() //cenário 4
        {
            repositorioGrupoAutomoveisMoq.Setup(x => x.Inserir(It.IsAny<GrupoAutomovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoGrupoAutomoveis.Inserir(grupoAutomoveis);

            //assert 
            resultado.Should().BeFailure();
            resultado.Reasons[0].Message.Should().Be("Falha ao tentar inserir Grupo de Automoveis.");
        }

        [TestMethod]
        public void Deve_editar_GrupoAutomoveis_caso_for_valido() //cenário 1
        {
            //arrange           
            grupoAutomoveis = new GrupoAutomovel("GrupoAutomovel1");

            //action
            Result resultado = servicoGrupoAutomoveis.Editar(grupoAutomoveis);

            //assert 
            resultado.Should().BeSuccess();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Editar(grupoAutomoveis), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_GrupoAutomoveis_caso_seja_invalido() //cenário 2
        {
            //arrange
            validadorMoq.Setup(x => x.Validate(It.IsAny<GrupoAutomovel>()))
                .Returns(() =>
                {
                    var resultado = new ValidationResult();
                    resultado.Errors.Add(new ValidationFailure("Nome", "Nome não pode ter caracteres especiais"));
                    return resultado;
                });

            //action
            var resultado = servicoGrupoAutomoveis.Editar(grupoAutomoveis);

            //assert             
            resultado.Should().BeFailure();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Editar(grupoAutomoveis), Times.Never());
        }

        [TestMethod]
        public void Deve_editar_GrupoAutomoveis_com_o_mesmo_nome() //cenário 3
        {
            //arrange
            Guid id = Guid.NewGuid();

            repositorioGrupoAutomoveisMoq.Setup(x => x.SelecionarPorNome("GrupoDeAutomovel1"))
            .Returns(() =>
            {
                return new GrupoAutomovel(id, "GrupoDeAutomovel");
            });

            GrupoAutomovel outraGrupoAutomoveis = new GrupoAutomovel(id, "GrupoDeAutomovel1");

            //action
            var resultado = servicoGrupoAutomoveis.Editar(outraGrupoAutomoveis);

            //assert 
            resultado.Should().BeSuccess();

            repositorioGrupoAutomoveisMoq.Verify(x => x.Editar(outraGrupoAutomoveis), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_editar_GrupoAutomoveis_caso_o_nome_ja_esteja_cadastrado() //cenário 4
        {
            Guid id = Guid.NewGuid();
            //arrange
            repositorioGrupoAutomoveisMoq.Setup(x => x.SelecionarPorNome("GrupoDeAutomoveis01"))
            .Returns(() =>
            {
                return new GrupoAutomovel(id, "GrupoDeAutomovel1");
            });

            GrupoAutomovel novaDisciplina = new GrupoAutomovel("GrupoDeAutomovel");

            //action
            var resultado = servicoGrupoAutomoveis.Editar(novaDisciplina);

            //assert 
            resultado.Should().BeFailure();

            repositorioGrupoAutomoveisMoq.Verify(x => x.Editar(novaDisciplina), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_caso_ocorra_falha_ao_tentar_editar_GrupoAutomoveis() //cenário 5
        {
            repositorioGrupoAutomoveisMoq.Setup(x => x.Editar(It.IsAny<GrupoAutomovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = servicoGrupoAutomoveis.Editar(grupoAutomoveis);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors[0].Message.Should().Be("Falha ao tentar editar Grupo de Automoveis.");
        }

        [TestMethod]
        public void Deve_excluir_GrupoAutomoveis_caso_esteja_cadastrado() //cenário 1
        {
            Guid id = Guid.NewGuid();
            //arrange
            var disciplina = new GrupoAutomovel(id, "GrupoAutomovel1");

            repositorioGrupoAutomoveisMoq.Setup(x => x.Existe(disciplina))
               .Returns(() =>
               {
                   return true;
               });

            //action
            var resultado = servicoGrupoAutomoveis.Excluir(disciplina);

            //assert 
            resultado.Should().BeSuccess();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Excluir(disciplina), Times.Once());
        }

        [TestMethod]
        public void Nao_deve_excluir_GrupoAutomoveis_caso_ela_nao_esteja_cadastrada() //cenário 2
        {
            Guid id = Guid.NewGuid();
            //arrange
            var grupoAutomoveis = new GrupoAutomovel(id, "Grupoautomovel");

            repositorioGrupoAutomoveisMoq.Setup(x => x.Existe(grupoAutomoveis))
               .Returns(() =>
               {
                   return false;
               });

            //action
            var resultado = servicoGrupoAutomoveis.Excluir(grupoAutomoveis);

            //assert 
            resultado.Should().BeFailure();
            repositorioGrupoAutomoveisMoq.Verify(x => x.Excluir(grupoAutomoveis), Times.Never());
        }
    }
}
