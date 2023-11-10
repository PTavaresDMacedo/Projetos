using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repository
{
    internal class MSSQL
    {
        private static readonly string _connectionString = @"Server=db.assembly.pt;Database=JD_YV_PT_Tastebook;Trusted_Connection=True;User Id=Students;Password=SkillUpForTomorrow;Integrated Security=False; TrustServerCertificate=True;";
        private static readonly SqlConnection _sqlConnection = new SqlConnection(_connectionString);
        private static bool _isClosed = false;

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
            string sql = $"SELECT MAX({columnName}) as MAX_VAL FROM {tableName};";
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
