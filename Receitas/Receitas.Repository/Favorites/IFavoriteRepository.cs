using Receitas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repository.Favorites
{
    public interface IFavoriteRepository
    {
        Favorite Create(Favorite favorite);
        Favorite Update(Favorite favorite);
        Favorite Retrieve(int id);
        List<Favorite> RetrieveAll();
        void Delete(int id);
    }
}
