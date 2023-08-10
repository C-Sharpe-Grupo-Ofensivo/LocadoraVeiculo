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
        public string Nome { get; set; }

        public GrupoAutomovel GrupoAutomovel { get; set; }

        public PlanoCobranca TipoPlano { get; set; }

        public decimal PrecoDiaria { get; set; }

        public decimal? PrecoPorKm { get; set; }

        public decimal? KmDisponivel { get; set; }

        public PlanoCobranca()
        {

        }

        public PlanoCobranca(GrupoAutomovel grupoAutomovel, string nome, PlanoCobranca tipoPlano, decimal precoDiaria, decimal precoPorKm)
        {
            GrupoAutomovel = grupoAutomovel;
            Nome = nome;
            TipoPlano = tipoPlano;
            PrecoDiaria = precoDiaria;
            PrecoPorKm = precoPorKm;
        }

        public PlanoCobranca(GrupoAutomovel grupoAutomovel, string nome, PlanoCobranca tipoPlano, decimal precoDiaria, decimal precoPorKm, decimal kmDisponivel)
        {
            GrupoAutomovel = grupoAutomovel;
            Nome = nome;
            TipoPlano = tipoPlano;
            PrecoDiaria = precoDiaria;
            PrecoPorKm = precoPorKm;
            KmDisponivel = kmDisponivel;
        }

        public PlanoCobranca(Guid id, GrupoAutomovel grupoAutomovel, string nome, PlanoCobranca tipoPlano, decimal precoDiaria)
        {
            Id = id;
            GrupoAutomovel = grupoAutomovel;
            Nome = nome;
            TipoPlano = tipoPlano;
            PrecoDiaria = precoDiaria;
        }

        public override void Atualizar(PlanoCobranca registro)
        {
            GrupoAutomovel = registro.GrupoAutomovel;
            TipoPlano = registro.TipoPlano;
            PrecoDiaria = registro.PrecoDiaria;
            PrecoPorKm = registro.PrecoPorKm;
            KmDisponivel = registro.KmDisponivel;
        }

        public override string ToString()
        {
            return Nome;
        }

    }
}
