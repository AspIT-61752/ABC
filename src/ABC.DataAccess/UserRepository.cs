using ABC.Entities;

namespace ABC.DataAccess
{
    public class UserRepository(DataContext context) : Repository<User>(context), IUserRepository
    {
        /// <summary>
        /// Checks if the email and password of the user are valid
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns></returns>
        public (bool, string) IsUserValid(User user)
        {
            User dbUser = new();

            // Find the user in the database
            if (user.UserId != null && user.UserId != 0) // Get by ID
            {
                dbUser = context.Users.FirstOrDefault(u => u.UserId == user.UserId);
            }
            else
            {
                dbUser = context.Users.FirstOrDefault(u => u.Email == user.Email);
            }

            // If the user is not found, return false
            if (dbUser == null)
            {
                return (false, "Not found");
            }
            // If the user is found, but the password or email is incorrect, return false
            else if (dbUser.Password == user.Password && dbUser.Email == user.Email)
            {
                return (true, dbUser.Username);
            }
            else
            {
                return (false, "Incorrect Email or password");
            }
        }
    }
}
