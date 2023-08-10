using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.ModuloCondutor
{
    public partial class TabelaCondutorControl : UserControl
    {
        public TabelaCondutorControl()
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
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Cliente", HeaderText = "Cliente", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Cpf", HeaderText = "Cpf", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Cnh", HeaderText = "Cnh", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Validade", HeaderText = "Validade", FillWeight=85F },
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Condutor> condutores)
        {
            grid.Rows.Clear();

            foreach (Condutor condutor in condutores)
            {
                grid.Rows.Add(condutor.Id, condutor.Nome, condutor.Cliente.Nome, condutor.Cpf, condutor.Cnh, condutor.Validade);
            }
        }
        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
