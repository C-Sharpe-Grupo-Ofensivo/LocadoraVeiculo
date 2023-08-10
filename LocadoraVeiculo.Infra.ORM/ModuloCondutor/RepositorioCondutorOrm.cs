
using LocadoraVeiculo.Dominio.ModuloCondutor;
using LocadoraVeiculo.Dominio.ModuloCupom;
using LocadoraVeiculo.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace LocadoraVeiculo.Infra.ORM.ModuloCondutor
{
    public class RepositorioCondutorOrm : RepositorioBaseORM<Condutor>, IRepositorioCondutor
    {
        public RepositorioCondutorOrm(LocadoraVeiculoDbContext dbContext) : base(dbContext)
        {
        }

        public Condutor SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }

        public List<Condutor> SelecionarTodos(bool incluirCliente = false)
        {
            if (incluirCliente)
                return registros.Include(x => x.Cliente).ToList();

            return registros.ToList();
        }
    }
    
}
