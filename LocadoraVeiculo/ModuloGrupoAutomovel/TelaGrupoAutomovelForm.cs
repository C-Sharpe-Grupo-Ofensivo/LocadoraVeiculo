using FluentResults;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculo.ModuloGrupoAutomovel
{
    public partial class TelaGrupoAutomovelForm : Form
    {
        private GrupoAutomovel grupoAutomovel;

        public event GravarRegistroDelegate<GrupoAutomovel> onGravarRegistro;
        public TelaGrupoAutomovelForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }
        public GrupoAutomovel ObterGrupo()
        {

            grupoAutomovel.Nome = txtNome.Text;

            return grupoAutomovel;
        }

        public void ConfigurarGrupo(GrupoAutomovel grupoAutomovel)
        {

            this.grupoAutomovel = grupoAutomovel;
            txtNome.Text = grupoAutomovel.Nome;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            grupoAutomovel = ObterGrupo();

            Result resultado = onGravarRegistro(grupoAutomovel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Text = grupoAutomovel.Nome;
        }
    }
}

