using LocadoraVeiculo.Dominio.ModuloAluguel;
using LocadoraVeiculo.Dominio.ModuloAutomovel;
using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloCupom;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using LocadoraVeiculo.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.ModuloAluguel
{
    public class MapeadorAluguelOrm : IEntityTypeConfiguration<Aluguel>
    {
        //public Funcionario Funcionario { get; set; }
        //public Cliente Cliente { get; set; }
        //public GrupoAutomovel GrupoAutomovel { get; set; }
        //public PlanoCobranca PlanoCobranca { get; set; }
        ////public Condutor Condutor { get; set; }
        //public Automovel Automovel { get; set; }
        //public decimal KmAutomovel { get; set; } x
        //public DateTime DataLocacao { get; set; } x
        //public DateTime DevolucaoPrevista { get; set; } x
        //public Cupom Cupom { get; set; }
        //public decimal ValorTotalPrevisto { get; set; } x
        //public List<TaxaServico> TaxaServico { get; set; }
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("TBAluguel");

            builder.Property(d => d.Id).IsRequired().ValueGeneratedNever();

            builder.Property(d => d.DevolucaoPrevista).IsRequired();

            builder.Property(d => d.ValorTotalPrevisto).HasConversion<decimal>().IsRequired();


            builder.Property(d => d.DataLocacao).IsRequired();

            builder.Property(d => d.KmAutomovel).HasConversion<decimal>().IsRequired();


            builder.HasOne(g => g.GrupoAutomovel)
                   .WithMany()
                   .IsRequired()
                   .HasConstraintName("FK_TBAluguel_TBGrupoAutomovel")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(g => g.Funcionario)
                   .WithMany()
                   .IsRequired()
                   .HasConstraintName("FK_TBAluguel_TBFuncionario")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(g => g.Cliente)
                   .WithMany()
                   .IsRequired()
                   .HasConstraintName("FK_TBAluguel_TBCliente")
                   .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(g => g.Condutor)
            //       .WithMany()
            //       .IsRequired()
            //       .HasConstraintName("FK_TBAluguel_TBCondutor")
            //       .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(g => g.Automovel)
                   .WithMany()
                   .IsRequired()
                   .HasConstraintName("FK_TBAluguel_TBAutomovel")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(g => g.Cupom)
                   .WithMany()
                   .IsRequired(false)
                   .HasConstraintName("FK_TBAluguel_TBCupom")
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(g => g.TaxaServico)
                   .WithMany()
                   .UsingEntity(x => x.ToTable("TBAluguel_TBTaxaEServico"));
        }
    }
}
