using Microsoft.Data.SqlClient;
using Receitas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Receitas.Repository.Recipes
{
    public class RecipeRepository : IRecipeRepository

    {
        private readonly string tableName = "recipes";
        public Recipe Create(Recipe recipe)
        {
            int isApproved = recipe.IsApproved ? 1 : 0;
            
            string sql = $"INSERT INTO {tableName} (name, id_user, id_category, prep_time, description, id_difficulty, is_approved) " +
                $"VALUES ('{recipe.Name}', {recipe.Author.Id}, {recipe.Category.Id}, {recipe.PreparationTime}, '{recipe.Description}', {recipe.Difficulty.Id}, {isApproved});";
            MSSQL.ExecuteNonQuery(sql);
            int id = MSSQL.GetMax(tableName, "id");
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Recipe Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id}";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Recipe not found.");
        }

        public Recipe Retrieve(string name)
        {
            string sql = $"SELECT * FROM {tableName} WHERE name = {name};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Recipe not found.");
        }

        public List<Recipe> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = MSSQL.Execute(sql);
            List<Recipe> recipes = new List<Recipe>();
            while (reader.Read())
            {
                recipes.Add(Parse(reader));
            }
            return recipes;
        }

        public Recipe Update(Recipe recipe)
        {
            int isApproved = recipe.IsApproved ? 1 : 0;

            string sql = $"UPDATE {tableName} SET name = '{recipe.Name}', id_user = {recipe.Author.Id}, id_category = {recipe.Category.Id}, prep_time = {recipe.PreparationTime}, description = '{recipe.Description}', " +
                $"id_difficulty = {recipe.Difficulty.Id}, is_approved = {isApproved} WHERE id = {recipe.Id};";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(recipe.Id);
        }

        private Recipe Parse(SqlDataReader reader)
        {
            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id"]);
            recipe.Name = Convert.ToString(reader["name"]);

            User user = new User();
            user.Id = Convert.ToInt32(reader["id_user"]);
            recipe.Author = user;

            Category category = new Category();
            category.Id = Convert.ToInt32(reader["id_category"]);
            recipe.Category = category;

            recipe.PreparationTime = Convert.ToInt32(reader["prep_time"]);
            recipe.Description = Convert.ToString(reader["description"]);

            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(reader["id_difficulty"]);
            recipe.Difficulty = difficulty;

            recipe.IsApproved = Convert.ToBoolean(reader["is_approved"]);
            return recipe;
        }
    }
}
