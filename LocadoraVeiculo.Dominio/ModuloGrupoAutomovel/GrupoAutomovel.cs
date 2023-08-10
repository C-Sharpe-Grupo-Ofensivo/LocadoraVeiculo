using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloGrupoAutomovel
{
    public class GrupoAutomovel : EntidadeBase<GrupoAutomovel>
    {
        public string Nome { get; set; }

        public List<Automovel> listaDeAutomovel { get; set; }

        public List<PlanoCobranca> listaDeCobrancas { get; set; }

        public GrupoAutomovel()
        {

        }

        public GrupoAutomovel(string nome)
        {
            Nome = nome;
            listaDeAutomovel = new List<Automovel>();
            listaDeCobrancas = new List<PlanoCobranca>();
        }

        public GrupoAutomovel(Guid id, string nome) : this(nome)
        {
            this.Id = id;
        }

        public override void Atualizar(GrupoAutomovel registro)
        {
            Nome = registro.Nome;
        }

        public override string ToString()
        {
            return Nome;
        }

        public bool AdicionarAutomovel(Automovel automovel)
        {
            if (listaDeAutomovel.Contains(automovel))
                return false;

            listaDeAutomovel.Add(automovel);

            return true;
        }

        public bool AdicionarCobranca(PlanoCobranca cobranca)
        {
            if (listaDeCobrancas.Contains(cobranca))
                return false;

            listaDeCobrancas.Add(cobranca);

            return true;
        }
    }
}
