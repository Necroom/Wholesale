using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Wholesale_LINQ;

public partial class WholesaleContext : DbContext
{
    public WholesaleContext()
    {
    }

    public WholesaleContext(DbContextOptions<WholesaleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsType> ProductsTypes { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<Release> Releases { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-TA8OEIS\\SQLEXPRESS; Database=Wholesale; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC27E3A18157");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Addres).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC2778A79821");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Middlename).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Position).HasMaxLength(20);
            entity.Property(e => e.StorageId).HasColumnName("StorageID");
            entity.Property(e => e.SurName).HasMaxLength(20);

            entity.HasOne(d => d.Storage).WithMany(p => p.Employees)
                .HasForeignKey(d => d.StorageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Storages");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Manufact__3214EC27AF8431BB");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC2785A1DD46");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Manufacturers");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductsTypes");
        });

        modelBuilder.Entity<ProductsType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC275F07FFEE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(20);
            entity.Property(e => e.Features).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Packing).HasMaxLength(20);
            entity.Property(e => e.StorageConditions).HasMaxLength(20);
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Receipts__3214EC27BE159E60");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.Value).HasMaxLength(10);

            entity.HasOne(d => d.Employee).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receips_Employees");

            entity.HasOne(d => d.Product).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receipts_Products");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receipts_Suppliers");
        });

        modelBuilder.Entity<Release>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Releases__3214EC27DB0685DA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ShippingMethod).HasMaxLength(20);
            entity.Property(e => e.Value).HasMaxLength(10);

            entity.HasOne(d => d.Customer).WithMany(p => p.Releases)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Releases_Customers");

            entity.HasOne(d => d.Employee).WithMany(p => p.Releases)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Releases_Employees");

            entity.HasOne(d => d.Product).WithMany(p => p.Releases)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Releases_Products");
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Storages__3214EC273BA649A5");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC2786BBDC64");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Addres).HasMaxLength(20);
            entity.Property(e => e.Features).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
