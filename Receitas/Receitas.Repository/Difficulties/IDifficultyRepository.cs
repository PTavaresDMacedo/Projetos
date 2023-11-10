using Receitas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repository.Difficulties
{
    public interface IDifficultyRepository
    {
        Difficulty Create(Difficulty difficulty);
        Difficulty Update(Difficulty difficulty);
        Difficulty Retrieve (int id);
        List<Difficulty> RetrieveAll();
        void Delete(int id);
    }
}
