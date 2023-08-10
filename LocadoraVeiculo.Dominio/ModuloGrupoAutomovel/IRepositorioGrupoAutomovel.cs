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
        public GrupoAutomovel SelecionarPorNome(string nome);

        public List<GrupoAutomovel> SelecionarTodos(bool incluirAutomovel = false, bool incluirCobrancas = false);
    }
}
