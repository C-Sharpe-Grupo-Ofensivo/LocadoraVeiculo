using LocadoraVeiculo.Compartilhado;
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

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Data de Admissão", HeaderText = "Data de Admissão", FillWeight=20F },

                new DataGridViewTextBoxColumn { Name = "Salário", HeaderText = "Salário", FillWeight=20F }
            };

            return colunas;
        }
        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }
        public void AtualizarRegistros(List<Funcionario> funcionarios)
        {
            grid.Rows.Clear();

            foreach (Funcionario funcionario in funcionarios)
            {
                grid.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.DataAdmissao.ToShortDateString(), funcionario.Salario);
            }
        }
        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
