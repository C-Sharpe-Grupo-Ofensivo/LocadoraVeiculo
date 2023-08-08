using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using LocadoraVeiculo.Infra.ORM.AcessoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.AcessoDados.ModuloTaxaServico
{
    public class RepositorioTaxaServicoEmOrm : RepositorioBaseORM<TaxaServico>, IRepositorioTaxaServico
    {
        public RepositorioTaxaServicoEmOrm(LocadoraVeiculoDbContext dbContext) : base(dbContext)
        {
        }
        public TaxaServico SelecionarPorNome(string nome) => registros.FirstOrDefault(x => x.Nome == nome);
    }
}
