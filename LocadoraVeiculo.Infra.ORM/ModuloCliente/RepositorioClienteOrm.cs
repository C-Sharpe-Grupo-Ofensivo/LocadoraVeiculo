using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Infra.ORM.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.ModuloCliente
{
    public class RepositorioClienteOrm : RepositorioBaseORM<Cliente>, IRepositorioCliente
    {
        public RepositorioClienteOrm(LocadoraVeiculoDbContext dbContext) : base(dbContext)
        {
        }

        public Cliente SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
