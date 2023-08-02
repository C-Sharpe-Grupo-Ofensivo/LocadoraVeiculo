using FluentResults;
using LocadoraDeVeiculos.Compartilhado;
using LocadoraVeiculo.Aplicacao.ModuloFuncionario;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloFuncionario
{
        public class ControladorFuncionario : ControladorBase
        {
            private IRepositorioFuncionario repositorioFuncionario;

            private TabelaFuncionarioControl tabelaFuncionario;

            private ServicoFuncionario servicoFuncionario;

            public ControladorFuncionario(
                IRepositorioFuncionario repositorioFuncionario,
                ServicoFuncionario servicoFuncionario)
            {
                this.repositorioFuncionario = repositorioFuncionario;
                this.servicoFuncionario = servicoFuncionario;
            }

            public override void Inserir()
            {
                TelaFuncionarioForm tela = new TelaFuncionarioForm();

                tela.onGravarRegistro += servicoFuncionario.Inserir;

                tela.ConfigurarFuncionario(new Funcionario());

                DialogResult resultado = tela.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    CarregarFuncionario();
                }
            }

            public override void Editar()
            {
                int id = tabelaFuncionario.ObtemIdSelecionado();

                Funcionario funcionarioSelecionada = repositorioFuncionario.SelecionarPorId(id);

                if (funcionarioSelecionada == null)
                {
                    MessageBox.Show("Selecione um funcionario primeiro",
                    "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                TelaFuncionarioForm tela = new TelaFuncionarioForm();

                tela.onGravarRegistro += servicoFuncionario.Editar;

                tela.ConfigurarFuncionario(funcionarioSelecionada);

                DialogResult resultado = tela.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    CarregarFuncionario();
                }
            }

            public override void Excluir()
            {
                int id = tabelaFuncionario.ObtemIdSelecionado();

                Funcionario disciplinaSelecionada = repositorioFuncionario.SelecionarPorId(id);

                if (disciplinaSelecionada == null)
                {
                    MessageBox.Show("Selecione um funcionario",
                    "Exclusão de Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir a funcionario?",
                   "Exclusão de Funcionario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (opcaoEscolhida == DialogResult.OK)
                {
                    Result resultado = servicoFuncionario.Excluir(disciplinaSelecionada);

                    if (resultado.IsFailed)
                    {
                        MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Funcionario",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    CarregarFuncionario();
                }
            }

            public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
            {
                return new ConfiguracaoToolBoxFuncionario();
            }

            public override UserControl ObtemListagem()
            {
                if (tabelaFuncionario == null)
                    tabelaFuncionario = new TabelaFuncionarioControl();

                CarregarFuncionario();

                return tabelaFuncionario;
            }

            private void CarregarFuncionario()
            {
                List<Funcionario> funcionario = repositorioFuncionario.SelecionarTodos();

                tabelaFuncionario.AtualizarRegistros(funcionario);

                mensagemRodape = string.Format("Visualizando {0} funcionario{1}", funcionario.Count, funcionario.Count == 1 ? "" : "s");

                TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
            }
        }
}
