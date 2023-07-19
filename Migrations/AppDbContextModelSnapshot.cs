﻿// <auto-generated />
using System;
using MSSQLStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MSSQLStoreAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MSSQLStoreAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CatagoryId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CatagoryName")
                        .IsRequired()
                        .HasColumnType("varchar(64)")
                        .HasColumnName("CatagoryName")
                        .HasColumnOrder(1);

                    b.Property<int>("CategoryStatus")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("Catogories", "dbo");
                });

            modelBuilder.Entity("MSSQLStoreAPI.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProductID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CatagoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(5);

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(6);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnOrder(1);

                    b.Property<string>("ProductPicture")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnOrder(4);

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnOrder(2);

                    b.Property<int>("UnitStock")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("CatagoryId");

                    b.ToTable("Products", "dbo", t =>
                        {
                            t.HasComment("ตารางเก็บข้อมูลสินค้า");
                        });
                });

            modelBuilder.Entity("MSSQLStoreAPI.Models.Products", b =>
                {
                    b.HasOne("MSSQLStoreAPI.Models.Category", "CatagoryInfo")
                        .WithMany()
                        .HasForeignKey("CatagoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatagoryInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
