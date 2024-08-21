namespace ABC.Calculator
{
    public class Debt
    {
        // It would be interesting to make something like: https://www.calculator.net/debt-payoff-calculator.html
        // later, but we'll need to make V0.1 first. 

        // PaybackDebtByInstallment
        public int PaybackDebtByInstallment(double debt, double interest, double installment)
        {
            double total = debt;
            double totalDebt = debt;
            double convertedInterest = (interest / 100) + 1; // interest = 10% = 0.1; 1 + 0.1 = 1.1
            int months = 0;

            while (total > 0)
            {
                // TODO: Add a Total Interest Paid variable
                total = total * convertedInterest;  // 100 * 1.1 = 110
                total -= installment;               // 110 - 20 = 90
                months++;                           // 1
            }

            // I'm changing the return type to int
            // I could just return this string in the controller instead of here. 
            // It just makes more sense to me to return the number of months, instead of a string.
            // It's easier to test and can be used in other methods.
            // return $"It will take ${months} months to pay back a debt of ${totalDebt} with an interest of ${interest} and an installment of ${installment}.";

            return months;
        }

        // PaybackDebtByAmount
        public int PaybackDebtByMonthlyAmount(double debt, double interest, double amount)
        {
            // I did do the math right: https://www.fm-magazine.com/news/2018/jan/excel-debt-repayment-calculations-201718014.html 
            // G = y * ( 1-(1 + r)^-n / r )
            // Find n
            double total = debt; // G
            double monthlyPayment = amount; // y
            double convertedInterest = interest / 100; // r

            // Math
            int n = Convert.ToInt32(System.Math.Ceiling(-1 * (System.Math.Log(1 - (total * convertedInterest / monthlyPayment)) / System.Math.Log(1 + convertedInterest))));

            return n;
        }


        // PaybackDebtByDate
        public int PaybackDebtByDate(double debt, double interest, DateOnly date)
        {
            double total = debt;

            return 0;
        }

    }
}
