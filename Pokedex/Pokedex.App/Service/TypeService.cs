using Pokedex.App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Repository;

namespace Pokedex.App.Service
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository = new TypeRepository();
        public Model.Type Retrieve(int Id)
        {
            return _typeRepository.Retrieve(Id);
        }

        public Model.Type Retrieve(string Name)
        {
            return _typeRepository.Retrieve(Name);
        }

        public List<Model.Type> RetrieveAll()
        {
            return _typeRepository.RetrieveAll();
        }
    }
}
