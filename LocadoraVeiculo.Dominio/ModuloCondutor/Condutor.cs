using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public Cliente Cliente { get; set; }

        public bool ClienteCondutor { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Cpf { get; set; }

        public string Cnh { get; set; }

        public DateTime Validade { get; set; }

        public Condutor()
        {

        }

        public Condutor(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Condutor(string nome)
        {
            Nome = nome;
        }

        public Condutor(Cliente cliente, bool clienteCondutor, string nome, string email, string telefone, string cpf, string cnh, DateTime validade)
        {
            Cliente = cliente;
            ClienteCondutor = clienteCondutor;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            Cnh = cnh;
            Validade = validade;
        }

        public override void Atualizar(Condutor registro)
        {
            Cliente = registro.Cliente;
            ClienteCondutor = registro.ClienteCondutor;
            Nome = registro.Nome;
            Email = registro.Email;
            Telefone = registro.Telefone;
            Cpf = registro.Cpf;
            Cnh = registro.Cnh;
            Validade = registro.Validade;
        }
    }
}
