using LocadoraVeiculo.Dominio.ModuloParceiro;
using LocadoraVeiculo.Infra.ORM.AcessoDados.Compartilhado;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.AcessoDados.ModuloParceiro
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
