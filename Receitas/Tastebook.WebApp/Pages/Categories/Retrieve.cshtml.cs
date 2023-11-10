using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Categories;

namespace Tastebook.WebApp.Pages.Categories
{
    public class RetrieveModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        public Category Category { get; set; }

        public RetrieveModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public void OnGet(int id)
        {
            Category = _categoryService.Retrieve(id);
        }
    }
}
