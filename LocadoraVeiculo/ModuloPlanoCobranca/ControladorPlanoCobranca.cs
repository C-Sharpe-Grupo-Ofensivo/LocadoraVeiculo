using FluentResults;
using LocadoraVeiculo.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculo.Aplicacao.ModuloTaxaServico;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using LocadoraVeiculo.ModuloTaxaServico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloPlanoCobranca
{
    internal class ControladorPlanoCobranca : ControladorBase
    {
        IRepositorioPlanoCobranca repositorioPlanoCobranca;
        IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        TabelaPlanoCobrancaControl tabelaPlanoCobranca;
        ServicoPlanoCobranca servicoPlanoCobranca;

        public ControladorPlanoCobranca(IRepositorioPlanoCobranca repositorioPlanoCobranca, ServicoPlanoCobranca servicoPlanoCobranca,
            IRepositorioGrupoAutomovel repositorioGrupoAutomovel)
        {
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
            this.servicoPlanoCobranca = servicoPlanoCobranca;
        }
        public override void Inserir()
        {
            TelaPlanoCobrancaForm telaPlanoCobranca = new TelaPlanoCobrancaForm(repositorioGrupoAutomovel);

            telaPlanoCobranca.onGravarRegistro += servicoPlanoCobranca.Inserir;

            telaPlanoCobranca.ConfigurarPlanoCobranca(new PlanoCobranca());

            DialogResult resultado = telaPlanoCobranca.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanoCobranca();
            }
        }
        public override void Editar()
        {
            Guid id = tabelaPlanoCobranca.ObtemIdSelecionado();

            PlanoCobranca planoCobrancaSelecionada = repositorioPlanoCobranca.SelecionarPorId(id);

            if (planoCobrancaSelecionada == null)
            {
                MessageBox.Show("Selecione um plano de cobranca primeiro",
                "Edição de Plano de Cobranca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaPlanoCobrancaForm telaPlanoCobranca = new(repositorioGrupoAutomovel.SelecionarTodos());

            telaPlanoCobranca.onGravarRegistro += servicoPlanoCobranca.Editar;

            telaPlanoCobranca.ConfigurarPlanoCobranca(planoCobrancaSelecionada);

            DialogResult resultado = telaPlanoCobranca.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanoCobranca();
            }
        }
        public override void Excluir()
        {
            Guid id = tabelaPlanoCobranca.ObtemIdSelecionado();

            PlanoCobranca planoCobrancaSelecionada = repositorioPlanoCobranca.SelecionarPorId(id);

            if (planoCobrancaSelecionada == null)
            {
                MessageBox.Show("Selecione um plano de cobrança primeiro",
                "Exclusão de Plano de Cobranca", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o plano de cobranca?",
               "Exclusão de Plano de cobranca", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoPlanoCobranca.Excluir(planoCobrancaSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Plano de Cobranca",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                CarregarPlanoCobranca();
            }
        }
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguraToolBoxPlanoCobranca();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPlanoCobranca == null)
                tabelaPlanoCobranca = new TabelaPlanoCobrancaControl();

            CarregarPlanoCobranca();

            return tabelaPlanoCobranca;
        }
        private void CarregarPlanoCobranca()
        {
            List<PlanoCobranca> planoCobrancas = repositorioPlanoCobranca.SelecionarTodos();

            tabelaPlanoCobranca.AtualizarRegistros(planoCobrancas);

            mensagemRodape = string.Format("Visualizando {0} plano cobranca{1}", planoCobrancas.Count, planoCobrancas.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
