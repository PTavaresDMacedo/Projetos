using McKing.Model;
using McKing.Service.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace McKing.WebApp.Pages.Recipes
{
    public class RetrieveModel : PageModel
    {
        private readonly IService<Recipe, int> _service;
        public Recipe Recipe { get; set; }

        public RetrieveModel(IService<Recipe, int> service)
        {
            _service = service;
        }

        public void OnGet()
        {

            Recipe = _service.Retrieve(2);
        }
    }
}
