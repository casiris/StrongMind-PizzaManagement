﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaManagement.Data;

#nullable disable

namespace PizzaManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240209174646_seed1")]
    partial class seed1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzaManagement.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PizzaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Topping1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Topping2Id")
                        .HasColumnType("int");

                    b.Property<int?>("Topping3Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Topping1Id");

                    b.HasIndex("Topping2Id");

                    b.HasIndex("Topping3Id");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("PizzaManagement.Models.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ToppingName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ToppingName = "Pepperoni"
                        },
                        new
                        {
                            Id = 2,
                            ToppingName = "Ham"
                        },
                        new
                        {
                            Id = 3,
                            ToppingName = "Mushroom"
                        },
                        new
                        {
                            Id = 4,
                            ToppingName = "Onion"
                        },
                        new
                        {
                            Id = 5,
                            ToppingName = "Olives"
                        });
                });

            modelBuilder.Entity("PizzaManagement.Models.Pizza", b =>
                {
                    b.HasOne("PizzaManagement.Models.Topping", "Topping1")
                        .WithMany()
                        .HasForeignKey("Topping1Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PizzaManagement.Models.Topping", "Topping2")
                        .WithMany()
                        .HasForeignKey("Topping2Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PizzaManagement.Models.Topping", "Topping3")
                        .WithMany()
                        .HasForeignKey("Topping3Id")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Topping1");

                    b.Navigation("Topping2");

                    b.Navigation("Topping3");
                });
#pragma warning restore 612, 618
        }
    }
}
