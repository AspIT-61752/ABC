namespace ABC.Calculator
{
    public class Debt
    {
        // It would be interesting to make something like: https://www.calculator.net/debt-payoff-calculator.html
        // later, but we'll need to make V0.1 first. 

        // PaybackDebtByInstallment
        /// <summary>
        /// Calculate how many months it will take to pay back a debt with an interest rate and a monthly installment
        /// </summary>
        /// <remarks>Uses a loop instead of a formula.</remarks>
        /// <param name="debt">Debt amount</param>
        /// <param name="interest">Interest rate in decimal form (10 = 10% interest)</param>
        /// <param name="installment">Amount paid per month</param>
        /// <returns>Amount of months it will take to pay back the debt with the given interest and installment</returns>
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
        /// <summary>
        /// Calculate how many months it will take to pay back a debt with an interest rate and a monthly installment.
        /// </summary>
        /// <remarks>Uses a formula instead of a loop.</remarks>
        /// <param name="debt">Debt amount</param>
        /// <param name="interest">Interest rate in decimal form (10 = 10% interest)</param>
        /// <param name="installment">Amount paid per month</param>
        /// <returns>Amount of months it will take to pay back the debt with the given interest and installment</returns>
        public int PaybackDebtByInstallment_formula(double debt, double interest, double amount)
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
