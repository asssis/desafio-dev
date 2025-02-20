﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using desafio_dev.Migrations;

namespace desafio_dev.Migrations
{
    [DbContext(typeof(ConectionSQLite))]
    [Migration("20210609221843_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("desafio_dev.Models.Cnab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cartao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TEXT");

                    b.Property<string>("DonoLoja")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeLoja")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TransacaoId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("TransacaoId");

                    b.ToTable("Cnab");
                });

            modelBuilder.Entity("desafio_dev.Models.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Transacao");
                });

            modelBuilder.Entity("desafio_dev.Models.Cnab", b =>
                {
                    b.HasOne("desafio_dev.Models.Transacao", "Transacao")
                        .WithMany()
                        .HasForeignKey("TransacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transacao");
                });
#pragma warning restore 612, 618
        }
    }
}
