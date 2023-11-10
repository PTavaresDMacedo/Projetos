using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Users;

namespace Tastebook.WebApp.Pages.Users
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IUserService _userService;

        public RetrieveAllModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = _userService.RetrieveAll();
        }

        public void OnPost()
        {
            User user = new User();
            user.FirstName = Convert.ToString(Request.Form["first_name"]);
            user.LastName = Convert.ToString(Request.Form["last_name"]);
            user.Email = Convert.ToString(Request.Form["email"]);
            user.Login = Convert.ToString(Request.Form["login"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            //user.IsAdmin = Convert.ToBoolean(Request.Form["is_admin"]);
            //user.IsBlocked = Convert.ToBoolean(Request.Form["is_blocked"]);
            _userService.Create(user);
            Users = _userService.RetrieveAll();
        }
    }
}
