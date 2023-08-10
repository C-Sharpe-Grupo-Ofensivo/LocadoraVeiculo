using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloAluguel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.ModuloAluguel
{
    public partial class TabelaAluguelControl : UserControl
    {
        public TabelaAluguelControl()
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
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight = 15F, Visible = false },
                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight = 35F },
                new DataGridViewTextBoxColumn { Name = "Veiculo", HeaderText = "Veículo", FillWeight = 25F },
                new DataGridViewTextBoxColumn { Name = "Plano", HeaderText = "Plano Selecionado", FillWeight = 25F },
                new DataGridViewTextBoxColumn { Name = "DataSaida", HeaderText = "Data de Saída", FillWeight = 25F },
                new DataGridViewTextBoxColumn { Name = "DataPrevista", HeaderText = "Data Prevista", FillWeight = 20F },
                
            };
            return colunas;
        }
        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }
        public void AtualizarRegistros(List<Aluguel> alugueis)
        {
            grid.Rows.Clear();
            foreach (Aluguel aluguel in alugueis)
            {
                grid.Rows.Add(aluguel.Id,
                                    aluguel.Condutor.Nome,
                                    aluguel.Automovel.Placa,
                                    aluguel.PlanoCobranca,
                                    aluguel.DataLocacao,
                                    aluguel.DataLocacao,
                                    aluguel.DevolucaoPrevista,
                                    aluguel.ValorTotalPrevisto);
            }
        }

    }
}
