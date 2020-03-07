﻿// <auto-generated />
using System;
using CompanyCob.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompanyCob.Repository.Migrations
{
    [DbContext(typeof(CobDbContext))]
    [Migration("20200306232858_inicio")]
    partial class inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompanyCob.Domain.Model.Carteira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Comissao")
                        .HasColumnType("money");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<decimal>("PercentualJuros")
                        .HasColumnType("money");

                    b.Property<int>("QtdParcelasMaxima")
                        .HasColumnType("int");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("TipoJuros")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carteira");
                });

            modelBuilder.Entity("CompanyCob.Domain.Model.Devedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cpf")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Devedor");
                });

            modelBuilder.Entity("CompanyCob.Domain.Model.Divida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarteiraId")
                        .HasColumnType("int");

                    b.Property<int>("DevedorId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroDivida")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<decimal>("ValorOriginal")
                        .HasColumnType("money");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CarteiraId");

                    b.HasIndex("DevedorId");

                    b.ToTable("Divida");
                });

            modelBuilder.Entity("CompanyCob.Domain.Model.Divida", b =>
                {
                    b.HasOne("CompanyCob.Domain.Model.Carteira", "Carteira")
                        .WithMany("Dividas")
                        .HasForeignKey("CarteiraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanyCob.Domain.Model.Devedor", "Devedor")
                        .WithMany("Dividas")
                        .HasForeignKey("DevedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}