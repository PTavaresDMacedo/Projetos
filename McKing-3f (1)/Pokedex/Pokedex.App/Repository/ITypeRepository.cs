using Pokedex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Pokedex.Model.Type;

namespace Pokedex.App.Repository
{
    public interface ITypeRepository
    {
        public Type Retrieve(int Id);
        public Type Retrieve(string Name);
        public List<Type> RetrieveAll();
    }
}
