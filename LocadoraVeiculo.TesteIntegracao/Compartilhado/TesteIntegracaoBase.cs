using FizzWare.NBuilder;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloCondutor;
using LocadoraVeiculo.Dominio.ModuloCupom;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using LocadoraVeiculo.Infra.ORM.Compartilhado;
using LocadoraVeiculo.Infra.ORM.ModuloAutomovel;
using LocadoraVeiculo.Infra.ORM.ModuloCliente;
using LocadoraVeiculo.Infra.ORM.ModuloCondutor;
using LocadoraVeiculo.Infra.ORM.ModuloCupom;
using LocadoraVeiculo.Infra.ORM.ModuloFuncionario;
using LocadoraVeiculo.Infra.ORM.ModuloGrupoAutomovel;
using LocadoraVeiculo.Infra.ORM.ModuloParceiro;
using LocadoraVeiculo.Infra.ORM.ModuloTaxaServico;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using LocadoraVeiculo.Infra.ORM.ModuloCondutor;
using Microsoft.Extensions.Configuration;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculo.Infra.ORM.ModuloPlanoCobranca;

namespace LocadoraVeiculo.TestesIntegracao.Compartilhado
{
    public class TesteIntegracaoBase
    {
        protected IRepositorioFuncionario repositorioFuncionario;
        protected IRepositorioCliente repositorioCliente;
        protected IRepositorioCondutor repositorioCondutor;
        protected IRepositorioCupom repositorioCupom;
        protected IRepositorioParceiro repositorioParceiro;
        //protected IRepositorioTaxasServicos repositorioTaxasServicos;
        protected IRepositorioPlanoCobranca repositorioPlanoCobranca;
        //protected IRepositorioAluguel repositorioAluguel;
        protected IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        protected IRepositorioAutomovel repositorioAutomovel;

        public TesteIntegracaoBase()
        {
            LimparTabelas();

            string connectionString = ObterConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraVeiculoDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new LocadoraVeiculoDbContext(optionsBuilder.Options);

            repositorioFuncionario = new RepositorioFuncionarioOrm(dbContext);
            repositorioCliente = new RepositorioClienteOrm(dbContext);
            repositorioCondutor = new RepositorioCondutorOrm(dbContext);
            repositorioCupom = new RepositorioCupomOrm(dbContext);
            repositorioParceiro = new RepositorioParceiroOrm(dbContext);
            //repositorioTaxasServicos = new RepositorioTaxasServicosOrm(dbContext);
            repositorioPlanoCobranca = new RepositorioPlanoCobrancaOrm(dbContext);
            //repositorioAluguel = new RepositorioAluguelOrm(dbContext);
            repositorioGrupoAutomovel = new RepositorioGrupoAutomoveisEmOrm(dbContext);
            repositorioAutomovel = new RepositorioAutomovelOrm(dbContext);


            BuilderSetup.SetCreatePersistenceMethod<Funcionario>(repositorioFuncionario.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorioCondutor.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cupom>(repositorioCupom.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Parceiro>(repositorioParceiro.Inserir);
            //BuilderSetup.SetCreatePersistenceMethod<TaxasServicos>(repositorioTaxasServicos.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorioPlanoCobranca.Inserir);
            //BuilderSetup.SetCreatePersistenceMethod<Aluguel>(repositorioAluguel.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>(repositorioGrupoAutomovel.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Automovel>(repositorioAutomovel.Inserir);
        }

        protected static void LimparTabelas()
        {
            string? connectionString = ObterConnectionString();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"
                

                DELETE FROM [DBO].[TBTAXASSERVICOS]

                DELETE FROM [DBO].[TBFUNCIONARIO]

                DELETE FROM [DBO].[TBCOBRANCA]

                DELETE FROM [DBO].[TBAUTOMOVEL]

                DELETE FROM [DBO].[TBGRUPOAUTOMOVEIS]

                DELETE FROM [DBO].[TBCONDUTOR]

                DELETE FROM [DBO].[TBCLIENTE]

                DELETE FROM [DBO].[TBCUPOM]

                DELETE FROM [DBO].[TBPARCEIRO];";

            SqlCommand comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

            sqlConnection.Open();

            comando.ExecuteNonQuery();

            sqlConnection.Close();
        }

        protected static string ObterConnectionString()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");
            return connectionString;
        }
    }
}
