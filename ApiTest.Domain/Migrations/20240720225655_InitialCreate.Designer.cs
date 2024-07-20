﻿// <auto-generated />
using System;
using ApiTest.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiTest.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240720225655_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("ApiTest.Domain.Data.Models.Configuration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("ApiTest.Domain.Data.Models.Header", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConfigurationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationId");

                    b.ToTable("Headers");
                });

            modelBuilder.Entity("ApiTest.Domain.Data.Models.Parameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ConfigurationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationId");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("ApiTest.Domain.Data.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConfigurationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ConfigurationId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("ApiTest.Domain.Data.Models.Header", b =>
                {
                    b.HasOne("ApiTest.Domain.Data.Models.Configuration", null)
                        .WithMany("Headers")
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiTest.Domain.Data.Models.Parameter", b =>
                {
                    b.HasOne("ApiTest.Domain.Data.Models.Configuration", null)
                        .WithMany("Parameters")
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiTest.Domain.Data.Models.Test", b =>
                {
                    b.HasOne("ApiTest.Domain.Data.Models.Configuration", "Configuration")
                        .WithMany()
                        .HasForeignKey("ConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Configuration");
                });

            modelBuilder.Entity("ApiTest.Domain.Data.Models.Configuration", b =>
                {
                    b.Navigation("Headers");

                    b.Navigation("Parameters");
                });
#pragma warning restore 612, 618
        }
    }
}
