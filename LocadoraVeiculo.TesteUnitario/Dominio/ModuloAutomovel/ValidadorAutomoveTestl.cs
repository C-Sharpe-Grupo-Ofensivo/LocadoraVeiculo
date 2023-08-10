using FluentValidation.TestHelper;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Dominio.ModuloAutomovel
{
    [TestClass]
    public class ValidadorAutomovelTest
    {
        private Automovel automovel;
        private ValidadorAutomovel validador;

        public ValidadorAutomovelTest()
        {
            automovel = new Automovel();
            validador = new ValidadorAutomovel();
        }

        [TestMethod]
        public void Nome_automovel_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validador.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Modelo);
        }

        [TestMethod]
        public void GrupoDoAutomovel_deve_ser_obrigatorio()
        {
            var resultado = validador.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.GrupoAutomovel);
        }

        [TestMethod]
        public void Modelo_deve_ser_obrigatorio()
        {
            var resultado = validador.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Modelo);
        }

        [TestMethod]
        public void Marca_deve_ser_obrigatoria()
        {
            var resultado = validador.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Marca);
        }

        [TestMethod]
        public void Cor_deve_ser_obrigatoria()
        {
            var resultado = validador.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Cor);
        }
    }
}
