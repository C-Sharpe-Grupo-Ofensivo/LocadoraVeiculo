using LocadoraVeiculo.Dominio.Compartilhado;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Dominio.ModuloPlanoCobranca
{
    public class PlanoCobranca : EntidadeBase<PlanoCobranca>
    {
        public TìpoPlanoCobrancaEnum TipoPlano { get; set; }
        public GrupoAutomovel GrupoAutomovel { get; set; }
        public decimal PrecoKm { get; set; }
        public decimal PrecoDiaria { get; set; }
        public decimal KmDisponivel { get; set; }

        public PlanoCobranca() 
        {

        }

        public PlanoCobranca(Guid id) : this()
        {
            Id = id;
        }

        public PlanoCobranca(TìpoPlanoCobrancaEnum tipoPlano, GrupoAutomovel grupoAutomovel, decimal precoKm, decimal precoDiaria, decimal kmDisponivel)
        {
            TipoPlano = tipoPlano;
            GrupoAutomovel = grupoAutomovel;
            PrecoKm = precoKm;
            PrecoDiaria = precoDiaria;
            KmDisponivel = kmDisponivel;
        }

        public override void Atualizar(PlanoCobranca registroAtualizado)
        {
            TipoPlano = registroAtualizado.TipoPlano;
            GrupoAutomovel = registroAtualizado.GrupoAutomovel;
            PrecoDiaria = registroAtualizado.PrecoDiaria;
            PrecoKm = registroAtualizado.PrecoKm;
            KmDisponivel = registroAtualizado.KmDisponivel;
        }
      

    }
}
