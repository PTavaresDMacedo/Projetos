using Microsoft.Data.SqlClient;
using Receitas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repository.Favorites
{
    public class FavoriteRepository : IFavoriteRepository
    { 
        private readonly string tableName = "favorites";

        public Favorite Create(Favorite favorite)
        {
            string sql = $"INSERT INTO {tableName} (name) VALUES ('{favorite.Name}');";
            MSSQL.ExecuteNonQuery(sql);
            int id = MSSQL.GetMax(tableName, "id");
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Favorite Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("Favorite not found");
        }

        public List<Favorite> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = MSSQL.Execute(sql);
            List<Favorite> list = new List<Favorite>();
            while (reader.Read())
            {
                list.Add(Parse(reader));
            }
            throw new Exception("Favorite not found");
        }

        public Favorite Update(Favorite favorite)
        {
            string sql = $"UPDATE {tableName} SET name = '{favorite.Name}' WHERE id = {favorite.Id};";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(favorite.Id);
        }

        private Favorite Parse(SqlDataReader reader)
        {
            Favorite favorite = new Favorite();
            favorite.Id = Convert.ToInt32(reader["id"]);
            favorite.Name = Convert.ToString(reader["name"]);
            return favorite;
        }
    }
}
