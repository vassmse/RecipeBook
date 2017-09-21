﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RecipeBook.Models
{
    public class Recipe
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public byte[] Image { get; set; }

    }
}
