using Microsoft.AspNetCore.Mvc;
using Receitas.Model;
using Receitas.Service.Difficulties;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly IDifficultyService _difficultyService;

        public DifficultyController(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        // GET: api/<DifficultyController>
        [HttpGet]
        public IEnumerable<Difficulty> Get()
        {
            return _difficultyService.RetrieveAll();
        }

        // GET api/<DifficultyController>/5
        [HttpGet("{id}")]
        public Difficulty Get(int id)
        {
            return _difficultyService.Retrieve(id);
        }

        // POST api/<DifficultyController>
        [HttpPost]
        public Difficulty Post([FromBody] Difficulty difficulty)
        {
            return _difficultyService.Create(difficulty);
        }

        // PUT api/<DifficultyController>/5
        [HttpPut("{id}")]
        public Difficulty Put(int id, [FromBody] Difficulty difficulty)
        {
            return _difficultyService.Update(difficulty);
        }

        // DELETE api/<DifficultyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _difficultyService.Delete(id);
        }
    }
}
