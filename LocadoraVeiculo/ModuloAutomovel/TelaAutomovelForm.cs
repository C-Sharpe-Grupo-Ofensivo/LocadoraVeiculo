using FluentResults;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
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
    public partial class TelaAutomovelForm : Form
    {
        private Automovel automovel;

        public event GravarRegistroDelegate<Automovel> onGravarRegistro;

        public TelaAutomovelForm(IRepositorioGrupoAutomovel repositorioGrupoAutomovel)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            ConfigurarComboBox(repositorioGrupoAutomovel);
        }

        private void ConfigurarComboBox(IRepositorioGrupoAutomovel repositorioGrupoAutomovel)
        {
            foreach (var item in repositorioGrupoAutomovel.SelecionarTodos())
            {
                txtListaGrupoAutomovel.Items.Add(item);
            }
            txtListaTipoCombustivel.Items.Add(TipoCombustivelEnum.Alcool);
            txtListaTipoCombustivel.Items.Add(TipoCombustivelEnum.Diesel);
            txtListaTipoCombustivel.Items.Add(TipoCombustivelEnum.Gas);
            txtListaTipoCombustivel.Items.Add(TipoCombustivelEnum.Gasolina);

        }

        public Automovel ObterAutomovel()
        {

            automovel.Ano = Convert.ToDateTime(txtAno.Value);
            automovel.Placa = txtPlaca.Text;
            automovel.Modelo = txtModelo.Text;
            automovel.Marca = txtMarca.Text;
            automovel.Cor = txtCor.Text;
            automovel.CapacidadeLitros = Convert.ToInt32(txtCapacidadeLitros.Text);
            automovel.Quilometragem = Convert.ToInt32(txtQuilometragem.Text);
            automovel.TipoCombustivel = (TipoCombustivelEnum)txtListaTipoCombustivel.SelectedItem;
            automovel.GrupoAutomovel = (GrupoAutomovel)txtListaGrupoAutomovel.SelectedItem;

            byte[] foto = null;
            foto = ConverterImagemEmByteArray(foto);
            automovel.Foto = foto;

            return automovel;
        }

        public void ConfigurarAutomovel(Automovel automovel)
        {

            this.automovel = automovel;
            txtAno.Text = automovel.Ano.ToShortTimeString();
            txtPlaca.Text = automovel.Placa;
            txtModelo.Text = automovel.Modelo;
            txtMarca.Text = automovel.Marca;
            txtCor.Text = automovel.Cor;
            txtCapacidadeLitros.Text = automovel.CapacidadeLitros.ToString();
            txtQuilometragem.Text = automovel.Quilometragem.ToString();
            txtListaTipoCombustivel.SelectedItem = automovel.TipoCombustivel;
            txtListaGrupoAutomovel.SelectedItem = automovel.GrupoAutomovel;

            Image foto = null;
            foto = ConverterByteArrayEmImagem(automovel, foto);
            fotoAutomovel.Image = foto;
        }

        private byte[] ConverterImagemEmByteArray(byte[] foto)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fotoAutomovel.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    foto = ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao converter a imagem em byte array: {ex.Message}");
            }

            return foto;
        }

        private static Image ConverterByteArrayEmImagem(Automovel automovel, Image foto)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(automovel.Foto))
                {
                    foto = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao converter o byte array em imagem: {ex.Message}");
            }

            return foto;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            automovel = ObterAutomovel();

            Result resultado = onGravarRegistro(automovel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Imagem |*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Selecione uma imagem";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoDaImagem = openFileDialog.FileName;

                Image imagem = Image.FromFile(caminhoDaImagem);

                fotoAutomovel.Image = imagem;
            }
        }

        private void txtAno_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}


