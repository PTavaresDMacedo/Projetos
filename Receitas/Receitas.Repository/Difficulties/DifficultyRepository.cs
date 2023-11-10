using Microsoft.Data.SqlClient;
using Receitas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repository.Difficulties
{
    public class DifficultyRepository : IDifficultyRepository
    {
        private readonly string tableName = "difficulties";
        public Difficulty Create(Difficulty difficulty)
        {
            string sql = $"INSERT INTO {tableName} (name) VALUES ('{difficulty.Name}');";
            MSSQL.ExecuteNonQuery(sql);
            int id = MSSQL.GetMax(tableName, "id");
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Difficulty Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Difficulty not found.");
        }

        public List<Difficulty> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = MSSQL.Execute(sql);
            List<Difficulty> difficulties = new List<Difficulty>();
            while (reader.Read())
            {
                difficulties.Add(Parse(reader));
            }
            return difficulties;
        }

        public Difficulty Update(Difficulty difficulty)
        {
            string sql = $"UPDATE {tableName} SET name = '{difficulty.Name}' WHERE id = {difficulty.Id};";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(difficulty.Id);
        }

        private Difficulty Parse(SqlDataReader reader)
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(reader["id"]);
            difficulty.Name = Convert.ToString(reader["name"]);
            return difficulty;
        }
    }
}
