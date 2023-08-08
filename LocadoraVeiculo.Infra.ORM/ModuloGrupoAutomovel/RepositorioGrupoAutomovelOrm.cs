using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculo.Infra.ORM.Compartilhado;
using Microsoft.Win32;

namespace LocadoraVeiculo.Infra.ORM.ModuloGrupoAutomovel
{
    public class RepositorioGrupoAutomovelOrm : RepositorioBaseORM<GrupoAutomovel>, IRepositorioGrupoAutomovel
    {
        public RepositorioGrupoAutomovelOrm(LocadoraVeiculoDbContext dbContext) : base(dbContext)
        {
        }

        public GrupoAutomovel SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
