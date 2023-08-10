using FluentResults;
using LocadoraVeiculo.Aplicacao.ModuloCondutor;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private TabelaCondutorControl tabelaCondutor;
        private ServicoCondutor servicoCondutor;
        private IRepositorioCondutor repositorioCondutor;
        private IRepositorioCliente repositorioCliente;

        public ControladorCondutor(IRepositorioCondutor repositorioCondutor, ServicoCondutor servicoCondutor, IRepositorioCliente repositorioCliente)
        {
            this.servicoCondutor = servicoCondutor;
            this.repositorioCondutor = repositorioCondutor;
            this.repositorioCliente = repositorioCliente;
        }

        public override void Inserir()
        {
            TelaCondutorForm tela = new TelaCondutorForm(repositorioCliente.SelecionarTodos());

            tela.onGravarRegistro += servicoCondutor.Inserir;

            tela.ConfigurarCondutor(new Condutor());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaCondutor.ObtemIdSelecionado();

            Condutor condutorSelecionado = repositorioCondutor.SelecionarPorId(id);

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                "Edição de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCondutorForm tela = new TelaCondutorForm(repositorioCliente.SelecionarTodos());

            tela.onGravarRegistro += servicoCondutor.Editar;

            tela.ConfigurarCondutor(condutorSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutores();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaCondutor.ObtemIdSelecionado();

            Condutor condutorSelecionado = repositorioCondutor.SelecionarPorId(id);

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                "Exclusão de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o Condutor?",
               "Exclusão de Condutores", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoCondutor.Excluir(condutorSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Condutores",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarCondutores();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCondutor();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCondutor == null)
                tabelaCondutor = new TabelaCondutorControl();

            CarregarCondutores();

            return tabelaCondutor;
        }

        private void CarregarCondutores()
        {
            List<Condutor> condutores = repositorioCondutor.SelecionarTodos(incluirCliente: true);

            tabelaCondutor.AtualizarRegistros(condutores);

            mensagemRodape = string.Format("Visualizando {0} Condutor{1} de cobrança", condutores.Count, condutores.Count == 1 ? "" : "es");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
