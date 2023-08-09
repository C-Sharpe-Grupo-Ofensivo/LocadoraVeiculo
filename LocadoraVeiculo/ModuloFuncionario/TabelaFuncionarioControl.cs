using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.ModuloFuncionario
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
        {

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

                new DataGridViewTextBoxColumn { DataPropertyName = "Preço do Gás", HeaderText = "Preço do Gás"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Preço do Disel", HeaderText = "Preço do Disel"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Preço do Alcool", HeaderText = "Preço do Alcool"}

            };

            return colunas;
        }

        public Guid ObterIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(ConfiguracaoPreco configPreco)
        {
            grid.Rows.Clear();

            grid.Rows.Add(configPreco.precoGasolina, configPreco.precoGas, configPreco.precoDiesel, configPreco.precoAlcool);

        }
    }
}
