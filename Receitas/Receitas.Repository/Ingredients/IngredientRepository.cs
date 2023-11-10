using Microsoft.Data.SqlClient;
using Receitas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repository.Ingredients
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly string tableName = "ingredients";
        public Ingredient Create(Ingredient ingredient)
        {
            string sql = $"INSERT INTO {tableName} (name) VALUES ('{ingredient.Name}');";
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMax(tableName,"id");
            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Ingredient Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"Ingredient not found.");
        }

        public Ingredient Retrieve(string name)
        {
            string sql = $"SELECT * FROM {tableName} WHERE name = {name};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"Ingredient not found.");
        }

        public List<Ingredient> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = MSSQL.Execute(sql);
            List<Ingredient> ingredients = new List<Ingredient>();
            while (reader.Read())
            {
                ingredients.Add(Parse(reader));
            }
            return ingredients;
        }

        public Ingredient Update(Ingredient ingredient)
        {
            string sql = $"UPDATE {tableName} SET name = '{ingredient.Name}' WHERE id = {ingredient.Id};";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(ingredient.Id);
        }

        private Ingredient Parse(SqlDataReader reader)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(reader["id"]);
            ingredient.Name = Convert.ToString(reader["name"]);
            return ingredient;
        }
    }
}
