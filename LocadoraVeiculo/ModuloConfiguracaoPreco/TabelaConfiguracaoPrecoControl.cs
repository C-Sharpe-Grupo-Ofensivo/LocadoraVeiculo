using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.ModuloConfiguracaoPreco
{
    public partial class TabelaConfiguracaoPrecoControl : UserControl
    {
        public TabelaConfiguracaoPrecoControl()
        {
            InitializeComponent();
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                 new DataGridViewTextBoxColumn { DataPropertyName = "Preço da Gasolina", HeaderText = "Preço da Gasolina"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Preço do Álcool", HeaderText = "Preço do Álcool"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Preço do Disel", HeaderText = "Preço do Disel"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Preço do Gás", HeaderText = "Preço do Gás"}
            };

            return colunas;
        }

        internal void AtualizarRegistros(List<ConfiguracaoPreco> configuracaoPreco)
        {
            grid.Rows.Clear();

            foreach (ConfiguracaoPreco c in configuracaoPreco)
            {
                grid.Rows.Add(c.Id, c.precoGasolina, c.precoAlcool,c.precoDiesel,c.precoGas);
                   
            }
        }

        internal Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
