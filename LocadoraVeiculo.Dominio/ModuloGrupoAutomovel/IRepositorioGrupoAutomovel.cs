using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloGrupoAutomovel
{
    public interface IRepositorioGrupoAutomovel : IRepositorio<GrupoAutomovel>
    {
        GrupoAutomovel SelecionarPorNome(string nome);
    }
}
