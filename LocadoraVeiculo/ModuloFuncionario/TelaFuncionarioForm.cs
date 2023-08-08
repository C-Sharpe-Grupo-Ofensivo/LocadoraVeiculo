using FluentResults;
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
    public partial class TelaFuncionarioForm : Form
    {
        private Funcionario funcionario;

        public event GravarRegistroDelegate<Funcionario> onGravarRegistro;
        public TelaFuncionarioForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();

        }
        public Funcionario ObterFuncionario()
        {
            
            funcionario.Nome = txtNome.Text;
            funcionario.DataAdmissao = Convert.ToDateTime(dtpDataAdmissao.Text);
            funcionario.Salario = Convert.ToDouble(txtSalario.Text);

            return funcionario;
        }
        public void ConfigurarFuncionario(Funcionario funcionario)
        {
            this.funcionario = funcionario;
            funcionario.DataAdmissao = DateTime.Now;
            txtId.Text = funcionario.Id.ToString();
            txtNome.Text = funcionario.Nome;
            txtSalario.Text = funcionario.Salario.ToString();
            dtpDataAdmissao.Text = funcionario.DataAdmissao.ToShortDateString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.funcionario = ObterFuncionario();

            Result resultado = onGravarRegistro(funcionario);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }

        private void TelaFuncionarioForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
