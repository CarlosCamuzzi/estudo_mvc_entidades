﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using app_calculadora.Models;

namespace app_calculadora.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220506233355_V01")]
    partial class V01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("app_calculadora.Models.Soma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumeroDois")
                        .HasColumnType("int");

                    b.Property<int>("NumeroUm")
                        .HasColumnType("int");

                    b.Property<int>("Resultado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Somas");
                });
#pragma warning restore 612, 618
        }
    }
}
