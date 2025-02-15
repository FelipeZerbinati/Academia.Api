﻿// <auto-generated />
using System;
using Academia.Data.Postgres.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Academia.Data.Postgres.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    [Migration("20250215011333_AcademiaAparelho")]
    partial class AcademiaAparelho
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Academia.Domain.Models.Academia", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AcademiaAparelhoId")
                        .HasColumnType("integer");

                    b.Property<string>("AnoFundacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Removed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.HasIndex("AcademiaAparelhoId");

                    b.ToTable("Academia");
                });

            modelBuilder.Entity("Academia.Domain.Models.AcademiaAparelho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AcademiaId")
                        .HasColumnType("integer");

                    b.Property<int>("AparelhoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AcademiaAparelho");
                });

            modelBuilder.Entity("Academia.Domain.Models.Aparelho", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DescricaoAparelho")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeAparelho")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Removed")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("RemovedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.ToTable("Aparelho");
                });

            modelBuilder.Entity("Academia.Domain.Models.Academia", b =>
                {
                    b.HasOne("Academia.Domain.Models.AcademiaAparelho", "AcademiaAparelho")
                        .WithMany()
                        .HasForeignKey("AcademiaAparelhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademiaAparelho");
                });
#pragma warning restore 612, 618
        }
    }
}
