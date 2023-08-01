using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraDeVeiculos.WinApp.Compartilhado;
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
            funcionario.Id = Convert.ToInt32(txtId.Text);
            funcionario.Nome = txtNome.Text;

            return funcionario;
        }
        public void ConfigurarFuncionario(Funcionario funcionario)
        {
            this.funcionario = funcionario;

            txtId.Text = funcionario.Id.ToString();
            txtNome.Text = funcionario.Nome;
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
    }
}
