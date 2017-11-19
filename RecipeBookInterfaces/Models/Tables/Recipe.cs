using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeBookInterfaces.Models.Tables
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PreparationTime { get; set; }
        
        public ObservableCollection<Ingredient> Ingredients { get; set; }

        public RecipeType Type { get; set; }

        public byte[] Image { get; set; }

        public Recipe()
        {
            Ingredients = new ObservableCollection<Ingredient>();
            Ingredients.Add(new Ingredient());
        }
    }
}
