using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloTaxaServico
{
    public class TaxaServico : EntidadeBase<TaxaServico>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public TipoPlanoCalculoEnum TipoPlano { get; set; }
        public TaxaServico() { }
        public TaxaServico(string nome, decimal preco, TipoPlanoCalculoEnum tipoPlano)
        {
            Nome = nome;
            Preco = preco;
            TipoPlano = tipoPlano;
        }

        public TaxaServico(int id, string nome, decimal preco, TipoPlanoCalculoEnum tipoPlano)
        {
            this.Id = id;
            Nome = nome;
            Preco = preco;
            TipoPlano = tipoPlano;
        }
        
        public override string ToString()
        {
            return Nome;
        }

        public override void Atualizar(TaxaServico registro)
        {
            Nome = registro.Nome;
            Preco = registro.Preco;
            TipoPlano = registro.TipoPlano;
        }
    }
}
