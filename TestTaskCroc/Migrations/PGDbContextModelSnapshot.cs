﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestTaskCroc.Models;

namespace TestTaskCroc.Migrations
{
    [DbContext(typeof(PGDbContext))]
    partial class PGDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TestTaskCroc.Models.Cars", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<decimal>("CarCost")
                        .HasColumnType("numeric(18,0)");

                    b.Property<DateTime>("DateOfPurchase")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("DepreciationCoef")
                        .HasColumnType("numeric(3,2)");

                    b.Property<float>("EngineForce")
                        .HasColumnType("real");

                    b.Property<decimal>("EngineVolume")
                        .HasColumnType("numeric(3,2)");

                    b.Property<string>("GovNumber")
                        .HasColumnType("text");

                    b.Property<decimal>("InsuranceCoef")
                        .HasColumnType("numeric(3,2)");

                    b.Property<decimal>("MaintenanceCoef")
                        .HasColumnType("numeric(3,2)");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<int>("TypeOfGearShiftBox")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("cars", "public");
                });

            modelBuilder.Entity("TestTaskCroc.Models.Trips", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CarId")
                        .HasColumnType("integer");

                    b.Property<float>("CostOfSpentFuel")
                        .HasColumnType("real");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("Range")
                        .HasColumnType("real");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("CarId");

                    b.HasIndex("WorkerId");

                    b.ToTable("trips", "public");
                });

            modelBuilder.Entity("TestTaskCroc.Models.Workers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("workers", "public");
                });

            modelBuilder.Entity("TestTaskCroc.Models.Trips", b =>
                {
                    b.HasOne("TestTaskCroc.Models.Cars", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("TestTaskCroc.Models.Workers", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId");

                    b.Navigation("Car");

                    b.Navigation("Worker");
                });
#pragma warning restore 612, 618
        }
    }
}
