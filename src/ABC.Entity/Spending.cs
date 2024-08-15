using System.Text.Json.Serialization;

namespace ABC.Entity
{
    public class Spending
    {
        private int spendingId;
        private int spent;
        private User user;
        private Category category;

        [JsonConstructor]
        public Spending() { }
        public Spending(int spendingId, int spent, User user, Category category)
        {
            SpendingId = spendingId;
            Spent = spent;
            User = user;
            Category = category;
        }

        public int SpendingId { get => spendingId; set => spendingId = value; }
        public int Spent { get => spent; set => spent = value; }
        public User User { get => user; set => user = value; }
        public Category Category { get => category; set => category = value; }
    }
}
