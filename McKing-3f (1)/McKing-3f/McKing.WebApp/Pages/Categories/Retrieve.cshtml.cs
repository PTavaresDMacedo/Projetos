using McKing.Model;
using McKing.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace McKing.WebApp.Pages.Categories
{
    public class RetrieveModel : PageModel
    {

        private readonly IService<Category, int> _service;

        public Category Category { get; set; }

        public RetrieveModel(IService<Category, int> service)
        {
            _service = service;
        }

        public void OnGet(int id)
        {
            Category = _service.Retrieve(id);
        }
    }
}
