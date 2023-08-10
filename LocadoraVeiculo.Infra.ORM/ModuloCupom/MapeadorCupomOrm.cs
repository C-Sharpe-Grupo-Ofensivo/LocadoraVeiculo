using LocadoraVeiculo.Dominio.ModuloCupom;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.ModuloCupom
{
    public class MapeadorCupomOrm : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> cupomBuilder)
        {
            cupomBuilder.ToTable("TBCupom");

            cupomBuilder.Property(c => c.Id).IsRequired().ValueGeneratedNever();

            cupomBuilder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();

            cupomBuilder.Property(c => c.Valor).HasColumnType("decimal").IsRequired();

            cupomBuilder.HasOne(c => c.Parceiro).WithMany().IsRequired().HasConstraintName("FK_TBCupom_TBParceiro").OnDelete(DeleteBehavior.NoAction);

            cupomBuilder.Property(c => c.DataValidade).IsRequired();
        }
    }
}
