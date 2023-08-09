using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
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
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using FluentResults;
using LocadoraVeiculo.Dominio.ModuloCliente;

namespace LocadoraVeiculo.ModuloPlanoCobranca
{
    public partial class TelaPlanoCobrancaForm : Form
    {
        private PlanoCobranca planoCobranca;
        public GravarRegistroDelegate<PlanoCobranca> onGravarRegistro;
        public TelaPlanoCobrancaForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public PlanoCobranca ObterPlanoCobranca()
        {
            planoCobranca.GrupoAutomovel = (GrupoAutomovel)cmbGrupoAutomovel.SelectedItem;
            planoCobranca.TipoPlano = (TìpoPlanoCobrancaEnum)cmbTipoPlano.SelectedItem;
            planoCobranca.PrecoKm = txtPrecoKm.Value;
            planoCobranca.KmDisponivel = txtKmDisponivel.Value;
            planoCobranca.PrecoDiaria = txtPlanoDiario.Value;

            return planoCobranca;
        }

        public void ConfigurarPlanoCobranca(PlanoCobranca planoCobranca)
        {
            this.planoCobranca = planoCobranca;

            txtKmDisponivel.Value = planoCobranca.KmDisponivel;
            txtPlanoDiario.Value = planoCobranca.PrecoDiaria;
            txtPrecoKm.Value = planoCobranca.PrecoKm;
            cmbGrupoAutomovel.SelectedItem = planoCobranca.GrupoAutomovel;
            cmbTipoPlano.SelectedItem = planoCobranca.TipoPlano;


        }

        //      txtNome.Text = cliente.Nome;
        //    txtEmail.Text = cliente.Email;
        //    txtTelefone.Text = cliente.Telefone;
        //    txtEstado.Text = cliente.Estado;
        //    txtCidade.Text = cliente.Cidade;
        //    txtBairro.Text = cliente.Bairro;
        //    txtRua.Text = cliente.Rua;
        //    txtNumero.Text = cliente.Numero.ToString();
        //    txtCpf.Text = cliente.Cpf;
        //    txtCnpj.Text = cliente.Cnpj;



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            planoCobranca = ObterPlanoCobranca();

            Result resultado = onGravarRegistro(planoCobranca);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
