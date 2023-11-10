using McKing.Model;
using McKing.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace McKing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IService<Ingredient, int> service;

        public IngredientController(IService<Ingredient, int> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Ingredient> Get()
        {
            return service.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Ingredient Get(int id)
        {
            return service.Retrieve(id);
        }

        [HttpPost]
        public Ingredient Post([FromBody] Ingredient ingredient)
        {
            return service.Create(ingredient);
        }

        [HttpPut]
        public Ingredient Put([FromBody] Ingredient ingredient)
        {
            return service.Update(ingredient);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
