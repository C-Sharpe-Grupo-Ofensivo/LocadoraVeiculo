using LocadoraVeiculo.Dominio.ModuloAluguel;
using LocadoraVeiculo.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.ModuloAluguel
{
    public class RepositorioAluguelOrm : RepositorioBaseORM<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelOrm(LocadoraVeiculoDbContext dbContext) : base(dbContext)
        {
        }

        public new virtual List<Aluguel> SelecionarTodos()
        {
            return 
                registros.Include
                (a => a.PlanoCobranca).Include
                (a => a.GrupoAutomovel).Include
                (a => a.Automovel).Include
                (a => a.Cliente).Include
                (a => a.Cupom).Include
                (a => a.TaxaServico).ToList();
        }
    }
}
