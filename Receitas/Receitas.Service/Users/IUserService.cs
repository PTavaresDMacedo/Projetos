using Receitas.Model;

namespace Receitas.Service.Users
{
    public interface IUserService
    {
        User Create(User user);
        User Retrieve(int id);
        List<User> RetrieveAll();
        User Update(User user);
        void Delete(int id);
    }
}
