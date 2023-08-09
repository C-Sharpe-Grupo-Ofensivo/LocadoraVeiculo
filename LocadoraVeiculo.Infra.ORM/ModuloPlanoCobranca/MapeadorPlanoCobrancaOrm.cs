using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.ModuloPlanoCobranca
{
    internal class MapeadorPlanoCobrancaOrm : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> planoCobrancaBuilder)
        {
            planoCobrancaBuilder.ToTable("TBPlanoCobranca");

            planoCobrancaBuilder.Property(d => d.Id).IsRequired().ValueGeneratedNever();

            planoCobrancaBuilder.Property(d => d.PrecoKm).HasColumnType("decimal(7,0)").IsRequired();
            planoCobrancaBuilder.Property(d => d.PrecoDiaria).HasColumnType("decimal(7,0)").IsRequired();
            planoCobrancaBuilder.Property(d => d.KmDisponivel).HasColumnType("decimal(7,0)").IsRequired();
            planoCobrancaBuilder.Property(d => d.TipoPlano).HasColumnType("varchar(100)").IsRequired();
            planoCobrancaBuilder.HasOne(d => d.GrupoAutomovel)
               .WithMany()
               .IsRequired()
               .HasConstraintName("FK_TBPlanoCobranca_TBGrupoAutomovel")
               .OnDelete(DeleteBehavior.NoAction);

            


        }
    }
}
