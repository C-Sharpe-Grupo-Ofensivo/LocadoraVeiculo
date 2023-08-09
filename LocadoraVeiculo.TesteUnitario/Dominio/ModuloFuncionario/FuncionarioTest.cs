using LocadoraVeiculo.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.TesteUnitario.Dominio.ModuloFuncionario
{
    [TestClass]
    public class FuncionarioTeste
    {
        Funcionario funcionario;

        public FuncionarioTeste()
        {
            funcionario = new Funcionario(new Guid(), "Dandy", DateTime.Now, 2000);
        }
    }
}
