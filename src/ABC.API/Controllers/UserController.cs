using ABC.DataAccess;
using ABC.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ABC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IRepository<User> repo) : Controller
    {
        private readonly IRepository<User> _repo = repo;

        [HttpPost]
        public void AddNew([FromQuery] User user) => _repo.Add(user);

        [HttpPut]
        public void UpdateBy([FromQuery] User user) => _repo.Update(user);

        [HttpDelete]
        public void DeleteBy([FromQuery] User user) => _repo.DeleteBy(user);

        [HttpDelete]
        public void DeleteBy([FromQuery] int id) => _repo.DeleteBy(id);

        [HttpGet]
        public User GetBy([FromQuery] int id) => _repo.GetBy(id);

        [HttpGet]
        public User GetBy([FromQuery] User user) => _repo.GetBy(user);

        [HttpGet]
        public IEnumerable<User> GetAll() => _repo.GetAll();
    }
}
