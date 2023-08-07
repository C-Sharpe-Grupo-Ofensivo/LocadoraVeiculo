using LocadoraVeiculo.Dominio.ModuloCliente;
using LocadoraVeiculo.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculo.Infra.ORM.ModuloCliente
{
    public class MapeadorClienteOrm : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> clienteBuilder)
    {

            clienteBuilder.ToTable("TBCliente");

            clienteBuilder.Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            clienteBuilder.Property(c => c.TipoCliente).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Email).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Telefone).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Cpf).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Cnpj).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Estado).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Cidade).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Bairro).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Rua).HasColumnType("varchar(100)").IsRequired();
            clienteBuilder.Property(c => c.Numero).HasColumnType("varchar(100)").IsRequired();

        }
    {

    }
}
