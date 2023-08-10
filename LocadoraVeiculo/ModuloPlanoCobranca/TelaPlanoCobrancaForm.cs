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
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using System.Collections;
using LocadoraVeiculo.Dominio.Compartilhado;

namespace LocadoraVeiculo.ModuloPlanoCobranca
{
    public partial class TelaPlanoCobrancaForm : Form
    {
        private PlanoCobranca planoCobranca;
        public GravarRegistroDelegate<PlanoCobranca> onGravarRegistro;
        public TelaPlanoCobrancaForm(List<GrupoAutomovel> repositorioGrupoAutomovel)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarGrupoAutomovel(repositorioGrupoAutomovel);
            CarregarOpcoesDePlano();
          
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

            txtKmDisponivel.Value = Convert.ToDecimal(planoCobranca.KmDisponivel);
            txtPlanoDiario.Value = Convert.ToDecimal(planoCobranca.PrecoDiaria);
            txtPrecoKm.Value = Convert.ToDecimal(planoCobranca.PrecoKm);
            cmbGrupoAutomovel.SelectedItem = planoCobranca.GrupoAutomovel;
            cmbTipoPlano.SelectedItem = planoCobranca.TipoPlano;

            if ((TìpoPlanoCobrancaEnum)cmbTipoPlano.SelectedItem == TìpoPlanoCobrancaEnum.PlanoCobrancaDiario)
            {
                txtKmDisponivel.Text = "";
              
                txtPrecoKm.Text = planoCobranca?.PrecoKm.ToString();
                txtPlanoDiario.Text = planoCobranca.PrecoDiaria.ToString();
            }

            if ((TìpoPlanoCobrancaEnum)cmbTipoPlano.SelectedItem == TìpoPlanoCobrancaEnum.PlanoCobrancaControlado)
            {
                txtPrecoKm.Text = "";
                txtPlanoDiario.Text = planoCobranca.PrecoDiaria.ToString();
                txtKmDisponivel.Text = planoCobranca?.KmDisponivel.ToString();
                
            }

            if ((TìpoPlanoCobrancaEnum)cmbTipoPlano.SelectedItem == TìpoPlanoCobrancaEnum.PlanoCobrancaKmLivre)
            {
                txtPrecoKm.Text = "";
                txtKmDisponivel.Text = "";          
                txtPlanoDiario.Text = planoCobranca.PrecoDiaria.ToString();
            }


        }

        private void CarregarGrupoAutomovel(List<GrupoAutomovel> grupoAutomovel)
        {
            foreach (GrupoAutomovel grupo in grupoAutomovel)
            {
                cmbGrupoAutomovel.Items.Add(grupo);
            }
        }

        //txtNome.Text = cliente.Nome;
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

        private void CarregarOpcoesDePlano()
        {
            TìpoPlanoCobrancaEnum[] plano = Enum.GetValues<TìpoPlanoCobrancaEnum>();

            foreach (TìpoPlanoCobrancaEnum opcaoPlano in plano)
            {
                cmbTipoPlano.Items.Add(opcaoPlano);
            }

            cmbTipoPlano.SelectedIndex = 0;
        }

       
    }
}
