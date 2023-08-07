using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCliente;
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

namespace LocadoraVeiculo.ModuloCliente
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
        {
            InitializeComponent();
            gridCliente.ConfigurarGridZebrado();
            gridCliente.ConfigurarGridSomenteLeitura();
            gridCliente.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F, Visible=false },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },
                new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", FillWeight=85F },
                new DataGridViewTextBoxColumn { Name = "Telefone", HeaderText = "Telefone", FillWeight=85F },
                new DataGridViewTextBoxColumn { Name = "TipCliente", HeaderText = "Tipo Cliente", FillWeight=85F },
                new DataGridViewTextBoxColumn { Name = "Cpf", HeaderText = "Cpf", FillWeight=85F },
                new DataGridViewTextBoxColumn { Name = "Cnpj", HeaderText = "Cnpj", FillWeight=85F }
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return gridCliente.SelecionarId();
        }
        public void AtualizarRegistros(List<Cliente> clientes)
        {
            gridCliente.Rows.Clear();

            foreach (Cliente cliente in clientes)
            {
                gridCliente.Rows.Add(cliente.Id, cliente.Nome, cliente.Email, cliente.Telefone, cliente.TipoCliente, cliente.Cpf, cliente.Cnpj) ;
            }
        }


    }
}
