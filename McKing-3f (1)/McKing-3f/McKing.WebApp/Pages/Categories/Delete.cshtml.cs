using McKing.Model;
using McKing.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace McKing.WebApp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly IService<Category, int> _service;

        public DeleteModel(IService<Category, int> service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            _service.Delete(id);
            return Redirect("/Categories/RetrieveAll");
        }
    }
}
