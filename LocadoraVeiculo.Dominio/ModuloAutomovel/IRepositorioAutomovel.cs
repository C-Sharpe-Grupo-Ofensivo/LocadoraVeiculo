using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloAutomovel
{
     public interface IRepositorioAutomovel : IRepositorio<Automovel>
    {
        Automovel SelecionarPorPlaca(string placa);

        List<Automovel> SelecionarPorGrupo(GrupoAutomovel grupo);
    }
}
