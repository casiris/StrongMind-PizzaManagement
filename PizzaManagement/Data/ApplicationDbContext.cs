using Microsoft.EntityFrameworkCore;
using PizzaManagement.Models;
using System;

namespace PizzaManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed DB
            modelBuilder.Entity<Topping>().HasData(
                new Topping { Id = 1, ToppingName = "Pepperoni"},
                new Topping { Id = 2, ToppingName = "Ham" },
                new Topping { Id = 3, ToppingName = "Mushroom" },
                new Topping { Id = 4, ToppingName = "Onion" },
                new Topping { Id = 5, ToppingName = "Olives" });

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, PizzaName = "Extra Pepperoni", Topping1Id = 1, Topping2Id = 1, Topping3Id = 1 },
                new Pizza { Id = 2, PizzaName = "Meat Lovers", Topping1Id = 1, Topping2Id = 1, Topping3Id = 2 },
                new Pizza { Id = 3, PizzaName = "Special", Topping1Id = 1, Topping2Id = 3, Topping3Id = 4 },
                new Pizza { Id = 4, PizzaName = "Mushroom", Topping1Id = 3, Topping2Id = 3, Topping3Id = 3 });

            modelBuilder.Entity<Pizza>()
                .HasOne(p => p.Topping1)
                .WithMany()
                .HasForeignKey(p => p.Topping1Id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            modelBuilder.Entity<Pizza>()
                .HasOne(p => p.Topping2)
                .WithMany()
                .HasForeignKey(p => p.Topping2Id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            modelBuilder.Entity<Pizza>()
                .HasOne(p => p.Topping3)
                .WithMany()
                .HasForeignKey(p => p.Topping3Id)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
        }
    }
}
