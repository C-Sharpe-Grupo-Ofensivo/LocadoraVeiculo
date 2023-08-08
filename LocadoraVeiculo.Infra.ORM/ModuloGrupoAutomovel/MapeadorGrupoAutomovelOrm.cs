using LocadoraVeiculo.Dominio.ModuloGrupoAutomovel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculo.Infra.ORM.Compartilhado;
using Microsoft.Win32;

namespace LocadoraVeiculo.Infra.ORM.ModuloGrupoAutomovel
{
    public class MapeadorGrupoAutomovelOrm : IEntityTypeConfiguration<GrupoAutomovel>
    {
        

        public void Configure(EntityTypeBuilder<GrupoAutomovel> grupoAutomovelBuilder)
        {

            grupoAutomovelBuilder.ToTable("TBGrupoAutomovel");

            grupoAutomovelBuilder.Property(p => p.Id).IsRequired().ValueGeneratedNever();

            grupoAutomovelBuilder.Property(p => p.Nome).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
