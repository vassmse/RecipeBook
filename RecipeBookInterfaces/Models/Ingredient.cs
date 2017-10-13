﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeBookInterfaces.Models
{
    public class Ingredient
    {
        public string Name { get; set; }

        public double Quantity { get; set; }

        public IngredientUnit Unit { get; set; }
    }

    public enum IngredientUnit
    {
        kg, g, liter, darab, ek, kk
    }
}
