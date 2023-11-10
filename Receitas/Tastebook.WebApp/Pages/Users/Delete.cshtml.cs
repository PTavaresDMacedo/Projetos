using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Service.Users;

namespace Tastebook.WebApp.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult OnGet(int id)
        {
            _userService.Delete(id);
            return Redirect("/Users/RetrieveAll");
        }
    }
}
