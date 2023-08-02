using LocadoraVeiculo.Dominio.Compartilhado;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }

        public DateTime DataAdmissao { get; set; }

        public double Salario { get; set; }

        public Funcionario(string nome, DateTime dataAdmissao, float salario)
        {
            Nome = nome;
            DataAdmissao = dataAdmissao;
            Salario = salario;
        }
        public Funcionario()
        {

        }

        public override void Atualizar(Funcionario registro)
        {
            Nome = registro.Nome;
            DataAdmissao = registro.DataAdmissao;
            Salario = registro.Salario;
        }

    }
}
