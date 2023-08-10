using FizzWare.NBuilder;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloCupom;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using LocadoraVeiculo.Infra.ORM.Compartilhado;
using LocadoraVeiculo.Infra.ORM.ModuloAutomovel;
using LocadoraVeiculo.Infra.ORM.ModuloCliente;
using LocadoraVeiculo.Infra.ORM.ModuloCupom;
using LocadoraVeiculo.Infra.ORM.ModuloFuncionario;
using LocadoraVeiculo.Infra.ORM.ModuloGrupoAutomovel;
using LocadoraVeiculo.Infra.ORM.ModuloParceiro;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraVeiculo.TestesIntegracao.Compartilhado
{
    public class TesteIntegracaoBase
    {
        protected IRepositorioCupom repositorioCupom;
        protected IRepositorioCliente repositorioCliente;
        protected IRepositorioParceiro repositorioParceiro;
        protected IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        protected IRepositorioFuncionario repositorioFuncionario;
        protected IRepositorioAutomovel repositorioAutomovel;
        //protected IRepositorioPlanoCobranca repositorioPlanoCobranca;


        public TesteIntegracaoBase()
        {

            LimparTabelas();

            string connectionString = ObterConnectionString();
            var optionsBuilder = new DbContextOptionsBuilder<LocadoraVeiculoDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new LocadoraVeiculoDbContext(optionsBuilder.Options);
            repositorioParceiro = new RepositorioParceiroOrm(dbContext);
            repositorioCupom = new RepositorioCupomOrm(dbContext);
            repositorioCliente = new RepositorioClienteOrm(dbContext);
            repositorioGrupoAutomovel = new RepositorioGrupoAutomovelOrm(dbContext);
            repositorioFuncionario = new RepositorioFuncionarioOrm(dbContext);


            repositorioAutomovel = new RepositorioAutomovelOrm(dbContext);


            //repositorioPlanoCobranca = new RepositorioPlanoCobrancaOrm(dbContext);



            BuilderSetup.SetCreatePersistenceMethod<Parceiro>(repositorioParceiro.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cupom>(repositorioCupom.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>(repositorioGrupoAutomovel.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Funcionario>(repositorioFuncionario.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Automovel>(repositorioAutomovel.Inserir);

            //BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorioPlanoCobranca.Inserir);

        }

        protected static void LimparTabelas()
        {
            string? connectionString = ObterConnectionString();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"
                DELETE FROM [DBO].[TBPLANOCOBRANCA];
                DELETE FROM [DBO].[TBAUTOMOVEL];
                DELETE FROM [DBO].[TBCLIENTE];
                DELETE FROM [DBO].[TBAUTOMOVEL];
                DELETE FROM [DBO].[TBGRUPOAUTOMOVEL];
                DELETE FROM [DBO].[TBPARCEIRO];
                DELETE FROM [DBO].[TBFUNCIONARIO];
              
                ";

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

            return configuracao.GetConnectionString("SqlServer");

        }
    }
}
