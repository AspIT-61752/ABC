using System.Text.Json.Serialization;

namespace ABC.Entities
{
    public class Saving
    {
        private int savingId;
        private string savingName;
        private User user;
        private int savingsGoal;
        private int savingsBalance;

        [JsonConstructor]
        public Saving() { }

        public Saving(int savingId, string savingName, User user, int savingsGoal, int savingsBalance)
        {
            SavingId = savingId;
            SavingName = savingName;
            User = user;
            SavingsGoal = savingsGoal;
            SavingsBalance = savingsBalance;
        }

        public int SavingId { get => savingId; set => savingId = value; }
        public string SavingName { get => savingName; set => savingName = value; }
        public User User { get => user; set => user = value; }
        public int SavingsGoal { get => savingsGoal; set => savingsGoal = value; }
        public int SavingsBalance { get => savingsBalance; set => savingsBalance = value; }
    }
}
