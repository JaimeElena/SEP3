﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uber2.Persistence;

namespace Uber2.Migrations
{
    [DbContext(typeof(UberDBContext))]
    [Migration("20211207154314_UberData4")]
    partial class UberData4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Uber2.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("firstname")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isLogged")
                        .HasColumnType("INTEGER");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("secondname")
                        .HasColumnType("TEXT");

                    b.Property<string>("sex")
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Uber2.Models.Driver", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isFree")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isLogged")
                        .HasColumnType("INTEGER");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Uber2.Models.Location", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("lat")
                        .HasColumnType("REAL");

                    b.Property<double>("lng")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Uber2.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("customerLocationid")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("customerid")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("driverLocationid")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("driverid")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isAccepted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isCompleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("customerLocationid");

                    b.HasIndex("customerid");

                    b.HasIndex("driverLocationid");

                    b.HasIndex("driverid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Uber2.Models.Order", b =>
                {
                    b.HasOne("Uber2.Models.Location", "customerLocation")
                        .WithMany()
                        .HasForeignKey("customerLocationid");

                    b.HasOne("Uber2.Models.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("customerid");

                    b.HasOne("Uber2.Models.Location", "driverLocation")
                        .WithMany()
                        .HasForeignKey("driverLocationid");

                    b.HasOne("Uber2.Models.Driver", "driver")
                        .WithMany()
                        .HasForeignKey("driverid");

                    b.Navigation("customer");

                    b.Navigation("customerLocation");

                    b.Navigation("driver");

                    b.Navigation("driverLocation");
                });
#pragma warning restore 612, 618
        }
    }
}
