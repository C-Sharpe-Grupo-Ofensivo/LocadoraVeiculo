using LocadoraVeiculo.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloGrupoAutomovel
{
    public class GrupoAutomovel : EntidadeBase<GrupoAutomovel>
    {

        public string? Nome { get; set; }

        public bool PossuiPlanoDiario { get; set; } = false;
        public bool PossuiPlanoControlador { get; set; } = false;
        public bool PossuiPlanoLivre { get; set; } = false;

        public GrupoAutomovel() { }
        public GrupoAutomovel(string nome)
        {
            Nome = nome;
        }
        public GrupoAutomovel(int id, string nome) : this(nome)
        {
            Id = id;
        }

        public override void Atualizar(GrupoAutomovel registro)
        {
            Nome = registro.Nome;
        }

        public override string ToString()
        {
            return Nome;
        }

        
    }
}
