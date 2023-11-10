using Receitas.Model;
using Receitas.Repository.Categories;

namespace Receitas.Service.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public Category Create(Category category)
        {
            return _categoryRepository.Create(category);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

        public Category Retrieve(int id)
        {
            return _categoryRepository.Retrieve(id);
        }

        public List<Category> RetrieveAll()
        {
            return _categoryRepository.RetrieveAll();
        }

        public Category Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
    }
}
