using Microsoft.AspNetCore.Mvc;
using Receitas.Model;
using Receitas.Service.Measures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureController : ControllerBase
    {
        private readonly IMeasureService _measureService;

        public MeasureController(IMeasureService measureService)
        {
            _measureService = measureService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Measure> Get()
        {
            return _measureService.RetrieveAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Measure Get(int id)
        {
            return _measureService.Retrieve(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Measure Post([FromBody] Measure measure)
        {
            return _measureService.Create(measure);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public Measure Put(int id, [FromBody] Measure measure)
        {
            return _measureService.Update(measure);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _measureService.Delete(id);
        }
    }
}
