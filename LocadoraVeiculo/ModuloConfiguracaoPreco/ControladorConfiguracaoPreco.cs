using FluentResults;
using LocadoraVeiculo.Aplicacao.ModuloConfiguracaoPreco;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.ModuloCupom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloConfiguracaoPreco
{
    public class ControladorConfiguracaoPreco : ControladorBase
    {
        private TabelaConfiguracaoPrecoControl tabelaConfiguracaoPreco;
        private ServicoConfiguracaoPreco servicoConfiguracaoPreco;
        private IRepositorioConfiguracaoPreco repositorioConfiguracaoPreco;
        private IRepositorioGrupoAutomovel repositorioGrupoAutomovel;

        public ControladorConfiguracaoPreco(ServicoConfiguracaoPreco servicoConfiguracaoPreco, IRepositorioConfiguracaoPreco repositorioConfiguracaoPreco, IRepositorioGrupoAutomovel repositorioGrupoAutomovel)
        {
            this.servicoConfiguracaoPreco = servicoConfiguracaoPreco;
            this.repositorioConfiguracaoPreco = repositorioConfiguracaoPreco;
            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
        }

        public override void Inserir()
        {
            TelaConfiguracaoPrecoForm tela = new TelaConfiguracaoPrecoForm();

            tela.onGravarRegistro += servicoConfiguracaoPreco.Inserir;

            tela.ConfigurarTela(new ConfiguracaoPreco());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarConfiguracaoPreco();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaConfiguracaoPreco.ObtemIdSelecionado();

            ConfiguracaoPreco configuracaoPrecoSelecionada = repositorioConfiguracaoPreco.SelecionarPorId(id);

            if (configuracaoPrecoSelecionada == null)
            {
                MessageBox.Show("Selecione um preço primeiro",
                "Edição de preço", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaConfiguracaoPrecoForm tela = new TelaConfiguracaoPrecoForm();

            tela.onGravarRegistro += servicoConfiguracaoPreco.Editar;

            tela.ConfigurarTela(configuracaoPrecoSelecionada);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarConfiguracaoPreco();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaConfiguracaoPreco.ObtemIdSelecionado();

            ConfiguracaoPreco configuracaoPreco = repositorioConfiguracaoPreco.SelecionarPorId(id);

            if (configuracaoPreco == null)
            {
                MessageBox.Show("Selecione um preco primeiro",
                "Exclusão de Configuracao de Preços", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o Configuracao de Preços?",
               "Exclusão de Configuracao de Preços", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoConfiguracaoPreco.Excluir(configuracaoPreco);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Configuracao de Preços",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarConfiguracaoPreco();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolBoxConfiguracaoPreco();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaConfiguracaoPreco == null)
                tabelaConfiguracaoPreco = new TabelaConfiguracaoPrecoControl();

            CarregarConfiguracaoPreco();

            return tabelaConfiguracaoPreco;
        }

        private void CarregarConfiguracaoPreco()
        {
            List<ConfiguracaoPreco> configuracaoPreco = repositorioConfiguracaoPreco.SelecionarTodos();

            tabelaConfiguracaoPreco.AtualizarRegistros(configuracaoPreco);

            mensagemRodape = string.Format("Visualizando {0} Plano{1} de cobrança", configuracaoPreco.Count, configuracaoPreco.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
