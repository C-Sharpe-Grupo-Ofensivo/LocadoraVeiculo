using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloTaxaServico
{
    public interface IRepositorioTaxaServico : IRepositorio<TaxaServico>
    {
        TaxaServico SelecionarPorNome(string nome);
        List<TaxaServico> SelecionarTodos();
    }
}
