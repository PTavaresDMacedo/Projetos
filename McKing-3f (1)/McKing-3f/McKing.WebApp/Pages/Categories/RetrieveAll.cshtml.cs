using McKing.Model;
using McKing.Service.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace McKing.WebApp.Pages
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IService<Category, int> _service;

        public RetrieveAllModel(IService<Category, int> service)
        {
            _service = service;
        }

        public List<Category> categories { get; set; }

        public void OnGet()
        {
            categories = _service.RetrieveAll();
        }

        public void OnPost()
        {
            Category category = new Category();
            category.Name = Convert.ToString(Request.Form["name"]);
            _service.Create(category);
            categories = _service.RetrieveAll();
        }
    }
}
