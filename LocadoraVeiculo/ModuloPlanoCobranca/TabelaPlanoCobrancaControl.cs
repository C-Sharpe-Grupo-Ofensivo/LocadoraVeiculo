using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
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

namespace LocadoraVeiculo.ModuloPlanoCobranca
{
    public partial class TabelaPlanoCobrancaControl : UserControl
    {
        public TabelaPlanoCobrancaControl()
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

                new DataGridViewTextBoxColumn { Name = "ValorDiaria", HeaderText = "Nome", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "ValorKm", HeaderText = "Valor Km", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "TipoPlano", HeaderText = "Tipo Plano", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "KmDisponivel", HeaderText = "Km Disponivel", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "GrupoAutomovel", HeaderText = "Grupo Automovel", FillWeight=15F }
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }
        public void AtualizarRegistros(List<PlanoCobranca> planoCobrancas)
        {
            grid.Rows.Clear();

            foreach (PlanoCobranca p in planoCobrancas)
            {

                grid.Rows.Add(p.Id, p.PrecoDiaria, p.PrecoKm, p.TipoPlano, p.KmDisponivel, p.GrupoAutomovel);
            }


        }
    }
}
