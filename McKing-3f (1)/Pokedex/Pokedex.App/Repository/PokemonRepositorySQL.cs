using Pokedex.Model;
using Pokedex.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Pokedex.Model.Type;

namespace Pokedex.App.Repository
{
    internal class PokemonRepositorySQL : IPokemonRepository
    {
        public Pokemon Create(Pokemon pokemon)
        {
            string sql = $"INSERT INTO Pokemon (Name, Pokemon_Level) VALUES ('{pokemon.Name}', '{pokemon.Level}');";
            MSSQL.ExecuteNonQuery(sql);
            int maxId = MSSQL.GetMax("pokemon", "id");
            return Retrieve(maxId);
        }

        public void Delete(int Id)
        {
            string sql = $"DELETE FROM Pokemon WHERE id = {Id};";
            MSSQL.ExecuteNonQuery(sql);
        }

        public Pokemon Retrieve(int Id)
        {
            string sql = $"SELECT Pokemon.Id, Name, Pokemon_Level, TypeName FROM Pokemon INNER JOIN Type ON Pokemon.Type_Id = Type.Id WHERE Pokemon.Id = {Id};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"O Pokémon de número {Id} não foi encontrado.");
        }

        public Pokemon Retrieve(string Name)
        {
            string sql = $"SELECT * FROM Pokemon WHERE name = {Name};";
            SqlDataReader reader = MSSQL.Execute(sql);
            if (reader.Read())
            {
                return Parse(reader);
            }
            throw new KeyNotFoundException($"O Pokémon {Name} não foi encontrado.");
        }

        public List<Pokemon> RetrieveAll()
        {
            string sql = $"SELECT * FROM Pokemon;";
            SqlDataReader reader = MSSQL.Execute(sql);
            List<Pokemon> pokemons = new List<Pokemon>();
            while (reader.Read())
            {
                pokemons.Add(Parse(reader));
            }
            return pokemons;
        }

        public Pokemon Update(Pokemon pokemon)
        {
            string sql = $"UPDATE Pokemon SET Name = '{pokemon.Name}', Level = '{pokemon.Level}';";
            MSSQL.ExecuteNonQuery(sql);
            return Retrieve(pokemon.Id);
        }

        private Pokemon Parse(SqlDataReader reader)
        {
            Pokemon pokemon = new Pokemon();
            Type type = new Model.Type();
            pokemon.Id = Convert.ToInt32(reader["Id"]);
            pokemon.Name = Convert.ToString(reader["Name"]);
            pokemon.Level = Convert.ToInt32(reader["Pokemon_Level"]);
            type.TypeName = Convert.ToString(reader["TypeName"]);
            return pokemon;
        }
    }
}
