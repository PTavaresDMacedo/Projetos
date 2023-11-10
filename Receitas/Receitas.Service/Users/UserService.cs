using Receitas.Model;
using Receitas.Repository.Users;

namespace Receitas.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            this._repository = repository;
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
