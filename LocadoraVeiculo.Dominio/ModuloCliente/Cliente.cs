using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
       

        public Cliente() { }

        public Cliente(string nome) : this()
        {
            Nome = nome;
        }

        public Cliente(Guid id) : this()
        {
            Id = id;
        }

        public Cliente(string nome, TipoClienteEnum tipoCliente, string cpf) : this()
        {
            Nome = nome;
            TipoCliente = tipoCliente;
            Cpf = cpf;

        }

        public TipoClienteEnum TipoCliente { get; set; } 

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }

        public override void Atualizar(Cliente registro)
        {
           
            Nome = registro.Nome;
            Cpf = registro.Cpf;
            Cnpj = registro.Cnpj;
            Email = registro.Email;
            Telefone = registro.Telefone;
            Estado = registro.Estado;
            Cidade = registro.Cidade;
            Bairro = registro.Bairro;
            Rua = registro.Rua;
            Numero = registro.Numero;


        }

        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                   Id == cliente.Id &&
                   TipoCliente == cliente.TipoCliente &&
                   Nome == cliente.Nome &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone &&
                   Estado == cliente.Estado &&
                   Cidade == cliente.Cidade &&
                   Bairro == cliente.Bairro &&
                   Rua == cliente.Rua &&
                   Numero == cliente.Numero &&
                   Cpf == cliente.Cpf &&
                   Cnpj == cliente.Cnpj;
            
        }


    }
}
