using LocadoraVeiculo.Dominio.ModuloCupom;
using LocadoraVeiculo.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.ModuloCupom
{
    public class RepositorioCupomOrm : RepositorioBaseORM<Cupom>, IRepositorioCupom
    {
        public RepositorioCupomOrm(LocadoraVeiculoDbContext dbContext) : base(dbContext)
        {
        }
        public Cupom SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
        public List<Cupom> SelecionarTodos()
        {
            return registros.Include(x => x.Parceiro).ToList();
        }
    }
}
