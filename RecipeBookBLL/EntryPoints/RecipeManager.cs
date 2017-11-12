using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipeBookInterfaces.EntryPoints;
using RecipeBookInterfaces.Models;
using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecipeBookBLL.Models
{
    public class RecipeManager : IRecipeManager
    {
        public RecipeManager()
        {

        }

        public List<Recipe> GetRecipes()
        {
            var rawFlour = new RawMaterial { Id = 1, Name = "liszt" };
            var rawWater = new RawMaterial { Id = 2, Name = "víz" };
            var rawSalt = new RawMaterial { Id = 3, Name = "só" };
            var rawPea = new RawMaterial { Id = 4, Name = "borsó" };

            var flour = new Ingredient { Id = 1, Material = rawFlour, Quantity = 0.5, Unit = "kg" };
            var water = new Ingredient { Id = 2, Material = rawWater, Quantity = 0.2, Unit = "liter" };
            var salt = new Ingredient { Id = 3, Material = rawSalt, Quantity = 2, Unit = "csipet" };
            var pea = new Ingredient { Id = 4, Material = rawSalt, Quantity = 1, Unit = "kg" };

            var lasagnaIngredients = new List<Ingredient>
            {
                flour,
                water,
                salt
            };

            var peaSoupIngredients = new List<Ingredient>
            {
                flour,
                water,
                salt,
                pea
            };

            var soup = new RecipeType { Id = 1, Name = "Leves" };
            var mainCourse = new RecipeType { Id = 2, Name = "Főétel" };
            
            return new List<Recipe>()
                {
                    new Recipe {Id=1, Name="Borsóleves", Description="Meg kell főzni a borsólevest. Nagyon finom.", PreparationTime=30, Ingredients=peaSoupIngredients, Type=soup},
                    new Recipe {Id=2, Name="Hagymaleves", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis quis hendrerit nulla, vel molestie libero. In nec ultricies magna, ultricies molestie ipsum. Mauris non dignissim velit. Etiam malesuada blandit mauris eu maximus. Quisque ornare, felis nec scelerisque mollis, risus dolor posuere magna, in gravida quam mi id nisi. Nullam mattis consequat ex. Cras nulla neque, dictum ac urna et, vestibulum feugiat ex. Pellentesque malesuada accumsan ligula, vel fringilla lacus facilisis sit amet. Proin convallis tempor arcu, ac placerat libero pretium ut. Praesent hendrerit nisl at lobortis viverra. Fusce vitae velit odio. Nam ut tortor sed purus finibus sollicitudin quis at ante. Ut sodales dolor vel eros mollis suscipit. Donec eu nulla id urna ultricies consequat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae", PreparationTime=20, Ingredients=lasagnaIngredients, Type=soup},
                    new Recipe {Id=3, Name="Lasagna", Description="Meg kell sütni. Minnél több, annál jobb.", PreparationTime=140, Ingredients=lasagnaIngredients, Type=mainCourse},
                    new Recipe {Id=4, Name="Pizza" , Description="Meg kell sütni", PreparationTime=180, Ingredients=lasagnaIngredients, Type=mainCourse},
                    new Recipe {Id=5, Name="Rakottkrumpli" , Description="Meg kell sütni", PreparationTime=200, Ingredients=lasagnaIngredients, Type=mainCourse}
                };
        }

        public List<RecipeType> GetRecipeTypes()
        {
            return new List<RecipeType>()
            {
                new RecipeType { Id = 1, Name = "Leves" },
                new RecipeType { Id = 2, Name = "Főétel" },
                new RecipeType { Id = 2, Name = "Desszert" }
             };
        }

        public List<RawMaterial> GetRawMaterial()
        {
            return new List<RawMaterial>()
            {
                new RawMaterial { Id = 1, Name = "liszt" },
                new RawMaterial { Id = 2, Name = "víz" },
                new RawMaterial { Id = 2, Name = "só" },
                new RawMaterial { Id = 2, Name = "borsó" }
             };
        }

        public void AddRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void ModifyRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
