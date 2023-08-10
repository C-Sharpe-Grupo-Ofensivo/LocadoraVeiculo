using LocadoraVeiculo.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.ModuloCondutor
{
    public class MapeadorCondutorOrm : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("TBCondutor");
            builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();
            builder.Property(x => x.Cnh).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.Cpf).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Validade).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.ClienteCondutor);

            builder.HasOne(x => x.Cliente)
                .WithMany(x => x.Condutores)
                .IsRequired()
                .HasConstraintName("FK_TBCondutor_TBCliente")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
