using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Users;

namespace Tastebook.WebApp.Pages.Users
{
    public class UpdateModel : PageModel
    {
        private readonly IUserService _userService;

        public UpdateModel(IUserService userService)
        {
            _userService = userService;
        }

        public User User { get; set; }

        public void OnGet(int id)
        {
            User = _userService.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            User user = new User();
            user.Id = Convert.ToInt32(Request.Form["id"]);
            user.FirstName = Convert.ToString(Request.Form["first_name"]);
            user.LastName = Convert.ToString(Request.Form["last_name"]);
            user.Email = Convert.ToString(Request.Form["email"]);
            user.Login = Convert.ToString(Request.Form["login"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            //user.IsAdmin = Convert.ToBoolean(Request.Form["is_admin"]);
            //user.IsBlocked = Convert.ToBoolean(Request.Form["is_blocked"]);
            _userService.Update(user);
            return Redirect("/Users/RetrieveAll");
        }
    }
}
