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

        public ControladorParceiro(IRepositorioParceiro repositorioParceiro, ServicoParceiro servicoParceiro)
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
                CarregarParceiros();
            }
        }

        public override void Editar()
        {

            Guid id = tabelaParceiro.ObtemIdSelecionado();

            Parceiro parceiroSelecionada = repositorioParceiro.SelecionarPorId(id);

            if (parceiroSelecionada == null)
            {
                MessageBox.Show("Selecione uma parceiro primeiro",
                "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaParceiroForm tela = new TelaParceiroForm();

            tela.onGravarRegistro += servicoParceiro.Editar;

            tela.ConfigurarParceiro(parceiroSelecionada);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarParceiros();
            }
        }

        public override void Excluir()
        {

            Guid id = tabelaParceiro.ObtemIdSelecionado();

            Parceiro parceiroSelecionada = repositorioParceiro.SelecionarPorId(id);

            if (parceiroSelecionada == null)
            {
                MessageBox.Show("Selecione uma parceiro primeiro",
                "Exclusão de Parceiros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir a parceiro?",
               "Exclusão de Parceiros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoParceiro.Excluir(parceiroSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Parceiros",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarParceiros();
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

            CarregarParceiros();

            return tabelaParceiro;
        }

        private void CarregarParceiros()
        {
            List<Parceiro> parceiros = repositorioParceiro.SelecionarTodos();

            tabelaParceiro.AtualizarRegistros(parceiros);

            mensagemRodape = string.Format("Visualizando {0} parceiro{1}", parceiros.Count, parceiros.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
