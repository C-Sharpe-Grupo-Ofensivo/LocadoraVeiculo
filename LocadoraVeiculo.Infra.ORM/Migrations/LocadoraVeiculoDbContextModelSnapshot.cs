﻿// <auto-generated />
using System;
using LocadoraVeiculo.Infra.ORM.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocadoraVeiculo.Infra.ORM.Migrations
{
    [DbContext(typeof(LocadoraVeiculoDbContext))]
    partial class LocadoraVeiculoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloAutomovel.Automovel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Ano")
                        .HasColumnType("DateTime");

                    b.Property<int>("CapacidadeLitros")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("GrupoAutomovelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Quilometragem")
                        .HasColumnType("int");

                    b.Property<int>("TipoCombustivel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GrupoAutomovelId");

                    b.ToTable("TBAutomovel", (string)null);
                });

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("CupomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TipoCliente")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CupomId");

                    b.ToTable("TBCliente", (string)null);
                });

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloCupom.Cupom", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ParceiroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("ParceiroId");

                    b.ToTable("TBCupom", (string)null);
                });

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloFuncionario.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("Date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("Decimal");

                    b.HasKey("Id");

                    b.ToTable("TBFuncionario", (string)null);
                });

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloGrupoAutomovel.GrupoAutomovel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBGrupoAutomovel", (string)null);
                });

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloParceiro.Parceiro", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TBParceiro", (string)null);
                });

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloPlanoCobranca.PlanoCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GrupoAutomovelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("KmDisponivel")
                        .HasColumnType("decimal(7,0)");

                    b.Property<decimal>("PrecoDiaria")
                        .HasColumnType("decimal(7,0)");

                    b.Property<decimal>("PrecoKm")
                        .HasColumnType("decimal(7,0)");

                    b.Property<string>("TipoPlano")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoAutomovelId");

                    b.ToTable("TBPlanoCobranca", (string)null);
                });

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloTaxaServico.TaxaServico", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal");

                    b.Property<int>("TipoPlano")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TBTaxaServico", (string)null);
                });

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloAutomovel.Automovel", b =>
                {
                    b.HasOne("LocadoraVeiculo.Dominio.ModuloGrupoAutomovel.GrupoAutomovel", "GrupoAutomovel")
                        .WithMany()
                        .HasForeignKey("GrupoAutomovelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_TBAutomovel_TBGrupoAutomovel");

                    b.Navigation("GrupoAutomovel");
                });

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.HasOne("LocadoraVeiculo.Dominio.ModuloCupom.Cupom", null)
                        .WithMany("ClientesJaUtilizados")
                        .HasForeignKey("CupomId");
                });

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloCupom.Cupom", b =>
                {
                    b.HasOne("LocadoraVeiculo.Dominio.ModuloParceiro.Parceiro", "Parceiro")
                        .WithMany()
                        .HasForeignKey("ParceiroId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_TBCupom_TBParceiro");

                    b.Navigation("Parceiro");
                });

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloCupom.Cupom", b =>
                {
                    b.Navigation("ClientesJaUtilizados");
                });

            modelBuilder.Entity("LocadoraVeiculo.Dominio.ModuloPlanoCobranca.PlanoCobranca", b =>
                {
                    b.HasOne("LocadoraVeiculo.Dominio.ModuloGrupoAutomovel.GrupoAutomovel", "GrupoAutomovel")
                        .WithMany()
                        .HasForeignKey("GrupoAutomovelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_TBPlanoCobranca_TBGrupoAutomovel");

                    b.Navigation("GrupoAutomovel");
                });
#pragma warning restore 612, 618
        }
    }
}
