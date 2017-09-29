using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBookInterfaces.Models
{
    public class Recipe
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int PrepatationTime { get; set; }

        public string Type { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public byte[] Image { get; set; }
    }
}
