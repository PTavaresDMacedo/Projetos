using McKing.Model;
using McKing.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace McKing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IService<Recipe, int> _service;

        public RecipeController(IService<Recipe, int> service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return _service.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            return _service.Retrieve(id);
        }

        [HttpPost]
        public Recipe Post([FromBody] Recipe recipe)
        {
            return _service.Create(recipe);
        }

        [HttpPut]
        public Recipe Put([FromBody] Recipe recipe)
        {
            return _service.Update(recipe);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
