using FluentResults;
using LocadoraVeiculo.Aplicacao.ModuloAutomovel;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.ModuloAutomovel
{
    public class ControladorAutomovel : ControladorBase
    {

        private IRepositorioAutomovel repositorioAutomovel;
        private TabelaAutomovelControl tabelaAutomovel;
        private ServicoAutomovel servicoAutomovel;
        private IRepositorioGrupoAutomovel repositorioGrupoAutomovel;

        public ControladorAutomovel(IRepositorioAutomovel repositorioAutomovel, ServicoAutomovel servicoAutomovel, IRepositorioGrupoAutomovel repositorioGrupoAutomovel)
        {
            this.repositorioAutomovel = repositorioAutomovel;
            this.servicoAutomovel = servicoAutomovel;
            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
        }

        public override void Inserir()
        {
            TelaAutomovelForm tela = new TelaAutomovelForm(repositorioGrupoAutomovel);

            tela.onGravarRegistro += servicoAutomovel.Inserir;

            tela.ConfigurarAutomovel(new Automovel());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAutomoveis();
            }
        }

        public override void Filtrar()
        {
            TelaFiltroAutomovelForm tela = new(repositorioGrupoAutomovel);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                List<Automovel> automoveis = repositorioAutomovel.SelecionarPorGrupo(tela.grupoAutomovel);

                CarregarAutomoveis(automoveis);

            }
            else if (resultado == DialogResult.Abort)
            {
                CarregarAutomoveis();
            }
        }

        public override void Editar()
        {
            int id = tabelaAutomovel.ObtemIdSelecionado();

            Automovel automovelSelecionado = repositorioAutomovel.SelecionarPorId(id);

            if (automovelSelecionado == null)
            {
                MessageBox.Show("Selecione um automóvel primeiro",
                "Edição de Automóveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaAutomovelForm tela = new(repositorioGrupoAutomovel);

            tela.onGravarRegistro += servicoAutomovel.Editar;

            tela.ConfigurarAutomovel(automovelSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAutomoveis();
            }
        }

        public override void Excluir()
        {
            int id = tabelaAutomovel.ObtemIdSelecionado();

            Automovel automovelSelecionado = repositorioAutomovel.SelecionarPorId(id);

            if (automovelSelecionado == null)
            {
                MessageBox.Show("Selecione um automóvel primeiro",
                "Exclusão de Automóveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o automóvel?",
               "Exclusão de Automóveis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoAutomovel.Excluir(automovelSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Automóveis",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                CarregarAutomoveis();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfigurarToolBoxAutomovel();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaAutomovel == null)
                tabelaAutomovel = new TabelaAutomovelControl();

            CarregarAutomoveis();

            return tabelaAutomovel;
        }

        private void CarregarAutomoveis()
        {
            List<Automovel> automoveis = repositorioAutomovel.SelecionarTodos();

            tabelaAutomovel.AtualizarRegistros(automoveis);

            mensagemRodape = string.Format($"Visualizando {automoveis.Count} automóve{0}", automoveis.Count == 1 ? "l" : "is");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

        private void CarregarAutomoveis(List<Automovel> automoveis)
        {
            tabelaAutomovel.AtualizarRegistros(automoveis);

            mensagemRodape = string.Format($"Visualizando {automoveis.Count} automóve{0}", automoveis.Count == 1 ? "l" : "is");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
