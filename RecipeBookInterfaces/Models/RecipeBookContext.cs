using Microsoft.EntityFrameworkCore;
using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBookInterfaces.Models
{
    public class RecipeBookContext : DbContext
    {
        public RecipeBookContext(DbContextOptions<RecipeBookContext> options) : base(options)
        {

        }

      
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<RawMaterial> RawMateral { get; set; }

        public DbSet<MaterialType> MaterialType { get; set; }

        public DbSet<RecipeType> RecipeType { get; set; }



    }
}