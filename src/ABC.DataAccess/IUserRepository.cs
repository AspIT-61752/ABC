using ABC.Entities;

namespace ABC.DataAccess
{
    public interface IUserRepository : IRepository<User>
    {
        (bool, string) IsUserValid(User user);
    }
}
