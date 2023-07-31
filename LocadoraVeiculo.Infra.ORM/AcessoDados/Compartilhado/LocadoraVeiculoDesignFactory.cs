using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LocadoraVeiculo.Infra.ORM.AcessoDados.Compartilhado
{
    public class LocadoraVeiculoDesignFactory : IDesignTimeDbContextFactory<LocadoraVeiculoDbContext>
    {
        public LocadoraVeiculoDbContext CreateDbContext(string[] args)
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraVeiculoDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new LocadoraVeiculoDbContext(optionsBuilder.Options);
        }
    }
}
