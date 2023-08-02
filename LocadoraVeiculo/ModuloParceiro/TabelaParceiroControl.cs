using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.ModuloParceiro
{
    public partial class TabelaParceiroControl : UserControl
    {
        public TabelaParceiroControl()
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

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F }
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Parceiro> parceiros)
        {
            grid.Rows.Clear();

            foreach (Parceiro parceiro in parceiros)
            {
                grid.Rows.Add(parceiro.Id, parceiro.Nome);
            }
        }

    }
}
