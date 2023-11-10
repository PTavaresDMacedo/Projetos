using McKing.Model;
using McKing.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace McKing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<User, int> _service;

        public UserController(IService<User, int> service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _service.RetrieveAll();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _service.Retrieve(id);
        }

        [HttpPost]
        public User Post([FromBody] User user)
        {
            return _service.Create(user);
        }

        [HttpPut]
        public User Put([FromBody] User user)
        {
            return _service.Update(user);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
