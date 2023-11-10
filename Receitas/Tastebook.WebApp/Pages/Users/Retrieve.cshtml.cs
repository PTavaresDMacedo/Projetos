using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Users;

namespace Tastebook.WebApp.Pages.Users
{
    public class RetrieveModel : PageModel
    {
        private readonly IUserService _userService;

        public RetrieveModel(IUserService userService)
        {
            _userService = userService;
        }

        public User User { get; set; }

        public void OnGet(int id)
        {
            User = _userService.Retrieve(id);
        }
    }
}
