using LocadoraVeiculo.Dominio.ModuloParceiro;
using LocadoraVeiculo.Infra.ORM.Compartilhado;

namespace LocadoraVeiculo.Infra.ORM.ModuloParceiro
{
    public class RepositorioParceiroOrm : RepositorioBaseORM<Parceiro>, IRepositorioParceiro
    {
        public RepositorioParceiroOrm(LocadoraVeiculoDbContext dbContext) : base(dbContext)
        {
        }

        public Parceiro SelecionarPorNome(string nome)
        {

            return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
