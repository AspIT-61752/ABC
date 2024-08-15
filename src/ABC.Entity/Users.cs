using System.Text.Json.Serialization;

namespace ABC.Entity
{
    public class User
    {
        private int userId;
        private string username;
        private string password;
        private string email;

        [JsonConstructor]
        public User() { }

        public User(int id, string username, string password, string email)
        {
            UserId = id;
            Username = username;
            Password = password;
            Email = email;
        }

        public int UserId { get => userId; set => userId = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
    }
}
