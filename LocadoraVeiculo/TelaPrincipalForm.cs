using LocadoraVeiculo.Aplicacao.ModuloAutomovel;
using LocadoraVeiculo.Aplicacao.ModuloCliente;
using LocadoraVeiculo.Aplicacao.ModuloFuncionario;
using LocadoraVeiculo.Aplicacao.ModuloGrupoAutomovel;
using LocadoraVeiculo.Aplicacao.ModuloParceiro;
using LocadoraVeiculo.Aplicacao.ModuloTaxaServico;
using LocadoraVeiculo.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using LocadoraVeiculo.Infra.ORM.AcessoDados.ModuloTaxaServico;
using LocadoraVeiculo.Infra.ORM.Compartilhado;
using LocadoraVeiculo.Infra.ORM.ModuloAutomovel;
using LocadoraVeiculo.Infra.ORM.ModuloCliente;
using LocadoraVeiculo.Infra.ORM.ModuloFuncionario;
using LocadoraVeiculo.Infra.ORM.ModuloGrupoAutomovel;
using LocadoraVeiculo.Infra.ORM.ModuloParceiro;
using LocadoraVeiculo.ModuloAutomovel;
using LocadoraVeiculo.ModuloCliente;
using LocadoraVeiculo.ModuloFuncionario;
using LocadoraVeiculo.ModuloGrupoAutomovel;
using LocadoraVeiculo.ModuloParceiro;
using LocadoraVeiculo.ModuloTaxaServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraVeiculo
{
    public partial class TelaPrincipalForm : Form
    {
        private Dictionary<string, ControladorBase> controladores;

        private ControladorBase controlador;
        public TelaPrincipalForm()
        {
            InitializeComponent();
            Instancia = this;
            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;
            ConfigurarDialog();

            controladores = new Dictionary<string, ControladorBase>();

            ConfigurarControladores();

        }

        public void ConfigurarDialog()
        {
            ShowIcon = false;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            MinimizeBox = false;


        }

        private void ConfigurarControladores()
        {
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraVeiculoDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new LocadoraVeiculoDbContext(optionsBuilder.Options);

            var migracoesPendentes = dbContext.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
            {
                dbContext.Database.Migrate();
            }

            IRepositorioFuncionario repositorioFuncionario = new RepositorioFuncionarioOrm(dbContext);
            IRepositorioTaxaServico repositorioTaxaServico = new RepositorioTaxaServicoEmOrm(dbContext);

            ValidadorFuncionario validadorFuncionario = new ValidadorFuncionario();
            ValidadorTaxaServico validadorTaxaServico = new ValidadorTaxaServico();

            ServicoFuncionario servicoFuncionario = new ServicoFuncionario(repositorioFuncionario, validadorFuncionario);
            ServicosTaxaServico servicosTaxaServico = new ServicosTaxaServico(repositorioTaxaServico, validadorTaxaServico);

            controladores.Add("ControladorFuncionario", new ControladorFuncionario(repositorioFuncionario, servicoFuncionario));
            controladores.Add("ControladorTaxaServico", new ControladorTaxaServico(repositorioTaxaServico, servicosTaxaServico));

            IRepositorioParceiro repositorioParceiro = new RepositorioParceiroOrm(dbContext);

            ValidadorParceiro validadorParceiro = new ValidadorParceiro();
            ServicoParceiro servicoParceiro = new ServicoParceiro(repositorioParceiro, validadorParceiro);

            controladores.Add("ControladorParceiro", new ControladorParceiro(repositorioParceiro, servicoParceiro));

            IRepositorioCliente repositorioCliente = new RepositorioClienteOrm(dbContext);

            ValidadorCliente validadorCliente = new ValidadorCliente();
            ServicoCliente servicoCliente = new ServicoCliente(repositorioCliente, validadorCliente);
            controladores.Add("ControladorCliente", new ControladorCliente(repositorioCliente, servicoCliente));

            //IRepositorioTeste repositorioTeste = new RepositorioTesteEmOrm(dbContext);

            //IGeradorArquivo geradorRelatorio = new GeradorTesteEmPdf();

            //ValidadorTeste validadorTeste = new ValidadorTeste();
            //ServicoTeste servicoTeste = new ServicoTeste(repositorioTeste, repositorioQuestao, validadorTeste, geradorRelatorio);

            //controladores.Add("ControladorTeste", new ControladorTeste(repositorioTeste, repositorioDisciplina, servicoTeste));

            IRepositorioGrupoAutomovel repositorioGrupoAutomovel = new RepositorioGrupoAutomovelOrm(dbContext);

            ValidadorGrupoAutomovel validadorGrupoAutomovel = new ValidadorGrupoAutomovel();

            ServicoGrupoAutomovel servicoGrupoAutomovel = new ServicoGrupoAutomovel(repositorioGrupoAutomovel, validadorGrupoAutomovel);

            controladores.Add("ControladorGrupoAutomovel", new ControladorGrupoAutomovel(repositorioGrupoAutomovel, servicoGrupoAutomovel));

            IRepositorioAutomovel repositorioAutomovel = new RepositorioAutomovelOrm(dbContext);

            ValidadorAutomovel validadorAutomovel = new ValidadorAutomovel();

            ServicoAutomovel servicoAutomovel = new ServicoAutomovel(repositorioAutomovel, validadorAutomovel);

            controladores.Add("ControladorAutomovel", new ControladorAutomovel(repositorioAutomovel, servicoAutomovel, repositorioGrupoAutomovel));
        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }
        public void AtualizarRodape()
        {
            string mensagemRodape = controlador.ObterMensagemRodape();

            AtualizarRodape(mensagemRodape);
        }
        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }
        private void veiculoMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorAutomovel"]);
        }
        private void funcionarioMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorFuncionario"]);
        }
        private void condutorMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorCondutor"]);
        }
        private void parceiroMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorParceiro"]);
        }
        private void cupomMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorCupom"]);
        }
        private void taxaDeServicoMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorTaxaServico"]);
        }
        private void planoDeCobrancaMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorPlanoDeCobranca"]);
        }
        private void grupoDeVeiculoMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorGrupoAutomovel"]);
        }
        private void clienteMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorCliente"]);
        }
        private void precoCombustivelMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorPrecoCombustivel"]);
        }
        private void locacaoMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal(controladores["ControladorLocacao"]);
        }
        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }

        private void btnGerarPdf_Click(object sender, EventArgs e)
        {
            controlador.GerarPdf();
        }
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            controlador.Visualizar();
        }
        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
            btnFiltrar.Enabled = configuracao.FiltrarHabilitado;
            btnGerarPdf.Enabled = configuracao.GerarPdfHabilitado;
            btnVisualizar.Enabled = configuracao.VisualizarHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
            btnFiltrar.ToolTipText = configuracao.TooltipFiltrar;
            btnGerarPdf.ToolTipText = configuracao.TooltipGerarPdf;
            btnVisualizar.ToolTipText = configuracao.TooltipVisualizar;
        }

        private void ConfigurarTelaPrincipal(ControladorBase controlador)
        {
            this.controlador = controlador;

            ConfigurarToolbox();

            ConfigurarListagem();

            string mensagemRodape = controlador.ObterMensagemRodape();

            AtualizarRodape(mensagemRodape);
        }
        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }
    }
}