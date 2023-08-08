using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using LocadoraVeiculo.Infra.ORM.Compartilhado;

namespace LocadoraVeiculo.Infra.ORM.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm :
        RepositorioBaseORM<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionarioOrm(LocadoraVeiculoDbContext dbContext) : base(dbContext)
        {
        }

        public Funcionario SelecionarPorNome(string nome)
        {

            return registros.FirstOrDefault(x => x.Nome == nome);
        }

      
    }
}
