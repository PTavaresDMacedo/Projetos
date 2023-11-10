using Receitas.Model;

namespace Receitas.Service.Categories
{
    public interface ICategoryService
    {
        Category Create(Category category);
        Category Update(Category category);
        Category Retrieve(int id);
        List<Category> RetrieveAll();
        void Delete(int id);
    }
}
