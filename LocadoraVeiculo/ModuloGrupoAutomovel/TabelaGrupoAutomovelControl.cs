using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.ModuloGrupoAutomovel
{
    public partial class TabelaGrupoAutomovelControl : UserControl
    {
        public TabelaGrupoAutomovelControl()
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

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=15F }
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<GrupoAutomovel> gruposAutomovel)
        {
            grid.Rows.Clear();

            foreach (GrupoAutomovel g in gruposAutomovel)
            {
                grid.Rows.Add(g.Id, g.Nome);
            }
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
