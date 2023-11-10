using McKing.Model;
using McKing.Repository.Interface;
using McKing.Service.Interface;

namespace McKing.Service.Implementation
{
    public class CategoryService : IService<Category, int>
    {
        private readonly IRepository<Category, int> _repository;

        public CategoryService(IRepository<Category, int> repository)
        {
            this._repository = repository;
        }

        public Category Create(Category cateegory)
        {
            return _repository.Create(cateegory);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Category Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Category> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Category Update(Category cateegory)
        {
            return _repository.Update(cateegory);
        }
    }
}
