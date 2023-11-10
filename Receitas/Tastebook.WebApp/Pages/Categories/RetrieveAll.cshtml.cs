using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Categories;

namespace Tastebook.WebApp.Pages.Categories
{
    public class RetrieveAllModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        public RetrieveAllModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<Category> categories { get; set; }

        public void OnGet()
        {
            categories = _categoryService.RetrieveAll();
        }

        public void OnPost()
        {
            Category category = new Category();
            category.Name = Convert.ToString(Request.Form["name"]);
            _categoryService.Create(category);
            categories = _categoryService.RetrieveAll();
        }
    }
}
