using FluentResults;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using LocadoraVeiculo.Dominio.ModuloCupom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.ModuloCupom
{
    public partial class TelaCupomForm : Form
    {
        private Cupom cupom;
        public event GravarRegistroDelegate<Cupom> onGravarRegistro;
        public TelaCupomForm(List<Parceiro> parceiros)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarParceiros(parceiros);

        }
        public Cupom ObterCupom()
        {
            cupom.Nome = txtNome.Text;
            cupom.Parceiro = (Parceiro)txtListaParceiro.SelectedItem;
            cupom.Valor = Convert.ToDecimal(txtValor.Text);
            cupom.DataValidade = Convert.ToDateTime(DataValidade.Value);
            return cupom;
        }

        public void ConfigurarCupom(Cupom cupom)
        {
            this.cupom = cupom;
            txtNome.Text = cupom.Nome;
            txtListaParceiro.SelectedItem = cupom.Parceiro;
            txtValor.Text = cupom.Valor.ToString("0.00");
            DataValidade.Value = cupom.DataValidade;
        }
        private void CarregarParceiros(List<Parceiro> parceiros)
        {
            txtListaParceiro.Items.Clear();

            foreach (var item in parceiros)
            {
                txtListaParceiro.Items.Add(item);
            }
        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            this.cupom = ObterCupom();

            Result resultado = onGravarRegistro(cupom);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
