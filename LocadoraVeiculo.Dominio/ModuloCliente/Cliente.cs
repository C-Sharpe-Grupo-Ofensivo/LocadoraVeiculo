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
        public Cliente(TipoClienteEnum tipoCliente, string nome, string email, string telefone, string cpf, string cnpj, string estado, string cidade, string bairro, string rua, int numero)
        {
            TipoCliente = tipoCliente;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            Cnpj = cnpj;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
        }

        public Cliente() { }

        public TipoClienteEnum TipoCliente { get; set; } 

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get;set; }
        public string Cnpj { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }

        public override void Atualizar(Cliente registro)
        {
            Nome = registro.Nome;
            Email = registro.Email;
            Telefone = registro.Telefone;
            Cpf = registro.Cpf;
            Cnpj = registro.Cnpj;
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
                   Nome == cliente.Nome &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone &&
                   Cpf == cliente.Cpf &&
                   Cnpj == cliente.Cnpj &&
                   Estado == cliente.Estado &&
                   Cidade == cliente.Cidade &&
                   Bairro == cliente.Bairro &&
                   Rua == cliente.Rua &&
                   Numero == cliente.Numero;
            
        }


    }
}
