using McKing.Model;
using McKing.Repository.Interface;
using McKing.Service.Interface;

namespace McKing.Service.Implementation
{
    public class DifficultyService : IService<Difficulty, int>
    {
        private readonly IRepository<Difficulty, int> _repository;

        public DifficultyService(IRepository<Difficulty, int> repository)
        {
            this._repository = repository;
        }

        public Difficulty Create(Difficulty difficulty)
        {
            return _repository.Create(difficulty);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Difficulty Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Difficulty> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Difficulty Update(Difficulty difficulty)
        {
            return _repository.Update(difficulty);
        }
    }
}
