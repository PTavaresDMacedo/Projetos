using McKing.Model;
using McKing.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace McKing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService<Category, int> _service;

        public CategoryController(IService<Category, int> service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _service.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _service.Retrieve(id);
        }

        [HttpPost]
        public Category Post([FromBody] Category category)
        {
            return _service.Create(category);
        }

        [HttpPut]
        public Category Put([FromBody] Category category)
        {
            return _service.Update(category);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
