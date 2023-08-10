using FluentResults;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.ModuloConfiguracaoPreco
{
    public partial class TelaConfiguracaoPrecoForm : Form
    {
        private ConfiguracaoPreco configuracaoPreco;
        public event GravarRegistroDelegate<ConfiguracaoPreco> onGravarRegistro;
        public TelaConfiguracaoPrecoForm()
        {
            InitializeComponent();
        }

        public void ConfigurarTela(ConfiguracaoPreco configuracaoPreco)
        {
            this.configuracaoPreco = configuracaoPreco;

            txtGasolina.Value = configuracaoPreco.precoGasolina;
            txtAlcool.Value = configuracaoPreco.precoAlcool;
            txtDiesel.Value = configuracaoPreco.precoDiesel;
            txtGas.Value = configuracaoPreco.precoGas;
        }

        public ConfiguracaoPreco ObterPreco()
        {

            configuracaoPreco.precoGasolina = txtGasolina.Value;
            configuracaoPreco.precoAlcool = txtAlcool.Value;
            configuracaoPreco.precoDiesel = txtDiesel.Value;
            configuracaoPreco.precoGas = txtGas.Value;

            return configuracaoPreco;
        }

     




        private void btnGravar_Click(object sender, EventArgs e)
        {
            this.configuracaoPreco = ObterPreco();

            Result resultado = onGravarRegistro(configuracaoPreco);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
