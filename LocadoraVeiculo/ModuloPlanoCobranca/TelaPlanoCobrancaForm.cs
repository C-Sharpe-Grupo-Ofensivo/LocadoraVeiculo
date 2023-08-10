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

namespace LocadoraVeiculo.ModuloPlanoCobranca
{
    public partial class TelaPlanoCobrancaForm : Form
    {
        private PlanoCobranca planoCobranca;
        public GravarRegistroDelegate<PlanoCobranca> onGravarRegistro;
        public TelaPlanoCobrancaForm(IRepositorioGrupoAutomovel repositorioGrupoAutomovel)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            ConfigurarListas(repositorioGrupoAutomovel);
        }



        private void ConfigurarListas(IRepositorioGrupoAutomovel repositorioGrupoAutomovel)
        {
            foreach (var grupo in repositorioGrupoAutomovel.SelecionarTodos())
            {
                cmbGrupoAutomovel.Items.Add(grupo);
            }
            cmbTipoPlano.Items.Add(TìpoPlanoCobrancaEnum.PlanoCobrancaKmLivre);
            cmbTipoPlano.Items.Add(TìpoPlanoCobrancaEnum.PlanoCobrancaControlado);
            cmbTipoPlano.Items.Add(TìpoPlanoCobrancaEnum.PlanoCobrancaKmLivre);
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
    }
}
