using FluentResults;
using LocadoraVeiculo.Compartilhado;
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

namespace LocadoraVeiculo.ModuloTaxaServico
{
    public partial class TelaTaxaServicoForm : Form
    {
        private TaxaServico taxaServico;

        public GravarRegistroDelegate<TaxaServico> GravarRegistro;
        public TelaTaxaServicoForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
            rdbPrecoFixo.Checked = true;
        }

        public TaxaServico ObterTaxa()
        {
            taxaServico.Nome = txtNome.Text;
            taxaServico.Preco = Convert.ToDecimal(txtPreco.Text);
            if (rdbPrecoFixo.Checked)
                taxaServico.TipoPlano = TipoPlanoCalculoEnum.PrecoFixo;
            else if (rdbCobrancaDiaria.Checked)
                taxaServico.TipoPlano = TipoPlanoCalculoEnum.CobrancaDiaria;
            return taxaServico;
        }

        public void ConfigurarTaxa(TaxaServico taxaServico)
        {
            this.taxaServico = taxaServico;
            txtNome.Text = taxaServico.Nome;
            txtPreco.Text = taxaServico.Preco.ToString();
            if (taxaServico.TipoPlano == TipoPlanoCalculoEnum.CobrancaDiaria)
            {
                rdbPrecoFixo.Checked = false;
                rdbCobrancaDiaria.Checked = true;
            }
            else if (taxaServico.TipoPlano == TipoPlanoCalculoEnum.PrecoFixo)
            {
                rdbPrecoFixo.Checked = true;
                rdbCobrancaDiaria.Checked = false;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            taxaServico = ObterTaxa();

            Result resultado = GravarRegistro(taxaServico);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
