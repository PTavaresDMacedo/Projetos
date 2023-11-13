using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.App.Repository
{
    internal class MSSQL
    {
        private static readonly string _connectionString = @"Server=db.assembly.pt;Database=PKDX_PedroTavares;Trusted_Connection=True;User Id=Students;Password=SkillUpForTomorrow;Integrated Security=False;";
        private static readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        private static bool _isClosed = true;

        public static SqlDataReader Execute(string sql)
        {
            HangUpCall();
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            return sqlCommand.ExecuteReader();
        }

        public static int ExecuteNonQuery(string sql)
        {
            HangUpCall();
            SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
            return sqlCommand.ExecuteNonQuery();
        }

        public static int GetMax(string tableName, string columnName)
        {
            string sql = $"SELECT MAX ({columnName}) as MAX_VAL FROM {tableName};";
            SqlDataReader dataReader = Execute(sql);
            if (dataReader.Read())
            {
                return Convert.ToInt32(dataReader["MAX_VAL"]);
            }
            return -1;
        }

        private static void HangUpCall()
        {
            if (_isClosed)
            {
                _sqlConnection.Open();
                _isClosed = !_isClosed;
            }
            else
            {
                _sqlConnection.Close();
                _sqlConnection.Open();
            }
        }
    }

}
