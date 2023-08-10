using FluentResults;
using LocadoraVeiculo.Aplicacao.ModuloAluguel;
using LocadoraVeiculo.Aplicacao.ModuloCliente;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloAluguel;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloConfiguracaoPreco;
using LocadoraVeiculo.Dominio.ModuloCupom;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using LocadoraVeiculo.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        private TabelaAluguelControl tabelaAluguel;
        private IRepositorioAluguel repositorioAluguel;
        private IRepositorioFuncionario repositorioFuncionario;
        private IRepositorioCliente repositorioCliente;
        private IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        private IRepositorioPlanoCobranca repositorioPlanoCobranca;
        private IRepositorioTaxaServico repositorioTaxaServico;
        private IRepositorioCupom repositorioCupom;
        //private IRepositorioCondutor repositorioCondutor;
        private IRepositorioAutomovel repositorioAutomovel;
        private IRepositorioConfiguracaoPreco repositorioConfiguracaoPreco;
        private ServicoAluguel servicoAluguel;

        public ControladorAluguel(TabelaAluguelControl tabelaAluguel, IRepositorioAluguel repositorioAluguel,
            IRepositorioFuncionario repositorioFuncionario, IRepositorioCliente repositorioCliente,
            IRepositorioGrupoAutomovel repositorioGrupoAutomovel, IRepositorioPlanoCobranca repositorioPlanoCobranca,
            IRepositorioTaxaServico repositorioTaxaServico, IRepositorioCupom repositorioCupom,
            IRepositorioAutomovel repositorioAutomovel, IRepositorioConfiguracaoPreco repositorioConfiguracaoPreco,
            ServicoAluguel servicoAluguel)
        {
            this.tabelaAluguel = tabelaAluguel;
            this.repositorioAluguel = repositorioAluguel;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioCliente = repositorioCliente;
            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
            this.repositorioPlanoCobranca = repositorioPlanoCobranca;
            this.repositorioTaxaServico = repositorioTaxaServico;
            this.repositorioCupom = repositorioCupom;
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioConfiguracaoPreco = repositorioConfiguracaoPreco;
            this.servicoAluguel = servicoAluguel;
        }

        public override void Excluir()
        {
            Guid id = tabelaAluguel.ObtemIdSelecionado();

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(id);

            if (aluguelSelecionado == null)
            {
                MessageBox.Show("Selecione um aluguel",
                "Exclusão de Aluguel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir a aluguel?",
               "Exclusão de Aluguel", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoAluguel.Excluir(aluguelSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Aluguel",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarAluguel();
            }
        }

        public override void Inserir()
        {
            TelaAluguelForm tela = new TelaAluguelForm();
            tela.onGravarRegistro += servicoAluguel.Inserir;
            tela.ConfigurarAluguel(new Aluguel());
            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAluguel();
            }


        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxAluguel();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaAluguel == null)
                tabelaAluguel = new TabelaAluguelControl();

            CarregarAluguel();

            return tabelaAluguel;
        }

        private void CarregarAluguel()
        {
            List<Aluguel> aluguels = repositorioAluguel.SelecionarTodos();

            tabelaAluguel.AtualizarRegistros(aluguels);

            mensagemRodape = string.Format("Visualizando {0} aluguel{1}", aluguels.Count, aluguels.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

        public override void Editar()
        {
            Guid id = tabelaAluguel.ObtemIdSelecionado();

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(id);

            if (aluguelSelecionado == null)
            {
                MessageBox.Show("Selecione um aluguel primeiro",
                "Edição de Aluguel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaAluguelForm tela = new TelaAluguelForm();

            tela.onGravarRegistro += servicoAluguel.Editar;

            tela.ConfigurarAluguel(aluguelSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAluguel();
            }
        }
    }
}
