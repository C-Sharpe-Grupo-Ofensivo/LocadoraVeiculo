using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloCupom;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase<Aluguel>
    {
        public Aluguel()
        {
        }

        public Aluguel(Funcionario funcionario, Cliente cliente, GrupoAutomovel grupoAutomovel,
            PlanoCobranca planoCobranca, /*Condutor condutor,*/ Automovel automovel, decimal kmAutomovel, 
            DateTime dataLocacao, DateTime devolucaoPrevista, Cupom cupom, decimal valorTotalPrevisto,
            List<TaxaServico> taxaServico)
        {
            Funcionario = funcionario;
            Cliente = cliente;
            GrupoAutomovel = grupoAutomovel;
            PlanoCobranca = planoCobranca;
            //Condutor = condutor;
            Automovel = automovel;
            KmAutomovel = kmAutomovel;
            DataLocacao = dataLocacao;
            DevolucaoPrevista = devolucaoPrevista;
            Cupom = cupom;
            ValorTotalPrevisto = valorTotalPrevisto;
            TaxaServico = taxaServico;
        }

        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public GrupoAutomovel GrupoAutomovel { get; set; }
        public PlanoCobranca PlanoCobranca { get; set; }
        //public Condutor Condutor { get; set; }
        public Automovel Automovel { get; set; }
        public decimal KmAutomovel { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DevolucaoPrevista { get; set; }
        public Cupom Cupom { get; set; }
        public decimal ValorTotalPrevisto { get; set; }
        public List<TaxaServico> TaxaServico { get; set; }
        public override void Atualizar(Aluguel registroAtualizado)
        {
            Funcionario = registroAtualizado.Funcionario;
            Cliente = registroAtualizado.Cliente;
            GrupoAutomovel = registroAtualizado.GrupoAutomovel;
            PlanoCobranca = registroAtualizado.PlanoCobranca;
            //Condutor = registroAtualizado.Condutor;
            Automovel = registroAtualizado.Automovel;
            KmAutomovel = registroAtualizado.KmAutomovel;
            DataLocacao = registroAtualizado.DataLocacao;
            DevolucaoPrevista = registroAtualizado.DevolucaoPrevista;
            Cupom = registroAtualizado.Cupom;
            ValorTotalPrevisto = registroAtualizado.ValorTotalPrevisto;
            TaxaServico = registroAtualizado.TaxaServico;
        }

        public decimal CupomValor()
        {
            if (Cupom.DataValidade > DateTime.Now)
                return ValorTotalPrevisto -= Cupom.Valor;
            else
                return 0;
        }
    }
}
