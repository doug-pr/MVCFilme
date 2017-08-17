using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MVCFilme.Models;

namespace MVCFilme.Migrations
{
    [DbContext(typeof(MVCFilmeContext))]
    [Migration("20170817014946_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCFilme.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Genero");

                    b.Property<DateTime>("Lancamento");

                    b.Property<decimal>("Preco");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Filme");
                });
        }
    }
}
