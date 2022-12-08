using FoodWebAPI.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace FoodWebAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions  options): base(options)
        {

        }

        public DbSet<Recipie> Recipies { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //Dont understand anything but makes sure timespan is in minutes
            modelBuilder.Entity<Recipie>().Property(x => x.TimeToCook).HasConversion(
                z => z.TotalMinutes, y => TimeSpan.FromMinutes(y));

            //modelBuilder.Entity<Recipie>()
            //    .Property(x => x.TimeToCook)
            //    .HasConversion(y => y.ToString(),
            //    z=> TimeSpan.Parse(z));


            //Defualt data for recipie table
            modelBuilder.Entity<Recipie>().HasData(
                new Recipie { RecipieId = 1, Name = "Jollof", Method = "Boiling", isVeganFood = false, TimeToCook = new TimeSpan(3,5,20)},
                new Recipie { RecipieId = 2, Name = "Ampesi", Method = "Boiling", isVeganFood = true, TimeToCook = new TimeSpan(0,59,45)}
                );

            //Defualt data for nigredient table
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId=1, Name="Rice", Quantity=2, Unit="grams", RecipieId=1},
                new Ingredient { IngredientId=2, Name="Tomatoes", Quantity=10, Unit="Sachet", RecipieId=1},
                new Ingredient { IngredientId=3, Name="Yam", Quantity=2, Unit="Tuber", RecipieId=2},
                new Ingredient { IngredientId=4, Name="Plantain", Quantity=5, Unit="Sticks", RecipieId=2}
                
                );


           
        }
    }
}
