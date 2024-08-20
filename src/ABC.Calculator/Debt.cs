namespace ABC.Calculator
{
    public class Debt
    {
        // It would be interesting to make something like: https://www.calculator.net/debt-payoff-calculator.html
        // later, but we'll need to make V0.1 first. 

        // PaybackDebtByInstallment
        public string PaybackDebtByInstallment(double debt, double interest, double installment)
        {
            double total = debt;
            double totalInterest = 0;
            double totalDebt = debt;
            int months = 0;

            while (total > 0)
            {
                totalInterest = total * interest;
                total += totalInterest;
                total -= installment;
                months++;
            }

            return $"It will take ${months} months to pay back a debt of ${totalDebt} with an interest of ${interest} and an installment of ${installment}.";
        }

        // PaybackDebtByAmount
        public string PaybackDebtByMonthlyAmount(double debt, double interest, double amount)
        {
            // G = y * ( 1-(1 + r)^-n / r )
            // Find n
            double total = debt; // G
            double monthlyPayment = amount; // y
            double convertedInterest = interest / 100; // r

            // Math
            double n = System.Math.Log(1 - (total * convertedInterest / monthlyPayment)) / System.Math.Log(1 + convertedInterest);

            return "";
        }


        // PaybackDebtByDate
        public string PaybackDebtByDate(double debt, double interest, DateOnly date)
        {
            double total = debt;

            return "";
        }

    }
}
