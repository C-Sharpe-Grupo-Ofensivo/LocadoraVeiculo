using FluentValidation.TestHelper;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Dominio.ModuloGrupoAutomovel
{
    [TestClass]
    public class ValidadorGrupoAutomoveisTeste
    {
        private ValidadorGrupoAutomovel validador;
        private GrupoAutomovel grupoAutomoveis;

        public ValidadorGrupoAutomoveisTeste()
        {
            grupoAutomoveis = new GrupoAutomovel();

            validador = new ValidadorGrupoAutomovel();
        }

        [TestMethod]
        public void Nome_GrupoAutomoveis_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(grupoAutomoveis);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_GrupoAutomoveis_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            grupoAutomoveis.Nome = "Camioneta";

            //action
            var resultado = validador.TestValidate(grupoAutomoveis);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_GrupoAutomoveis_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            grupoAutomoveis.Nome = "@ PUNTO";

            //action
            var resultado = validador.TestValidate(grupoAutomoveis);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }
    }
}
