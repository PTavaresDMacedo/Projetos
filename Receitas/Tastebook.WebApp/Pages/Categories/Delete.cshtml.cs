using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Service.Categories;

namespace Tastebook.WebApp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public DeleteModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult OnGet(int id)
        {
            _categoryService.Delete(id);
            return Redirect("/Categories/RetrieveAll");
        }
    }
}
