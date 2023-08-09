using FluentValidation.TestHelper;
using LocadoraVeiculo.Dominio.ModuloCupom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Dominio.ModuloCupom
{
    [TestClass]
    public class ValidadorCupomTest
    {
        private Cupom cupom;
        private ValidadorCupom validador;

        public ValidadorCupomTest()
        {
            cupom = new Cupom();
            validador = new ValidadorCupom();
        }

        [TestMethod]
        public void Nome_cupom_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validador.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cupom_deve_ter_no_minimo_3_caracteres()
        {
            cupom.Nome = "DESCONTODEKO";

            var resultado = validador.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cupom_deve_ser_composto_por_letras_e_numeros()
        {
            cupom.Nome = "Cupom Deko";

            var resultado = validador.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }
    }
}

