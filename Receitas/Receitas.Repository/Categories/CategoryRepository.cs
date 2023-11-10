using Microsoft.Data.SqlClient;
using Receitas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repository.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string tableName = "Categories";
        public Category Create(Category category)
        {
            string sql = $"INSERT INTO {tableName} (name) VALUES ('{category.Name}');";
            MSSQL.ExecuteNonQuery(sql);
            int id = MSSQL.GetMax(tableName, "id");
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Category Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Category not found.");
        }

        public List<Category> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = MSSQL.Execute(sql);
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                categories.Add(Parse(reader));
            }
            return categories;
        }

        public Category Update(Category category)
        {
            string sql = $"UPDATE {tableName} SET name = '{category.Name}' WHERE id = {category.Id};";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(category.Id);
        }

        private Category Parse(SqlDataReader reader)
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(reader["id"]);
            category.Name = Convert.ToString(reader["name"]);
            return category;
        }
    }
}
