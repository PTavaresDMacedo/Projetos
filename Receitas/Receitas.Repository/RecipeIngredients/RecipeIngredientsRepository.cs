using Microsoft.Data.SqlClient;
using Receitas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repository.RecipeIngredients
{
    public class RecipeIngredientsRepository : IRecipeIngredientsRepository
    {
        private readonly string tableName = "Recipe_Ingredients";
        public RecipeIngredient Create(RecipeIngredient recipeIngredients)
        {
            string sql = $"INSERT INTO {tableName} (id_recipe, id_ingredient, quantity, id_measure) VALUES" +
                $"({recipeIngredients.Recipe.Id}, {recipeIngredients.Ingredient.Id}, {recipeIngredients.Quantity}, {recipeIngredients.Measure.Id});";
            MSSQL.ExecuteNonQuery(sql);
            int id = MSSQL.GetMax(tableName, "id");
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            MSSQL.ExecuteNonQuery(sql);
        }
        public void DeleteAllByRecipeId(int recipeId)
        {
            string sql = $"DELETE FROM {tableName} WHERE id_recipe = {recipeId};";
            MSSQL.ExecuteNonQuery(sql);
        }

        public RecipeIngredient Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Ingredient line not found.");
        }

        public List<RecipeIngredient> RetrieveAllByRecipeId(int recipeId)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id_recipe = {recipeId};";
            SqlDataReader reader = MSSQL.Execute(sql);
            List<RecipeIngredient> list = new List<RecipeIngredient>();
            while (reader.Read())
            {
                list.Add(Parse(reader));
            }
            return list;
        }

        private RecipeIngredient Parse(SqlDataReader reader)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient();
            recipeIngredient.Id = Convert.ToInt32(reader["id"]);

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id_recipe"]);
            recipeIngredient.Recipe = recipe;

            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(reader["id_ingredient"]);
            recipeIngredient.Ingredient = ingredient;

            recipeIngredient.Quantity = Convert.ToInt64(reader["quantity"]);

            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(reader["id_measure"]);
            recipeIngredient.Measure = measure;

            return recipeIngredient;
        }
    }
}
