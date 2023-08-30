using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepairWorkshopAdmin.MVVM.Models;

namespace RepairWorkshopAdmin.DB;

public partial class RepairWorkshopContext : DbContext
{
    public RepairWorkshopContext()
    {
    }

    public RepairWorkshopContext(DbContextOptions<RepairWorkshopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Receip> Receips { get; set; }

    public virtual DbSet<TechOwner> TechOwners { get; set; }

    public virtual DbSet<TechType> TechTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.LogTo(App.Log, Microsoft.Extensions.Logging.LogLevel.Error)
                         .UseSqlite($"Data source={Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\RepairWorkshop\\RepairDB.db");
    //.UseSqlServer("Data Source=DESKTOP-FRCEKS8;Initial Catalog=RepairWorkshop;User ID=RepairAdmin;Password=Skeetle3;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False",
    //opt => opt.EnableRetryOnFailure());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee);

            entity.Property(e => e.IdEmployee)
                .HasMaxLength(8)
                .HasColumnName("id_employee");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("fullname");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.Deadline)
                .HasColumnType("date")
                .HasColumnName("deadline");
            entity.Property(e => e.DescriptionByOwner)
                .HasMaxLength(400)
                .HasColumnName("description_by_owner");
            entity.Property(e => e.IdEmployee)
                .HasMaxLength(8)
                .HasColumnName("id_employee");
            entity.Property(e => e.IdOwner).HasColumnName("id_owner");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.MalfunctionDescription)
                .HasMaxLength(400)
                .HasColumnName("malfunction_description");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Employees");

            entity.HasOne(d => d.IdOwnerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdOwner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_TechOwners");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_TechTypes");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.IdPrice);

            entity.Property(e => e.IdPrice).HasColumnName("id_price");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price1)
                .HasColumnType("decimal(10,2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Receip>(entity =>
        {
            entity.HasKey(e => e.IdReceip);

            entity.Property(e => e.IdReceip).HasColumnName("id_receip");
            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.IdPrice).HasColumnName("id_price");

            entity.HasOne(d => d.IdOrderNavigation).WithMany()
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK_Receips_Orders");

            entity.HasOne(d => d.IdPriceNavigation).WithMany()
                .HasForeignKey(d => d.IdPrice)
                .HasConstraintName("FK_Receips_Prices");
        });

        modelBuilder.Entity<TechOwner>(entity =>
        {
            entity.HasKey(e => e.IdOwner);

            entity.Property(e => e.IdOwner).HasColumnName("id_owner");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("fullname");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<TechType>(entity =>
        {
            entity.HasKey(e => e.IdType);

            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("manufacturer");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
