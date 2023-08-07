using FluentResults;
using LocadoraVeiculo.Aplicacao.ModuloCliente;
using LocadoraVeiculo.Aplicacao.ModuloFuncionario;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using LocadoraVeiculo.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private IRepositorioCliente repositorioCliente;
        private TabelaClienteControl tabelaCliente;
        private ServicoCliente servicoCliente;

        public ControladorCliente(IRepositorioCliente repositorioCliente, ServicoCliente servicoCliente)
        {
            this.repositorioCliente = repositorioCliente;
            this.servicoCliente = servicoCliente;
        }

        public override void Excluir()
        {
            int id = tabelaCliente.ObtemIdSelecionado();

            Cliente clienteSelecionada = repositorioCliente.SelecionarPorId(id);

            if (clienteSelecionada == null)
            {
                MessageBox.Show("Selecione um cliente",
                "Exclusão de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir a cliente?",
               "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoCliente.Excluir(clienteSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Cliente",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarCliente();
            }
        }

        public override void Inserir()
        {
           TelaClienteForm tela = new TelaClienteForm();
            tela.onGravarRegistro += servicoCliente.Inserir;
            tela.ConfigurarCliente(new Cliente());
            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCliente();
            }


        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTooBoxCliente();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCliente == null)
                tabelaCliente = new TabelaClienteControl();

            CarregarCliente();

            return tabelaCliente;
        }

        private void CarregarCliente()
        {
            List<Cliente> cliente = repositorioCliente.SelecionarTodos();

            tabelaCliente.AtualizarRegistros(cliente);

            mensagemRodape = string.Format("Visualizando {0} cliente{1}", cliente.Count, cliente.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

        public override void Editar()
        {
            int id = tabelaCliente.ObtemIdSelecionado();

            Cliente clienteSelecionada = repositorioCliente.SelecionarPorId(id);

            if (clienteSelecionada == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Edição de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaClienteForm tela = new TelaClienteForm();

            tela.onGravarRegistro += servicoCliente.Editar;

            tela.ConfigurarCliente(clienteSelecionada);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCliente();
            }
        }
    }
}
