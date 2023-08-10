using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloAluguel;
using LocadoraVeiculo.Dominio.ModuloCliente;
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

namespace LocadoraVeiculo.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        private Aluguel aluguel;
        IRepositorioCupom cupom;
        public event GravarRegistroDelegate<Aluguel> onGravarRegistro;
        public TelaAluguelForm()
        {
            InitializeComponent();
        }

        public void ConfigurarAluguel(Aluguel aluguel)
        {
            throw new NotImplementedException();
        }
    }
}
