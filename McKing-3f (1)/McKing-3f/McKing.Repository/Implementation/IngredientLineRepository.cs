using McKing.Model;
using McKing.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McKing.Repository.Implementation
{
    public class IngredientLineRepository : IIngredientLineRepository
    {
        private readonly string tableName = "recipe_ingredients";

        public IngredientLine Create(IngredientLine ingredientLine)
        {
            string sql = $"INSERT INTO {tableName} (id_recipe, id_ingredient, quantity, id_measure) VALUES ({ingredientLine.Recipe.Id}, {ingredientLine.Ingredient.Id}, {ingredientLine.Quantity}, {ingredientLine.Measure.Id});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public void DeleteAllByRecipeId(int recipeId)
        {
            string sql = $"DELETE FROM {tableName} WHERE id_recipe = {recipeId};";
            SQL.ExecuteNonQuery(sql);
        }

        public IngredientLine Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("IngredientLine not found.");
        }

        public List<IngredientLine> RetrieveAllByRecipeId(int recipeId)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id_recipe = {recipeId};";
            SqlDataReader reader = SQL.Execute(sql);
            List<IngredientLine> ingredients = new List<IngredientLine>();
            while (reader.Read())
            {
                ingredients.Add(Parse(reader));
            }
            return ingredients;
        }
        private IngredientLine Parse(SqlDataReader reader)
        {
            IngredientLine ingredientLine = new IngredientLine();
            ingredientLine.Id = Convert.ToInt32(reader["id"]);

            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(reader["id_ingredient"]);
            ingredientLine.Ingredient = ingredient;

            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id_recipe"]);
            ingredientLine.Recipe = recipe;

            ingredientLine.Quantity = Convert.ToInt64(reader["quantity"]);

            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(reader["id_measure"]);
            ingredientLine.Measure = measure;

            return ingredientLine;
        }

    }
}
