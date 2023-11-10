using Receitas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repository.Categories
{
    public interface ICategoryRepository
    {
        Category Create(Category category);
        Category Update(Category category);
        Category Retrieve(int id);
        List<Category> RetrieveAll();
        void Delete(int id);
    }
}
