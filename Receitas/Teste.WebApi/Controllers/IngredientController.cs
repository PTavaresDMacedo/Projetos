using Microsoft.AspNetCore.Mvc;
using Receitas.Model;
using Receitas.Service.Ingredients;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        // GET: api/<IngredientController>
        [HttpGet]
        public IEnumerable<Ingredient> Get()
        {
            return _ingredientService.RetrieveAll();
        }

        // GET api/<IngredientController>/5
        [HttpGet("{id}")]
        public Ingredient Get(int id)
        {
            return _ingredientService.Retrieve(id);
        }

        // POST api/<IngredientController>
        [HttpPost]
        public Ingredient Post([FromBody] Ingredient ingredient)
        {
            return _ingredientService.Create(ingredient);
        }

        // PUT api/<IngredientController>/5
        [HttpPut("{id}")]
        public Ingredient Put([FromBody] Ingredient ingredient)
        {
            return _ingredientService.Update(ingredient);
        }

        // DELETE api/<IngredientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ingredientService.Delete(id);
        }
    }
}
