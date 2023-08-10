using FluentValidation.TestHelper;
using LocadoraVeiculo.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Dominio.ModuloCliente
{
    [TestClass]
    public class ValidadorClienteTest
    {
        private Cliente cliente;
        private ValidadorCliente validador;

        public ValidadorClienteTest()
        {
            cliente = new Cliente();
            validador = new ValidadorCliente();
        }

        [TestMethod]
        public void Nome_cliente_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cliente_deve_ter_no_minimo_6_caracteres()
        {
            cliente.Nome = "Pedro De Lara";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cliente_deve_ser_composto_por_letras()
        {
            cliente.Nome = "Cliente";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Email_cliente_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [TestMethod]
        public void Email_cliente_deve_ser_um_endereco_de_email_valido()
        {
            cliente.Email = "email invalido";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [TestMethod]
        public void Telefone_cliente_deve_estar_no_formato_valido()
        {
            cliente.Telefone = "(48) 33233233";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Telefone);
        }

        [TestMethod]
        public void Cpf_cliente_deve_estar_no_formato_valido()
        {
            cliente.Cpf = "322.346.099-12345";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Cpf);
        }

        [TestMethod]
        public void Cnpj_cliente_deve_estar_no_formato_valido()
        {
            cliente.Cnpj = "93.000.000/8000800-17";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Cnpj);
        }

        [TestMethod]
        public void Estado_cliente_deve_ter_exatamente_2_caracteres()
        {
            cliente.Estado = "Santa Catarina";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Estado);
        }


    }
}
