using Pokedex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Repository
{
    internal interface IPokemonRepository
    {
        public Pokemon Create(Pokemon pokemon); 
        public Pokemon Retrieve(int Id);
        public Pokemon Retrieve(string Name);
        public List<Pokemon> RetrieveAll();
        public Pokemon Update(Pokemon pokemon);
        public void Delete(int Id);

    }
}
