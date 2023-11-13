using Pokedex.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pokedex.App.Repository
{
    public class TypeRepository : ITypeRepository
    {
        public Model.Type Retrieve(int Id)
        {
            string sql = $"SELECT * FROM Type WHERE Id = {Id};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"O Tipo {Id} não foi encontrado.");
        }

        public Model.Type Retrieve(string Name)
        {
            string sql = $"SELECT * FROM Type WHERE TypeName = {Name};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"O Tipo {Name} não foi encontrado.");
        }

        public List<Model.Type> RetrieveAll()
        {
            string sql = $"SELECT * FROM Pokemon;";
            SqlDataReader reader = MSSQL.Execute(sql);
            List<Model.Type> types = new List<Model.Type>();
            while (reader.Read())
            {
                types.Add(Parse(reader));
            }
            return types;
        }
        private Model.Type Parse(SqlDataReader reader)
        {
            Model.Type type = new Model.Type();
            type.Id = Convert.ToInt32(reader["Id"]);
            type.TypeName = Convert.ToString(reader["TypeName"]);
            return type;
        }
    }
}
