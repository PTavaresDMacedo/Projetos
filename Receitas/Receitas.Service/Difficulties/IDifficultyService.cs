using Receitas.Model;

namespace Receitas.Service.Difficulties
{
    public interface IDifficultyService
    {
        Difficulty Create(Difficulty difficulty);
        Difficulty Update(Difficulty difficulty);
        Difficulty Retrieve(int id);
        List<Difficulty> RetrieveAll();
        void Delete(int id);
    }
}
