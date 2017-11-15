using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeBookInterfaces.Models.Tables
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        public RawMaterial Material { get; set; }

        public double Quantity { get; set; }

         public string Unit { get; set; }

        public Ingredient()
        {
            
        }

    }



    public enum IngredientUnit
    {
        kg, g, liter, darab, ek, kk
    }
}
