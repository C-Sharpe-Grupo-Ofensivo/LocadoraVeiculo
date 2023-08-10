using System;
using FluentResults;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloCondutor;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocadoraVeiculo.Compartilhado;

namespace LocadoraVeiculo.ModuloCondutor
{
    public partial class TelaCondutorForm : Form
    {
        private Condutor condutor;
        public event GravarRegistroDelegate<Condutor> onGravarRegistro;

        public TelaCondutorForm(List<Cliente> clientes)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            CarregarClientes(clientes);
        }

        public Condutor ObterCondutor()
        {
            condutor.Cliente = (Cliente)cbCliente.SelectedItem;
            condutor.Cnh = txtCnh.Text;
            condutor.Cpf = txtCpf.Text;
            condutor.Email = txtEmail.Text;
            condutor.Nome = txtNome.Text;
            condutor.Telefone = txtTelefone.Text;
            condutor.ClienteCondutor = chEhCondutor.Checked;
            condutor.Validade = dateValidade.Value;

            return condutor;
        }

        public void ConfigurarCondutor(Condutor condutor)
        {
            this.condutor = condutor;
            txtEmail.Text = condutor.Email;
            txtCpf.Text = condutor.Cpf;
            txtCnh.Text = condutor.Cnh;
            txtTelefone.Text = condutor.Telefone;
            txtNome.Text = condutor.Nome;
            cbCliente.SelectedItem = condutor.Cliente;
            chEhCondutor.Checked = condutor.ClienteCondutor;
            dateValidade.MinDate = condutor.Validade;
        }

        private void CarregarClientes(List<Cliente> clientes)
        {
            foreach (Cliente cliente in clientes)
            {
                cbCliente.Items.Add(cliente);
            }
        }

        private void chEhCondutor_CheckedChanged(object sender, EventArgs e)
        {
            if (condutor == null)
                condutor = new Condutor();

            Cliente cliente = (Cliente)cbCliente.SelectedItem;

            txtNome.Text = cliente.Nome;
            txtTelefone.Text = cliente.Telefone;
            txtEmail.Text = cliente.Email;
            txtCpf.Text = cliente.Cpf;
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            this.condutor = ObterCondutor();

            Result resultado = onGravarRegistro(condutor);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
