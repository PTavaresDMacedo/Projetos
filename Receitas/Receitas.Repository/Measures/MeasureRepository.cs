using Microsoft.Data.SqlClient;
using Receitas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repository.Measures
{
    public class MeasureRepository : IMeasureRepository
    {
        private readonly string tableName = "measures";
        public Measure Create(Measure measure)
        {
            string sql = $"INSERT INTO {tableName} (measure_type) VALUES ('{measure.MeasureType}');";
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMax(tableName, "id");
            return Retrieve(maxId);
        }

        public void Delete(int id)
        {
            string sql = $"DELETE FROM {tableName} WHERE id = {id};";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Measure Retrieve(int id)
        {
            string sql = $"SELECT * FROM {tableName} WHERE id = {id};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"Measure not found.");
        }

        public Measure Retrieve(string measureType)
        {
            string sql = $"SELECT * FROM {tableName} WHERE measure_type = '{measureType}';";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"Measure not found.");
        }

        public List<Measure> RetrieveAll()
        {
            string sql = $"SELECT * FROM {tableName};";
            SqlDataReader reader = MSSQL.Execute(sql);
            List<Measure> measureList = new List<Measure>();
            while (reader.Read())
            {
                measureList.Add(Parse(reader));
            }
            return measureList;
        }

        public Measure Update(Measure measure)
        {
            string sql = $"UPDATE {tableName} SET measure_type = '{measure.MeasureType}' WHERE id = {measure.Id};";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(measure.Id);
        }

        private Measure Parse(SqlDataReader reader)
        {
            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(reader["id"]);
            measure.MeasureType = Convert.ToString(reader["measure_type"]);
            return measure;
        }
    }
}
