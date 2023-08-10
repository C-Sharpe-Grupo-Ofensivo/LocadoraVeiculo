using LocadoraVeiculo.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Aplicação.ModuloCliente
{
    [TestClass]
    public class ClienteTeste
    {
        Cliente cliente;
        //Condutor condutor01;

        public ClienteTeste()
        {
            cliente = new Cliente("Beto loco");
            //condutor01 = new Condutor();
        }

        [TestMethod]
        public void Materias_Devem_ser_diferentes_de_null()
        {
            //cliente.Condutores.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_permitir_adicionar_condutores_na_cliente()
        {
            //Arrange
            //Condutor condutor02 = new Condutor();

            ////Action
            //cliente.AdicionarCondutor(condutor01);
            //cliente.AdicionarCondutor(condutor02);

            ////Assert            
            //cliente.Condutores.Count.Should().Be(2);
        }

        [TestMethod]
        public void Nao_deve_adicionar_condutores_iguais_no_cliente()
        {
            //arrange
            //condutor01 = new Condutor();

            ////action
            //cliente.AdicionarCondutor(condutor01);
            //cliente.AdicionarCondutor(condutor01);

            ////assert
            //cliente.Condutores.Should().HaveCount(1);
        }
    }
}
