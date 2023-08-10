using FluentResults;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloAluguel;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloCondutor;
using LocadoraVeiculo.Dominio.ModuloCupom;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LocadoraVeiculo.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        private Aluguel aluguel;
        IRepositorioCupom cupons;

        bool cupomUsado = false;
        public event GravarRegistroDelegate<Aluguel> onGravarRegistro;

        public TelaAluguelForm(List<Cliente> cliente, List<Funcionario> funcionario, List<GrupoAutomovel> grupoAutomovel,
        List<Automovel> automovel, List<PlanoCobranca> planoCobranca, List<Condutor> condutor)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarAutomovel(automovel);
            CarregarCliente(cliente);
            CarregarCondutor(condutor);
            CarregarFuncionario(funcionario);
            CarregarGrupoAutomoveis(grupoAutomovel);
            CarregarPlanoCobranca(planoCobranca);
        }

        public void ConfigurarAluguel(Aluguel aluguel)
        {
            this.aluguel = aluguel;



            cmbKmAutomovel.SelectedItem = aluguel.KmAutomovel.ToString();
            labelValorFinal.Text = aluguel.ValorTotalPrevisto.ToString();
            cmbFuncionario.SelectedItem = aluguel.Funcionario;
            cmbCliente.SelectedItem = aluguel.Cliente;
            cmbGrupoAutomovel.SelectedItem = aluguel.GrupoAutomovel;
            cmbPlanoCobranca.SelectedItem = aluguel.PlanoCobranca;
            cmbCondutor.SelectedItem = aluguel.Condutor;
            cmbAutomovel.SelectedItem = aluguel.Automovel;

            if (aluguel.Cupom != null) txtCupom.Text = aluguel.Cupom.Nome;
            dataDataLocacao.Text = aluguel.DataLocacao.ToShortTimeString();
            dateDataPrevista.Text = aluguel.DevolucaoPrevista.ToShortTimeString();

            //foreach (TaxaServico item in aluguel.TaxaServico)
            //{

            //    chkTaxa.SetItemChecked(chkTaxa.Items.IndexOf(item), true);

            //}
        }

        public Aluguel ObterAluguel()
        {

            aluguel.Funcionario = (Funcionario)cmbFuncionario.SelectedItem;
            aluguel.Cliente = (Cliente)cmbCliente.SelectedItem;
            aluguel.Condutor = (Condutor)cmbCondutor.SelectedItem;
            aluguel.GrupoAutomovel = (GrupoAutomovel)cmbGrupoAutomovel.SelectedItem;
            aluguel.Automovel = (Automovel)cmbAutomovel.SelectedItem;
            aluguel.PlanoCobranca = (PlanoCobranca)cmbPlanoCobranca.SelectedItem;
            aluguel.KmAutomovel = Convert.ToDecimal(cmbKmAutomovel.Text);
            aluguel.DataLocacao = Convert.ToDateTime(dataDataLocacao.Text);
            aluguel.DevolucaoPrevista = Convert.ToDateTime(dateDataPrevista.Text);

            
            //aluguel.NivelCombustivel = (NivelTanqueEnum)cmbNivelTanque.SelectedItem;


            Cupom cupom = cupons.SelecionarPorNome(txtCupom.Text);
            if (cupomUsado) aluguel.Cupom = cupom;

            aluguel.TaxaServico.Clear();
            foreach (TaxaServico item in chkTaxa.CheckedItems)
            {
                aluguel.TaxaServico.Add(item);
            }

            aluguel.ValorTotalPrevisto = CalcularValorTotalPrevisto(aluguel);

            return aluguel;
        }

        private decimal CalcularValorTotalPrevisto(Aluguel a)
        {


            DateTime dataDevolucaoPrevista = a.DevolucaoPrevista.Date;
            DateTime dataLocacao = a.DataLocacao.Date;
            TimeSpan diasPrevistos = dataDevolucaoPrevista - dataLocacao;
            int dias = diasPrevistos.Days;
            decimal valorDiariasPrevistas = dias * a.PlanoCobranca.PrecoDiaria;


            decimal valorCupom = 0;
            if (a.Cupom != null)
                valorCupom = a.Cupom.Valor;


            decimal valorTaxas = 0;
            foreach (var item in a.TaxaServico)
            {
                valorTaxas += item.Preco;
            }


            decimal valorTotalPrevisto = valorDiariasPrevistas + valorTaxas - valorCupom;

            return valorTotalPrevisto;

        }

        private void CarregarAutomovel(List<Automovel> automovels)
        {
            cmbAutomovel.Items.Clear();

            foreach (Automovel automovel in automovels)
            {
                cmbAutomovel.Items.Add(automovels);
            }
        }

        private void CarregarCondutor(List<Condutor> condutors)
        {
            cmbCondutor.Items.Clear();

            foreach (Condutor condutor in condutors)
            {
                cmbCondutor.Items.Add(condutors);
            }
        }

        private void CarregarPlanoCobranca(List<PlanoCobranca> planoCobrancas)
        {
            cmbPlanoCobranca.Items.Clear();

            foreach (PlanoCobranca planoCobranca in planoCobrancas)
            {
                cmbPlanoCobranca.Items.Add(planoCobrancas);
            }
        }

        private void CarregarGrupoAutomoveis(List<GrupoAutomovel> grupoAutomovels)
        {
            cmbGrupoAutomovel.Items.Clear();

            foreach (GrupoAutomovel grupoAutomovel in grupoAutomovels)
            {
                cmbGrupoAutomovel.Items.Add(grupoAutomovels);
            }
        }

        private void CarregarCliente(List<Cliente> clientes)
        {
            cmbCliente.Items.Clear();

            foreach (Cliente cliente in clientes)
            {
                cmbCliente.Items.Add(clientes);
            }
        }

        private void CarregarFuncionario(List<Funcionario> funcionarios)
        {
            cmbCliente.Items.Clear();

            foreach (Funcionario funcionario in funcionarios)
            {
                cmbCliente.Items.Add(funcionarios);
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            aluguel = ObterAluguel();

            Result resultado = onGravarRegistro(aluguel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
