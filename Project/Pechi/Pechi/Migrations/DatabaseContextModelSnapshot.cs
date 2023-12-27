﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pechi.Data;

#nullable disable

namespace Pechi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Pechi.Data.DataRow", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("RasD")
                        .HasColumnType("REAL");

                    b.Property<int>("RasH")
                        .HasColumnType("INTEGER");

                    b.Property<float>("RasRas")
                        .HasColumnType("REAL");

                    b.Property<float>("RasTemG")
                        .HasColumnType("REAL");

                    b.Property<float>("RasTemM")
                        .HasColumnType("REAL");

                    b.Property<int>("RasTepl")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RasTg")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RasTm")
                        .HasColumnType("INTEGER");

                    b.Property<float>("RasV")
                        .HasColumnType("REAL");

                    b.Property<int?>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("DataRows");
                });

            modelBuilder.Entity("Pechi.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
