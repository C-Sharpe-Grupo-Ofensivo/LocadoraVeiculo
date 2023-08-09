using FluentResults;
using LocadoraVeiculo.Aplicacao.ModuloTaxaServico;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloTaxaServico
{
    public class ControladorTaxaServico : ControladorBase
    {
        IRepositorioTaxaServico repositorioTaxaServico;
        TabelaTaxaServicoControl tabelaTaxaServico;
        ServicosTaxaServico servicosTaxaServico;

        public ControladorTaxaServico(IRepositorioTaxaServico repositorioTaxaServico, ServicosTaxaServico servicosTaxaServico)
        {
            this.repositorioTaxaServico = repositorioTaxaServico;
            this.servicosTaxaServico = servicosTaxaServico;
        }
        public override void Inserir()
        {
            TelaTaxaServicoForm telaTaxaServico = new TelaTaxaServicoForm();

            telaTaxaServico.GravarRegistro += servicosTaxaServico.Inserir;

            telaTaxaServico.ConfigurarTaxa(new TaxaServico());

            DialogResult resultado = telaTaxaServico.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }
        public override void Editar()
        {
            Guid id = tabelaTaxaServico.ObtemIdSelecionado();

            TaxaServico taxaSelecionada = repositorioTaxaServico.SelecionarPorId(id);

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxa de Serviços", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaTaxaServicoForm telaTaxaServico = new();

            telaTaxaServico.GravarRegistro += servicosTaxaServico.Editar;

            telaTaxaServico.ConfigurarTaxa(taxaSelecionada);

            DialogResult resultado = telaTaxaServico.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }
        public override void Excluir()
        {
            Guid id = tabelaTaxaServico.ObtemIdSelecionado();

            TaxaServico taxaSelecionada = repositorioTaxaServico.SelecionarPorId(id);

            if (taxaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Exclusão de Taxa de Serviços", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir a taxa?",
               "Exclusão de Taxa de Serviços", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicosTaxaServico.Excluir(taxaSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Taxa de Serviços",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                CarregarTaxas();
            }
        }
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolBoxTaxaServico();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTaxaServico == null)
                tabelaTaxaServico = new TabelaTaxaServicoControl();

            CarregarTaxas();

            return tabelaTaxaServico;
        }
        private void CarregarTaxas()
        {
            List<TaxaServico> taxas = repositorioTaxaServico.SelecionarTodos();

            tabelaTaxaServico.AtualizarRegistros(taxas);

            mensagemRodape = string.Format("Visualizando {0} taxa{1}", taxas.Count, taxas.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}