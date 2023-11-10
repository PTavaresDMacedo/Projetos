using McKing.Model;
using McKing.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace McKing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly IService<Difficulty, int> service;

        public DifficultyController(IService<Difficulty, int> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Difficulty> Get()
        {
            return service.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Difficulty Get(int id)
        {
            return service.Retrieve(id);
        }

        [HttpPost]
        public Difficulty Post([FromBody] Difficulty difficulty)
        {
            return service.Create(difficulty);
        }

        [HttpPut]
        public Difficulty Put([FromBody] Difficulty difficulty)
        {
            return service.Update(difficulty);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
