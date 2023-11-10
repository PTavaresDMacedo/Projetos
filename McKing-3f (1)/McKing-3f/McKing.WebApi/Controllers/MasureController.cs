using McKing.Model;
using McKing.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace McKing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasureController : ControllerBase
    {
        private readonly IService<Measure, int> service;

        public MasureController(IService<Measure, int> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Measure> Get()
        {
            return service.RetrieveAll();
        }

        [HttpGet("{id}")]
        public Measure Get(int id)
        {
            return service.Retrieve(id);
        }

        [HttpPost]
        public Measure Post([FromBody] Measure measure)
        {
            return service.Create(measure);
        }

        [HttpPut]
        public Measure Put([FromBody] Measure measure)
        {
            return service.Update(measure);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
