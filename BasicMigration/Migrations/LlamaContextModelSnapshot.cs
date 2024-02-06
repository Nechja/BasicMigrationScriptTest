﻿// <auto-generated />
using BasicMigration.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BasicMigration.Migrations
{
    [DbContext(typeof(LlamaContext))]
    partial class LlamaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BasicMigration.Models.Hat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Hats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Black",
                            Name = "Top Hat"
                        },
                        new
                        {
                            Id = 2,
                            Color = "Brown",
                            Name = "Cowboy Hat"
                        },
                        new
                        {
                            Id = 3,
                            Color = "Red",
                            Name = "Baseball Cap"
                        });
                });

            modelBuilder.Entity("BasicMigration.Models.Llamas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Llamas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Larry"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Lucy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Leroy"
                        });
                });

            modelBuilder.Entity("HatLlamas", b =>
                {
                    b.Property<int>("HatsId")
                        .HasColumnType("integer");

                    b.Property<int>("LlamasId")
                        .HasColumnType("integer");

                    b.HasKey("HatsId", "LlamasId");

                    b.HasIndex("LlamasId");

                    b.ToTable("HatLlamas");
                });

            modelBuilder.Entity("HatLlamas", b =>
                {
                    b.HasOne("BasicMigration.Models.Hat", null)
                        .WithMany()
                        .HasForeignKey("HatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasicMigration.Models.Llamas", null)
                        .WithMany()
                        .HasForeignKey("LlamasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}