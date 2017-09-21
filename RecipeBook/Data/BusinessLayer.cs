using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Data
{   
    public class BusinessLayer
    {
        public static String Name = "Fake Data Service.";

        public static List<Recipe> GetRecipes()
        {
            Debug.WriteLine("GET for people.");
            return new List<Recipe>()
                {
                    new Recipe() { Name="Borsóleves"},
                    new Recipe() { Name="Lasagna"},
                    new Recipe() { Name="Pizza" }
                };
        }

        public static void Write(Recipe person)
        {
            Debug.WriteLine("INSERT person with name " + person.Name);
        }

        public static void Delete(Recipe person)
        {
            Debug.WriteLine("DELETE person with name " + person.Name);
        }
    }
}
