using ABC.DataAccess;
using ABC.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ABC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository repo) : Controller
    {
        private readonly IUserRepository _repo = repo;

        [HttpPost]
        public void AddNew([FromQuery] User user) => _repo.Add(user);

        [HttpPut]
        public void UpdateBy([FromQuery] User user) => _repo.Update(user);

        [HttpDelete]
        [Route("DeleteByUser")]
        public void DeleteBy([FromQuery] User user) => _repo.DeleteBy(user);

        [HttpDelete]
        [Route("DeleteById")]
        public void DeleteBy([FromQuery] int id) => _repo.DeleteBy(id);

        [HttpGet]
        [Route("GetById")]
        public User GetBy([FromQuery] int id) => _repo.GetBy(id);

        [HttpGet]
        [Route("GetByUser")]
        public User GetBy([FromQuery] User user) => _repo.GetBy(user);

        [HttpGet]
        public IEnumerable<User> GetAll() => _repo.GetAll();

        [HttpGet]
        [Route("IsUserValid")]
        public (bool, string) IsUserValid([FromQuery] User user) => _repo.IsUserValid(user);
    }
}
