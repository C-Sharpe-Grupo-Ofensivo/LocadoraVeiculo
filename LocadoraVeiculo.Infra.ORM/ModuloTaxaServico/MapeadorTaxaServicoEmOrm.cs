using LocadoraVeiculo.Dominio.ModuloTaxaServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.ModuloTaxaServico
{
    public class MapeadorTaxaServicoEmOrm : IEntityTypeConfiguration<TaxaServico>
    {
        public void Configure(EntityTypeBuilder<TaxaServico> taxaServicoBuilder)
        {
            taxaServicoBuilder.ToTable("TBTaxaServico");

            taxaServicoBuilder.Property(t => t.Id).IsRequired().ValueGeneratedNever();

            taxaServicoBuilder.Property(t => t.Nome).HasColumnType("varchar(100)").IsRequired();

            taxaServicoBuilder.Property(t => t.Preco).HasColumnType("decimal").IsRequired();

            taxaServicoBuilder.Property(t => t.TipoPlano).HasConversion<int>().IsRequired();
        }
    }
}