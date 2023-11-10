using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Categories;

namespace Tastebook.WebApp.Pages.Categories
{
    public class UpdateModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public UpdateModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public Category Category { get; set; }

        public void OnGet(int id)
        {
            Category = _categoryService.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(Request.Form["id"]);
            category.Name = Convert.ToString(Request.Form["name"]);
            _categoryService.Update(category);
            return Redirect("/Categories/RetrieveAll");
        }
    }
}
