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
    public class RepositorioGrupoAutomoveisEmOrm : RepositorioBaseORM<GrupoAutomovel>, IRepositorioGrupoAutomovel
    {
        public RepositorioGrupoAutomoveisEmOrm(LocadoraVeiculoDbContext dbContext) : base(dbContext)
        {
        }

        public GrupoAutomovel SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }

        public List<GrupoAutomovel> SelecionarTodos(bool incluirAutomoveis = false, bool incluirCobrancas = false)
        {
            if (incluirAutomoveis && incluirCobrancas)
            {
                return registros
                        .Include(x => x.listaDeAutomovel)
                        .Include(x => x.listaDeCobrancas)
                        .ToList();
            }

            else if (incluirAutomoveis)
            {
                return registros
                        .Include(x => x.listaDeAutomovel)
                        .ToList();
            }

            else if (incluirCobrancas)
            {
                return registros
                        .Include(x => x.listaDeCobrancas)
                        .ToList();
            }
            return registros.ToList();
        }
    }
}