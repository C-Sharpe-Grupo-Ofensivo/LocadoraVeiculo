using LocadoraVeiculo.Dominio.ModuloParceiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.AcessoDados.ModuloParceiro
{
    public class MapeadorParceiroOrm : IEntityTypeConfiguration<Parceiro>
    {
        public void Configure(EntityTypeBuilder<Parceiro> parceiroBuilder)
        {
            parceiroBuilder.ToTable("TBParceiro");

            parceiroBuilder.Property(d => d.Id).IsRequired().ValueGeneratedNever();

            parceiroBuilder.Property(d => d.Nome).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
