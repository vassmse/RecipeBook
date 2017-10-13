using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBookInterfaces.Models
{
    public class RecipeContext: DbContext
    {
        public RecipeContext(): base()
        {

        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
