﻿// <auto-generated />
using Exercize.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Exercize.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220222091342_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Library.Model.ExercizeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Exercizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Bitbucket pipeline should automatically create the MobilePulseClientSecrets AWS secret",
                            IsFinished = false,
                            Title = "Bitbucket pipeline"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Dev",
                            IsFinished = false,
                            Title = "PagerDuty"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Test",
                            IsFinished = false,
                            Title = "PagerDuty pipeline"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Conmplete configuration for Services",
                            IsFinished = false,
                            Title = "Configuration"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
