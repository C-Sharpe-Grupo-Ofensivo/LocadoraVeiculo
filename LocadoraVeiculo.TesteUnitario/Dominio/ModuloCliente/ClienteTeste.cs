using FluentValidation.Results;
using LocadoraVeiculo.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Dominio.ModuloCliente
{
    [TestClass]
    public class ClienteTeste
    {
        private ValidadorCliente validador;
        private Cliente cliente;

        [TestInitialize]
        public void Setup()
        {
            validador = new ValidadorCliente();
            cliente = new ("Pedro de Lara",TipoClienteEnum.CPF, "065.656.432-54");
        }

        [TestMethod]
        public void Validar_Cliente()
        {
            ValidationResult validacao = validador.Validate(cliente);
            Assert.IsNotNull(validacao);
        }
    }
}
