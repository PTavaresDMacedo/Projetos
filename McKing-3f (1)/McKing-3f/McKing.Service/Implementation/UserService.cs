using McKing.Model;
using McKing.Repository.Interface;
using McKing.Service.Interface;

namespace McKing.Service.Implementation
{
    public class UserService : IService<User, int>
    {
        private readonly IRepository<User, int> _repository;

        public UserService(IRepository<User, int> repository)
        {
            _repository = repository;
        }

        public User Create(User user)
        {
            return _repository.Create(user);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public User Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<User> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public User Update(User user)
        {
            return _repository.Update(user);
        }
    }
}
