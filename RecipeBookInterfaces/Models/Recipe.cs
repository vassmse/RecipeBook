using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeBookInterfaces.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PrepatationTime { get; set; }

        public string Type { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public byte[] Image { get; set; }

        public Recipe()
        {

        }
    }
}
