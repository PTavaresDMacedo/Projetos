﻿using McKing.Model;
using McKing.Repository.Interface;
using System.Data.SqlClient;

namespace McKing.Repository.Implementation
{
    public class RecipeRepository : IRepository<Recipe, int>
    {
        private readonly string tableName = "recipes";
        public Recipe Create(Recipe recipe)
        {
            int isApproved = recipe.IsApproved ? 1 : 0;

            string sql = $"INSERT INTO {tableName} (title, id_user, id_category, prep_time, prep_method, id_difficulty, is_approved) VALUES ('{recipe.Title}', {recipe.Author.Id}, {recipe.Category.Id}, {recipe.PrepTime}, '{recipe.PrepMethod}', {recipe.Difficulty.Id}, {isApproved});";
            SQL.ExecuteNonQuery(sql);
            int id = SQL.GetMax("id", tableName);
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            SQL.ExecuteNonQuery(sql);
        }

        public Recipe Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = SQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Recipe not found.");
        }

        public List<Recipe> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = SQL.Execute(sql);
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

            string sql = $"UPDATE {tableName} SET" +
                $" title = '{recipe.Title}'," +
                $" id_category = {recipe.Category.Id}," +
                $" prep_time = {recipe.PrepTime}," +
                $" prep_method = '{recipe.PrepMethod}'," +
                $" id_difficulty = {recipe.Difficulty.Id}," +
                $" is_approved = {isApproved}," +
                $" WHERE id = {recipe.Id}";
            SQL.ExecuteNonQuery(sql);
            return Retrieve(recipe.Id);
        }
        private Recipe Parse(SqlDataReader reader)
        {
            Recipe recipe = new Recipe();
            recipe.Id = Convert.ToInt32(reader["id"]);
            recipe.Title = Convert.ToString(reader["title"]);

            User user = new User();
            user.Id = Convert.ToInt32(reader["id_user"]);
            recipe.Author = user;

            Category category = new Category();
            category.Id = Convert.ToInt32(reader["id_category"]);
            recipe.Category = category;

            recipe.PrepTime = Convert.ToInt32(reader["prep_time"]);
            recipe.PrepMethod = Convert.ToString(reader["prep_method"]);

            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(reader["id_difficulty"]);
            recipe.Difficulty = difficulty;

            recipe.IsApproved = Convert.ToBoolean(reader["is_approved"]);
            return recipe;
        }

    }
}
