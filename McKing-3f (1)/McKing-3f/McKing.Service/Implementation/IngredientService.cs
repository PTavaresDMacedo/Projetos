using McKing.Model;
using McKing.Repository.Interface;
using McKing.Service.Interface;

namespace McKing.Service.Implementation
{
    public class IngredientService : IService<Ingredient, int>
    {
        private readonly IRepository<Ingredient, int> _repository;

        public IngredientService(IRepository<Ingredient, int> repository)
        {
            this._repository = repository;
        }

        public Ingredient Create(Ingredient ingredient)
        {
            return _repository.Create(ingredient);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Ingredient Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Ingredient> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Ingredient Update(Ingredient ingredient)
        {
            return _repository.Update(ingredient);
        }
    }
}
