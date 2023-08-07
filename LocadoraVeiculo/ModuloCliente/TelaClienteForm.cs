using FluentResults;
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
    public partial class TelaClienteForm : Form
    {
        private Cliente cliente { get; set; }
        public event GravarRegistroDelegate<Cliente> onGravarRegistro;
        public TelaClienteForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();

        }

        public void ConfigurarTela(Cliente clienteSelecionado)
        {
            this.cliente = clienteSelecionado;
            txtNome.Text = clienteSelecionado.Nome;
            txtEmail.Text = clienteSelecionado.Email;
            txtTelefone.Text = clienteSelecionado.Telefone;
            txtCpf.Text = clienteSelecionado.Cpf;
            txtCnpj.Text = clienteSelecionado.Cnpj;
            txtEstado.Text = clienteSelecionado.Estado;
            txtCidade.Text = clienteSelecionado.Cidade;
            txtBairro.Text = clienteSelecionado.Bairro;
            txtRua.Text = clienteSelecionado.Rua;
            txtNumero.Text = clienteSelecionado.Numero.ToString();
        }

        public Cliente ObterCliente()
        {

            cliente.Nome = txtNome.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.Cnpj = txtCnpj.Text;
            cliente.Estado = txtEstado.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Rua = txtRua.Text;
            cliente.Numero = Convert.ToInt32(txtNumero.Text);

            if (cliente.TipoCliente == TipoClienteEnum.CPF)
            {
                rdnPessoaFisica.Checked = true;
                cliente.TipoCliente = TipoClienteEnum.CPF;

                txtCpf.Text = cliente.Cpf;
            }
            else
            {
                rdnPessoaJuridica.Checked = true;
                cliente.TipoCliente = TipoClienteEnum.CNPJ;

                txtCnpj.Text = cliente.Cnpj;
            }

            return cliente;
        }

        public void ConfigurarCliente(Cliente cliente)
        {
            this.cliente = cliente;


            txtNome.Text = cliente.Nome;
            txtEmail.Text = cliente.Email;
            txtTelefone.Text = cliente.Telefone;
            txtEstado.Text = cliente.Estado;
            txtCidade.Text = cliente.Cidade;
            txtBairro.Text = cliente.Bairro;
            txtRua.Text = cliente.Rua;
            txtNumero.Text = cliente.Numero.ToString();
            txtCpf.Text = cliente.Cpf;
            txtCnpj.Text = cliente.Cnpj;

        }

        private void rdnPessoaFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnPessoaFisica.Checked)
            {
                txtCpf.Enabled = true;
                txtCnpj.Enabled = false;
                txtCnpj.Text = "";
            }
            else
            {
                txtCpf.Enabled = false;

            }
        }

        private void rdnPessoaJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnPessoaJuridica.Checked)
            {
                txtCpf.Enabled = false;
                txtCnpj.Enabled = true;
                txtCpf.Text = "";
            }
            else
            {
                txtCnpj.Enabled = false;

            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            cliente = ObterCliente();

            Result resultado = onGravarRegistro(cliente);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
