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
        public void AddNew([FromBody] User user) => _repo.Add(user);

        [HttpPut]
        public void UpdateBy([FromBody] User user) => _repo.Update(user);

        [HttpDelete]
        [Route("DeleteByUser")]
        public void DeleteBy([FromBody] User user) => _repo.DeleteBy(user);

        [HttpDelete]
        [Route("DeleteById")]
        public void DeleteBy([FromBody] int id) => _repo.DeleteBy(id);

        [HttpGet]
        [Route("GetById")]
        public User GetBy([FromBody] int id) => _repo.GetBy(id);

        [HttpGet]
        [Route("GetByUser")]
        public User GetBy([FromBody] User user) => _repo.GetBy(user);

        [HttpGet]
        public IEnumerable<User> GetAll() => _repo.GetAll();

        [HttpGet]
        [Route("IsUserValid")]
        public (bool, string) IsUserValid([FromBody] User user) => _repo.IsUserValid(user);
    }
}
