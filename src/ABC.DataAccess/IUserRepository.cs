using ABC.Entities;

namespace ABC.DataAccess
{
    public interface IUserRepository : IRepository<User>
    {
        bool IsUserValid(User user);
    }
}
