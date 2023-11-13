using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.App.Service
{
    public interface ITypeService
    {
        public Model.Type Retrieve(int Id);
        public Model.Type Retrieve(string Name);
        public List<Model.Type> RetrieveAll();
    }
}
