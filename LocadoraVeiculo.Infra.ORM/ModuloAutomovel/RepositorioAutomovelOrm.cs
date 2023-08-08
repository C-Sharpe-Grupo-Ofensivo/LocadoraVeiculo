using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using LocadoraVeiculo.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.ModuloAutomovel
{
    public class RepositorioAutomovelOrm : RepositorioBaseORM<Automovel>, IRepositorioAutomovel
    {
        public RepositorioAutomovelOrm(LocadoraVeiculoDbContext dbContext) : base(dbContext)
        {
        }

        public List<Automovel> SelecionarTodos()
        {
            return registros.Include(x => x.GrupoAutomovel).ToList();
        }

        public Automovel SelecionarPorPlaca(string placa)
        {
            return registros.FirstOrDefault(x => x.Placa == placa);
        }

        public List<Automovel> SelecionarPorGrupo(GrupoAutomovel grupo)
        {
            return registros.Where(x => x.GrupoAutomovel == grupo).ToList();

        }
    }
}
