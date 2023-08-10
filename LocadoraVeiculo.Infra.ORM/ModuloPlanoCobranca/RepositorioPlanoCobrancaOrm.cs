using LocadoraVeiculo.Dominio.ModuloParceiro;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculo.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaOrm : RepositorioBaseORM<PlanoCobranca>, IRepositorioPlanoCobranca
    {
        public RepositorioPlanoCobrancaOrm(LocadoraVeiculoDbContext dbContext) : base(dbContext)
        {
        }



        public List<PlanoCobranca> SelecionarTodos(bool incluirGrupoAutomoveis = false)
        {
            if (incluirGrupoAutomoveis)
                return registros.Include(x => x.GrupoAutomovel).ToList();

            return registros.ToList();
        }
    }
}
