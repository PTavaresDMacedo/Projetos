using Microsoft.Data.SqlClient;
using Receitas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly string tableName = "users";
        public User Create(User user)
        {
            int isAdmin = user.IsAdmin ? 1 : 0;
            int isBlocked = user.IsBlocked ? 1 : 0;

            string sql = $"INSERT INTO {tableName} (first_name, last_name, email, login, password, is_admin, is_blocked)" +
                $" VALUES ('{user.FirstName}', '{user.LastName}', '{user.Email}', '{user.Login}', CONVERT(VARCHAR(32), HashBytes('MD5','{user.Password}'), 2), '{user.IsAdmin}', '{user.IsBlocked}');";
            MSSQL.ExecuteNonQuery(sql);
            int id = MSSQL.GetMax(tableName, "id");
            return Retrieve(id);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            MSSQL.ExecuteNonQuery(sql);
        }

        public User Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new Exception("User not found.");
        }

        public List<User> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = MSSQL.Execute(sql);
            List<User> users = new List<User>();
            while (reader.Read())
            {
                users.Add(Parse(reader));
            }
            return users;
        }

        public User Update(User user)
        {
            int isAdmin = user.IsAdmin ? 1 : 0;
            int isBlocked = user.IsBlocked ? 1 : 0;

            string sql = $"UPDATE {tableName} SET first_name = '{user.FirstName}', last_name = '{user.LastName}', email = '{user.Email}', login = '{user.Login}', " +
                $"password = CONVERT(VARCHAR(32), HashBytes('MD5','{user.Password}'), 2), is_admin = '{user.IsAdmin}', is_blocked = '{user.IsBlocked}' WHERE id = {user.Id};";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(user.Id);
        }

        private User Parse(SqlDataReader reader)
        {
            User user = new User();
            user.Id = Convert.ToInt32(reader["id"]);
            user.FirstName = Convert.ToString(reader["first_name"]);
            user.LastName = Convert.ToString(reader["last_name"]);
            user.Email = Convert.ToString(reader["email"]);
            user.Login = Convert.ToString(reader["login"]);
            user.Password = Convert.ToString(reader["password"]);
            user.IsAdmin = Convert.ToBoolean(reader["is_admin"]);
            user.IsBlocked = Convert.ToBoolean(reader["is_blocked"]);
            return user;
        }
    }
}
