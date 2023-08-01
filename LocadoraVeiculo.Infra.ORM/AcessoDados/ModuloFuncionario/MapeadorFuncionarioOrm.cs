using LocadoraVeiculo.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.AcessoDados.ModuloFuncionario
{
    public class MapeadorFuncionarioOrm  : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> funcionarioBuilder)
        {

            funcionarioBuilder.ToTable("TBFuncionario");

            funcionarioBuilder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();

            funcionarioBuilder.Property(f => f.Nome).HasColumnType("varchar(100)").IsRequired();

            funcionarioBuilder.Property(f => f.DataAdmissao).HasColumnType("Date").IsRequired();

            funcionarioBuilder.Property(f => f.Salario).HasColumnType("Decimal").IsRequired();

        }
    }
}
