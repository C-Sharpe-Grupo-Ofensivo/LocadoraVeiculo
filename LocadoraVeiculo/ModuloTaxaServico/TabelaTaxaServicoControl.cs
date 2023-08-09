
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.ModuloTaxaServico
{
    public partial class TabelaTaxaServicoControl : UserControl
    {
        public TabelaTaxaServicoControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible = false},

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "Preço", HeaderText = "Preço", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "Tipo", HeaderText = "Tipo", FillWeight=15F }
            };

            return colunas;
        }
        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }
        public void AtualizarRegistros(List<TaxaServico> taxas)
        {
            grid.Rows.Clear();

            foreach (TaxaServico t in taxas)
            {
                string tipo;
                if (t.TipoPlano == TipoPlanoCalculoEnum.CobrancaDiaria)
                    tipo = "Cobrança Diária";
                else
                    tipo = "Preço Fixo";
                grid.Rows.Add(t.Id, t.Nome, t.Preco, tipo);
            }
        }
    }
}
