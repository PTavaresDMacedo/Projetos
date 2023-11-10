using McKing.Model;
using McKing.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace McKing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientLineController : ControllerBase
    {
        private readonly IIngredientLineService _service;

        public IngredientLineController(IIngredientLineService service)
        {
            _service = service;
        }

        [HttpGet("recipe/{id}")]
        public IEnumerable<IngredientLine> GetByRecipeId(int id)
        {
            return _service.RetrieveAllByRecipeId(id);
        }

        [HttpGet("{id}")]
        public IngredientLine Get(int id)
        {
            return _service.Retrieve(id);
        }

        [HttpPost]
        public IngredientLine Post([FromBody] IngredientLine ingredientLine)
        {
            return _service.Create(ingredientLine);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        [HttpDelete("recipe/{id}")]
        public void DeleteAllByRecipeId(int id)
        {
            _service.DeleteAllByRecipeId(id);
        }
    }
}
