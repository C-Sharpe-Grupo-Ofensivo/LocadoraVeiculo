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

namespace LocadoraVeiculo.ModuloAutomovel
{
    public partial class TelaFiltroAutomovelForm : Form
    {

        public GrupoAutomovel grupoAutomovel;
        public TelaFiltroAutomovelForm(IRepositorioGrupoAutomovel repositorioGrupoAutomovel)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            ConfigurarComboBox(repositorioGrupoAutomovel);
        }
        private void ConfigurarComboBox(IRepositorioGrupoAutomovel repositorioGrupoAutomovel)
        {
            foreach (var item in repositorioGrupoAutomovel.SelecionarTodos())
            {
                txtListaGrupoAutomoveis.Items.Add(item);
            }

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            grupoAutomovel = (GrupoAutomovel)txtListaGrupoAutomoveis.SelectedItem;
        }
    }
}
