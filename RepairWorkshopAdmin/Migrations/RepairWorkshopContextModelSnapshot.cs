﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepairWorkshopAdmin.DB;

#nullable disable

namespace RepairWorkshopAdmin.Migrations
{
    [DbContext(typeof(RepairWorkshopContext))]
    partial class RepairWorkshopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("RepairWorkshopAdmin.MVVM.Models.Employee", b =>
                {
                    b.Property<string>("IdEmployee")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT")
                        .HasColumnName("id_employee");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("address");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("fullname");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT")
                        .HasColumnName("phone");

                    b.HasKey("IdEmployee");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RepairWorkshopAdmin.MVVM.Models.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_order");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("date")
                        .HasColumnName("deadline");

                    b.Property<string>("DescriptionByOwner")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("TEXT")
                        .HasColumnName("description_by_owner");

                    b.Property<string>("IdEmployee")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT")
                        .HasColumnName("id_employee");

                    b.Property<int>("IdOwner")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_owner");

                    b.Property<int>("IdTechType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdType")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_type");

                    b.Property<string>("MalfunctionDescription")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("TEXT")
                        .HasColumnName("malfunction_description");

                    b.HasKey("IdOrder");

                    b.HasIndex("IdEmployee");

                    b.HasIndex("IdOwner");

                    b.HasIndex("IdType");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RepairWorkshopAdmin.MVVM.Models.Price", b =>
                {
                    b.Property<int>("IdPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_price");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<decimal>("Price1")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.HasKey("IdPrice");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("RepairWorkshopAdmin.MVVM.Models.Receip", b =>
                {
                    b.Property<int>("IdReceip")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_receip");

                    b.Property<int?>("IdOrder")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_order");

                    b.Property<int?>("IdPrice")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_price");

                    b.HasKey("IdReceip");

                    b.HasIndex("IdOrder");

                    b.HasIndex("IdPrice");

                    b.ToTable("Receips");
                });

            modelBuilder.Entity("RepairWorkshopAdmin.MVVM.Models.TechOwner", b =>
                {
                    b.Property<int>("IdOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_owner");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("fullname");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT")
                        .HasColumnName("phone");

                    b.HasKey("IdOwner");

                    b.ToTable("TechOwners");
                });

            modelBuilder.Entity("RepairWorkshopAdmin.MVVM.Models.TechType", b =>
                {
                    b.Property<int>("IdType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_type");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT")
                        .HasColumnName("manufacturer")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.HasKey("IdType");

                    b.ToTable("TechTypes");
                });

            modelBuilder.Entity("RepairWorkshopAdmin.MVVM.Models.Order", b =>
                {
                    b.HasOne("RepairWorkshopAdmin.MVVM.Models.Employee", "IdEmployeeNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdEmployee")
                        .IsRequired()
                        .HasConstraintName("FK_Orders_Employees");

                    b.HasOne("RepairWorkshopAdmin.MVVM.Models.TechOwner", "IdOwnerNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdOwner")
                        .IsRequired()
                        .HasConstraintName("FK_Orders_TechOwners");

                    b.HasOne("RepairWorkshopAdmin.MVVM.Models.TechType", "IdTypeNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdType")
                        .IsRequired()
                        .HasConstraintName("FK_Orders_TechTypes");

                    b.Navigation("IdEmployeeNavigation");

                    b.Navigation("IdOwnerNavigation");

                    b.Navigation("IdTypeNavigation");
                });

            modelBuilder.Entity("RepairWorkshopAdmin.MVVM.Models.Receip", b =>
                {
                    b.HasOne("RepairWorkshopAdmin.MVVM.Models.Order", "IdOrderNavigation")
                        .WithMany()
                        .HasForeignKey("IdOrder")
                        .HasConstraintName("FK_Receips_Orders");

                    b.HasOne("RepairWorkshopAdmin.MVVM.Models.Price", "IdPriceNavigation")
                        .WithMany()
                        .HasForeignKey("IdPrice")
                        .HasConstraintName("FK_Receips_Prices");

                    b.Navigation("IdOrderNavigation");

                    b.Navigation("IdPriceNavigation");
                });

            modelBuilder.Entity("RepairWorkshopAdmin.MVVM.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RepairWorkshopAdmin.MVVM.Models.TechOwner", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RepairWorkshopAdmin.MVVM.Models.TechType", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
