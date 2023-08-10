using FluentValidation.TestHelper;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Dominio.ModuloFuncionario
{
    [TestClass]
    public class ValidadorFuncionarioTeste
    {
        private ValidadorFuncionario validador;
        private Funcionario funcionario;

        public ValidadorFuncionarioTeste()
        {
            validador = new ValidadorFuncionario();
            funcionario = new Funcionario();
        }

        [TestMethod]
        public void Nome_funcionario_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_funcionario_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            funcionario.Nome = "alex";

            //action
            var resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_funcionario_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            funcionario.Nome = "Dandy ";

            //action
            var resultado = validador.TestValidate(funcionario);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }
    }
}
