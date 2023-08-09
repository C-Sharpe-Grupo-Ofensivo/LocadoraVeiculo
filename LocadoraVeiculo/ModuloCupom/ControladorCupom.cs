using FluentResults;
using LocadoraVeiculo.Aplicacao.ModuloCupom;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCupom;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloCupom
{
    internal class ControladorCupom : ControladorBase
    {
        private IRepositorioParceiro repositorioParceiro;
        private IRepositorioCupom repositorioCupom;
        private TabelaCupomControl tabelaCupom;
        private ServicoCupom servicoCupom;
        public ControladorCupom(IRepositorioCupom repositorioCupom, ServicoCupom servicoCupom, IRepositorioParceiro repositorioParceiro)
        {
            this.repositorioCupom = repositorioCupom;
            this.servicoCupom = servicoCupom;
            this.repositorioParceiro = repositorioParceiro;
        }

        public override void Excluir()
        {
            Guid id = tabelaCupom.ObtemIdSelecionado();

            Cupom cupomSelecionada = repositorioCupom.SelecionarPorId(id);

            if (cupomSelecionada == null)
            {
                MessageBox.Show("Selecione um cupom primeiro",
                "Exclusão de cupons", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o cupom?",
               "Exclusão de Cupons", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoCupom.Excluir(cupomSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Parceiros",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarCupom();
            }
        }

        private void CarregarCupom()
        {
            List<Cupom> cupom = repositorioCupom.SelecionarTodos();

            tabelaCupom.AtualizarRegistros(cupom);

            mensagemRodape = string.Format("Visualizando {0} cupom{1}", cupom.Count, cupom.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

        public override void Inserir()
        {
            if (VerificarParceiro()) return;

            TelaCupomForm tela = new TelaCupomForm(repositorioParceiro.SelecionarTodos());

            tela.onGravarRegistro += servicoCupom.Inserir;

            tela.ConfigurarCupom(new Cupom());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCupom();
            }

        }


        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolBoxCupom();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCupom == null)
                tabelaCupom = new TabelaCupomControl();

            CarregarCupom();

            return tabelaCupom;

        }
        public override void Editar()
        {
            Guid id = tabelaCupom.ObtemIdSelecionado();

            Cupom cupomSelecionado = repositorioCupom.SelecionarPorId(id);

            if (cupomSelecionado == null)
            {
                MessageBox.Show("Selecione um Cupom primeiro",
                "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCupomForm tela = new TelaCupomForm(repositorioParceiro.SelecionarTodos());

            tela.onGravarRegistro += servicoCupom.Editar;

            tela.ConfigurarCupom(cupomSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCupom();
            }
        }

        private bool VerificarParceiro()
        {
            if (repositorioParceiro.SelecionarTodos().Count() == 0)
            {
                MessageBox.Show($"Nenhum Parceiro cadastrado", "Novo Cupom", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            else return false;
        }
    }
}
