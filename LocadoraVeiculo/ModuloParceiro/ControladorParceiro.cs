using FluentResults;
using LocadoraVeiculo.Aplicacao.ModuloParceiro;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloParceiro
{
    public class ControladorParceiro: ControladorBase
    {
        private IRepositorioParceiro repositorioParceiro;

        private TabelaParceiroControl tabelaParceiro;

        private ServicoParceiro servicoParceiro;

        public ControladorParceiro(
            IRepositorioParceiro repositorioParceiro,
            ServicoParceiro servicoParceiro)
        {
            this.repositorioParceiro = repositorioParceiro;
            this.servicoParceiro = servicoParceiro;
        }

        public override void Inserir()
        {
            TelaParceiroForm tela = new TelaParceiroForm();

            tela.onGravarRegistro += servicoParceiro.Inserir;

            tela.ConfigurarParceiro(new Parceiro());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarParceiro();
            }
        }

        public override void Editar()
        {
            int id = tabelaParceiro.ObtemIdSelecionado();

            Parceiro parceiroSelecionada = repositorioParceiro.SelecionarPorId(id);

            if (parceiroSelecionada == null)
            {
                MessageBox.Show("Selecione um Parceiro primeiro",
                "Edição de Parceiro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaParceiroForm tela = new TelaParceiroForm();

            tela.onGravarRegistro += servicoParceiro.Editar;

            tela.ConfigurarParceiro(parceiroSelecionada);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarParceiro();
            }
        }

        public override void Excluir()
        {
            int id = tabelaParceiro.ObtemIdSelecionado();

            Parceiro parceiroSelecionada = repositorioParceiro.SelecionarPorId(id);

            if (parceiroSelecionada == null)
            {
                MessageBox.Show("Selecione um Parceiro",
                "Exclusão de Parceiro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir a Parceiro?",
               "Exclusão de Parceiro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoParceiro.Excluir(parceiroSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Parceiro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarParceiro();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolBoxParceiro();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaParceiro == null)
                tabelaParceiro = new TabelaParceiroControl();

            CarregarParceiro();

            return tabelaParceiro;
        }

        private void CarregarParceiro()
        {
            List<Parceiro> parceiro = repositorioParceiro.SelecionarTodos();

            tabelaParceiro.AtualizarRegistros(parceiro);

            mensagemRodape = string.Format("Visualizando {0} Parceiro{1}", parceiro.Count, parceiro.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
