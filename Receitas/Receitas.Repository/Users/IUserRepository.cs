using Receitas.Model;

namespace Receitas.Repository.Users
{
    public interface IUserRepository
    {
        User Create (User user);
        User Retrieve(int id);
        List<User> RetrieveAll();
        User Update (User user);
        void Delete (int id);
    }
}
