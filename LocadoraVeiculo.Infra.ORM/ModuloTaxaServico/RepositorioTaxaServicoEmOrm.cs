using LocadoraVeiculo.Dominio.ModuloTaxaServico;

using LocadoraVeiculo.Infra.ORM.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.ModuloTaxaServico
{
    public class RepositorioTaxaServicoEmOrm : RepositorioBaseORM<TaxaServico>, IRepositorioTaxaServico
    {
        public RepositorioTaxaServicoEmOrm(LocadoraVeiculoDbContext dbContext) : base(dbContext)
        {
        }
        public TaxaServico SelecionarPorNome(string nome) => registros.FirstOrDefault(x => x.Nome == nome);
    }
}
