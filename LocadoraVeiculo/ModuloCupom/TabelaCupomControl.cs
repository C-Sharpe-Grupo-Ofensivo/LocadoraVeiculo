using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCupom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.ModuloCupom
{
    public partial class TabelaCupomControl : UserControl
    {
        public TabelaCupomControl()
        {
            InitializeComponent();
            gridCupom.ConfigurarGridZebrado();
            gridCupom.ConfigurarGridSomenteLeitura();
            gridCupom.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible = false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=45F },

                new DataGridViewTextBoxColumn { Name = "Parceiro", HeaderText = "Parceiro", FillWeight=25F },

                new DataGridViewTextBoxColumn { Name = "Valor", HeaderText = "Valor", FillWeight=25F },

                 new DataGridViewTextBoxColumn { Name = "Data de Validade", HeaderText = "Data de Validade", FillWeight=25F }
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return gridCupom.SelecionarId();
        }
        public void AtualizarRegistros(List<Cupom> cupons)
        {
            gridCupom.Rows.Clear();

            foreach (Cupom cupom in cupons)
            {
                gridCupom.Rows.Add(cupom.Id, cupom.Nome, cupom.Parceiro, "R$ " + cupom.Valor.ToString("0.00"), cupom.DataValidade.ToShortDateString());
            }
        }
    }
}
