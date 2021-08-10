﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("ClassLibrary.Base", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bases");
                });

            modelBuilder.Entity("ClassLibrary.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("ClassLibrary.MedicalIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PDINId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PDINId");

                    b.ToTable("MedicalIngredients");
                });

            modelBuilder.Entity("ClassLibrary.PDIN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PDINs");
                });

            modelBuilder.Entity("ClassLibrary.MedicalIngredient", b =>
                {
                    b.HasOne("ClassLibrary.PDIN", null)
                        .WithMany("EligibleIngredient")
                        .HasForeignKey("PDINId");
                });

            modelBuilder.Entity("ClassLibrary.PDIN", b =>
                {
                    b.Navigation("EligibleIngredient");
                });
#pragma warning restore 612, 618
        }
    }
}
