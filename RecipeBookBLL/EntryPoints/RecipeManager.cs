using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipeBookInterfaces.EntryPoints;
using RecipeBookInterfaces.Models;
using RecipeBookInterfaces.Models.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Microsoft.Data.Sqlite;

namespace RecipeBookBLL.Models
{
    public class RecipeManager : IRecipeManager
    {
        public RecipeManager()
        {
            
        }

        public List<Recipe> GetRecipes()
        {
            var recipes = new List<Recipe>();

            using (SqliteConnection db = new SqliteConnection("Filename=recipeBook.db"))
            {
                db.Open();

                SqliteCommand selectRecipesCommand = new SqliteCommand("SELECT Recipe.id, recipe.name, recipe.description, recipe.PREPARATION, recipetype.id, recipetype.name from Recipe, RecipeType where Recipe.RECIPETYPE_ID = RecipeType.ID", db);

                SqliteDataReader query = selectRecipesCommand.ExecuteReader();

                while (query.Read())
                {
                    //Get ingredients
                    var ingredients = new List<Ingredient>();
                    SqliteCommand selectIngredientsCommand = new SqliteCommand("SELECT ingredients.id, ingredients.quantity, ingredients.unit,RawMaterial.id, RawMaterial.name  from Ingredients, RawMaterial where Ingredients.RECIPE_ID==@id AND ingredients.RAWMATERIAL_ID == rawmaterial.id; ", db);
                    selectIngredientsCommand.Parameters.AddWithValue("@id", query.GetInt32(0));
                    SqliteDataReader inQuery = selectIngredientsCommand.ExecuteReader();

                    while(inQuery.Read())
                    {
                        var material = new RawMaterial { Id = inQuery.GetInt32(3), Name = inQuery.GetString(4) };
                        ingredients.Add(new Ingredient { Id = inQuery.GetInt32(0), Quantity = inQuery.GetInt32(1), Unit = inQuery.GetString(2), Material = material });
                    }

                    var type = new RecipeType { Id = query.GetInt32(4), Name = query.GetString(5) };
                    recipes.Add(new Recipe { Id = query.GetInt32(0), Name = query.GetString(1), Description = query.GetString(2), PreparationTime = query.GetInt32(3), Type = type, Ingredients = ingredients });
                }

                db.Close();
            }

            return recipes;


            //var rawFlour = new RawMaterial { Id = 1, Name = "liszt" };
            //var rawWater = new RawMaterial { Id = 2, Name = "víz" };
            //var rawSalt = new RawMaterial { Id = 3, Name = "só" };
            //var rawPea = new RawMaterial { Id = 4, Name = "borsó" };

            //var flour = new Ingredient { Id = 1, Material = rawFlour, Quantity = 5, Unit = "kg" };
            //var water = new Ingredient { Id = 2, Material = rawWater, Quantity = 2, Unit = "liter" };
            //var salt = new Ingredient { Id = 3, Material = rawSalt, Quantity = 2, Unit = "csipet" };
            //var pea = new Ingredient { Id = 4, Material = rawSalt, Quantity = 1, Unit = "kg" };

            //var lasagnaIngredients = new List<Ingredient>
            //{
            //    flour,
            //    water,
            //    salt
            //};

            //var peaSoupIngredients = new List<Ingredient>
            //{
            //    flour,
            //    water,
            //    salt,
            //    pea
            //};

            //var pizzaIngredients = new List<Ingredient>
            //{
            //    flour,
            //    water
            //};


            //var soup = new RecipeType { Id = 1, Name = "Leves" };
            //var mainCourse = new RecipeType { Id = 2, Name = "Főétel" };

            //AddRecipe(new Recipe { Id = 1, Name = "Borsóleves", Description = "Meg kell főzni a borsólevest. Nagyon finom.", PreparationTime = 30, Ingredients = peaSoupIngredients, Type = soup });

            //return new List<Recipe>()
            //    {
            //        new Recipe {Id=1, Name="Borsóleves", Description="Meg kell főzni a borsólevest. Nagyon finom.", PreparationTime=30, Ingredients=peaSoupIngredients, Type=soup},
            //        new Recipe {Id=2, Name="Hagymaleves", Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis quis hendrerit nulla, vel molestie libero. In nec ultricies magna, ultricies molestie ipsum. Mauris non dignissim velit. Etiam malesuada blandit mauris eu maximus. Quisque ornare, felis nec scelerisque mollis, risus dolor posuere magna, in gravida quam mi id nisi. Nullam mattis consequat ex. Cras nulla neque, dictum ac urna et, vestibulum feugiat ex. Pellentesque malesuada accumsan ligula, vel fringilla lacus facilisis sit amet. Proin convallis tempor arcu, ac placerat libero pretium ut. Praesent hendrerit nisl at lobortis viverra. Fusce vitae velit odio. Nam ut tortor sed purus finibus sollicitudin quis at ante. Ut sodales dolor vel eros mollis suscipit. Donec eu nulla id urna ultricies consequat. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae", PreparationTime=20, Ingredients=lasagnaIngredients, Type=soup},
            //        new Recipe {Id=3, Name="Lasagna", Description="Meg kell sütni. Minnél több, annál jobb.", PreparationTime=140, Ingredients=lasagnaIngredients, Type=mainCourse},
            //        new Recipe {Id=4, Name="Pizza" , Description="Ezt is meg kell sütni", PreparationTime=180, Ingredients=pizzaIngredients, Type=mainCourse},
            //        new Recipe {Id=5, Name="Rakottkrumpli" , Description="Meg kell sütni", PreparationTime=200, Ingredients=peaSoupIngredients, Type=mainCourse}
            //    };
        }



        public List<RecipeType> GetRecipeTypes()
        {
            var recipeTypes = new List<RecipeType>();

            using (SqliteConnection db = new SqliteConnection("Filename=recipeBook.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from RecipeType", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    recipeTypes.Add(new RecipeType { Id = query.GetInt32(0), Name = query.GetString(1) });
                }

                db.Close();
            }

            return recipeTypes;
        }

        public List<RawMaterial> GetRawMaterial()
        {
            var rawMaterials = new List<RawMaterial>();

            using (SqliteConnection db = new SqliteConnection("Filename=recipeBook.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from RawMaterial", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    rawMaterials.Add(new RawMaterial { Id = query.GetInt32(0), Name = query.GetString(1) });
                }

                db.Close();
            }

            return rawMaterials;
        }

        public List<string> GetUnits()
        {
            return new List<string>()
            {
                "kg",
                "liter",
                "ek",
                "darab",
                "dl"
             };
        }

        public void AddRecipe(Recipe recipe)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=recipeBook.db"))
            {
                db.Open();
                
                
                try
                {
                    //Insert recipe
                    SqliteCommand insertRecipe = new SqliteCommand();
                    insertRecipe.Connection = db;

                    insertRecipe.CommandText = "INSERT INTO Recipe VALUES (NULL, @Name, @Description, @PrepTime, @RecipeType, NULL);";
                    insertRecipe.Parameters.AddWithValue("@Name", recipe.Name);
                    insertRecipe.Parameters.AddWithValue("@Description", recipe.Description);
                    insertRecipe.Parameters.AddWithValue("@PrepTime", recipe.PreparationTime);
                    insertRecipe.Parameters.AddWithValue("@RecipeType", recipe.Type.Id);
                    //insertRecipe.Parameters.AddWithValue("@Image", recipe.Image);

                    var a = insertRecipe.ExecuteScalar();

                    //Get ID of the inserted recipe
                    SqliteCommand selectCommand = new SqliteCommand("SELECT ID from Recipe WHERE NAME=@Name", db);
                    selectCommand.Parameters.AddWithValue("@Name", recipe.Name);

                    SqliteDataReader query = selectCommand.ExecuteReader();
                    int recipeId = 0;
                    while (query.Read())
                    {
                        recipeId = query.GetInt32(0);
                    }

                    //Insert ingredients of the recipe
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        SqliteCommand insertIngredients = new SqliteCommand();
                        insertIngredients.Connection = db;

                        insertIngredients.CommandText = "INSERT INTO Ingredients VALUES (NULL, @RawMat, @Quantity, @Unit, @RecipeId);";
                        insertIngredients.Parameters.AddWithValue("@RawMat", ingredient?.Material?.Id??0);
                        insertIngredients.Parameters.AddWithValue("@Quantity", ingredient?.Quantity??0);
                        insertIngredients.Parameters.AddWithValue("@Unit", ingredient?.Unit??"");
                        insertIngredients.Parameters.AddWithValue("@RecipeId", recipeId);

                        insertIngredients.ExecuteReader();
                    }

                    GetRecipes();

                    SqliteCommand delete1 = new SqliteCommand();
                    delete1.Connection = db;
                    delete1.CommandText = "DELETE FROM Recipe;";
                    var tmp = delete1.ExecuteScalar();

                    SqliteCommand delete2 = new SqliteCommand();
                    delete2.Connection = db;
                    delete2.CommandText = "DELETE FROM Ingredients;";
                    var tmp2 = delete2.ExecuteScalar();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                db.Close();
            }

        }

        public void DeleteRecipe(Recipe recipe)
        {

        }

        public void ModifyRecipe(Recipe recipe)
        {

        }

        #region Private DB methods

        private void CreateTables()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=recipeBook.db"))
            {
                db.Open();
                //String recipeTypeTableCommand =
                //    @"CREATE TABLE IF NOT EXISTS RecipeType(
                //    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                //    NAME NVARCHAR(2048) NOT NULL UNIQUE)";

                //String rawMaterialTableCommand =
                //    @"CREATE TABLE IF NOT EXISTS RawMaterial(
                //    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                //    NAME NVARCHAR(2048) NOT NULL UNIQUE)";

                //String recipeTableCommand =
                //    @"CREATE TABLE IF NOT EXISTS Recipe(
                //    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                //    NAME NVARCHAR(2048) NOT NULL UNIQUE,
                //    DESCRIPTION NVARCHAR(2048),
                //    PREPARATION INTEGER,
                //    RECIPETYPE_ID INTEGER,
                //    IMAGE BLOB,
                //    FOREIGN KEY(RECIPETYPE_ID) REFERENCES RecipeType(ID))";

                //String ingredientsTableCommand =
                //    @"CREATE TABLE IF NOT EXISTS Ingredients(
                //    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                //    RAWMATERIAL_ID INTEGER,
                //    QUANTITY REAL,
                //    UNIT NVARCHAR(100),
                //    RECIPE_ID INTEGER,
                //    FOREIGN KEY(RAWMATERIAL_ID) REFERENCES RawMaterial(ID),
                //    FOREIGN KEY(RECIPE_ID) REFERENCES Recipe(ID))";

                //SqliteCommand createTable1 = new SqliteCommand(recipeTypeTableCommand, db);
                //SqliteCommand createTable2 = new SqliteCommand(rawMaterialTableCommand, db);
                //SqliteCommand createTable3 = new SqliteCommand(recipeTableCommand, db);
                //SqliteCommand createTable4 = new SqliteCommand(ingredientsTableCommand, db);

                //createTable1.ExecuteReader();
                //createTable2.ExecuteReader();
                //createTable3.ExecuteReader();
                //createTable4.ExecuteReader();


                //SqliteCommand insertCommand = new SqliteCommand();
                //insertCommand.Connection = db;

                //// Use parameterized query to prevent SQL injection attacks
                //insertCommand.CommandText = "INSERT INTO RawMaterial VALUES (NULL, @Entry);";
                //insertCommand.Parameters.AddWithValue("@Entry", "só");

                //insertCommand.ExecuteReader();


                //SqliteCommand insertCommand2 = new SqliteCommand();
                //insertCommand2.Connection = db;

                //// Use parameterized query to prevent SQL injection attacks
                //insertCommand2.CommandText = "INSERT INTO RawMaterial VALUES (NULL, @Entry);";
                //insertCommand2.Parameters.AddWithValue("@Entry", "borsó");


                //insertCommand2.ExecuteReader();

                db.Close();
            }
        }



        #endregion
    }
}
