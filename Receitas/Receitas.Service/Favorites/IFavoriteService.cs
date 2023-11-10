using Receitas.Model;

namespace Receitas.Service.Favorites
{
    public interface IFavoriteService
    {
        Favorite Create(Favorite favorite);
        Favorite Update(Favorite favorite);
        Favorite Retrieve(int id);
        List<Favorite> RetrieveAll();
        void Delete(int id);
    }
}
