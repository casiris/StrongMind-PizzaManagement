using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PizzaManagement.Models;

public partial class PizzaManagementContext : DbContext
{
    public PizzaManagementContext()
    {
    }

    public PizzaManagementContext(DbContextOptions<PizzaManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Pizza> Pizzas { get; set; }

    public virtual DbSet<Topping> Toppings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UF6LITD\\MSSQLSERVER01;Database=PizzaManagement;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__Person__536C85E5AA62C585");

            entity.ToTable("Person");

            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AccessLevel)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Pw)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PW");
        });

        modelBuilder.Entity<Pizza>(entity =>
        {
            entity.HasKey(e => e.PizzaName).HasName("PK__Pizza__401E473ED9BB1A8A");

            entity.ToTable("Pizza");

            entity.Property(e => e.PizzaName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Topping1Navigation).WithMany(p => p.PizzaTopping1Navigations)
                .HasForeignKey(d => d.Topping1)
                .HasConstraintName("FK__Pizza__Topping1__3B75D760");

            entity.HasOne(d => d.Topping2Navigation).WithMany(p => p.PizzaTopping2Navigations)
                .HasForeignKey(d => d.Topping2)
                .HasConstraintName("FK__Pizza__Topping2__3C69FB99");

            entity.HasOne(d => d.Topping3Navigation).WithMany(p => p.PizzaTopping3Navigations)
                .HasForeignKey(d => d.Topping3)
                .HasConstraintName("FK__Pizza__Topping3__3D5E1FD2");
        });

        modelBuilder.Entity<Topping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Toppings__3213E83F946C1230");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ToppingName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
