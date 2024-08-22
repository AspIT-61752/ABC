﻿using ABC.Entities;

namespace ABC.Calculator
{
    public class DebtManager
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

        // SnowballMethod. A method to pay off debts by paying the smallest debt first, then the next smallest, etc.
        // You pay the minimum on all debts, then pay the smallest debt as much as you can.
        // I'll need to make a few methods to make this work.
        // Maybe I should sort the debts by amount and interest rate first. Find a way to calculate the minimum payment.

        // I probably need to make a class for the debts, the payments, and the debts paid off. 3 classes:
        // Debt (amount, interest rate, etc.)
        // Payment (amount, date, etc.)
        // DebtPaid (months to pay off, interest paid, etc.)

        // 1. Get the smallest debt
        // 2. Pay the smallest debt
        // 3. Repeat until all debts are paid off
        // 4. Return the list of debts with the amount paid and the amount left.


        public List<Debt> SnowballMethod(List<Debt> debts)
        {
            // Sort the debts by amount
            // Calculate the projected time and money to pay off all debts.
            // Return the list of debts with the amount paid and the amount left.

            // I think we could make a button that makes a new row of (debt, interest, installment), with the same unique class.
            // Then when the user clicks the calculate button, it gets all the rows with that class and sends them to the controller.
            // const debts = document.querySelectorAll('.debt-row'); 
            // If the controller only gets a list of debt, interest, and installment instead of a List<Debt>, I'll just make a foreach loop to make the List<Debt> in the controller.

            // Make a method to calculate the minimum payment for each debt.

            int setId = 0;
            double monthlyDebtBudget = 0;   // The total amount they can pay per month.
                                            // If I do this, I want to return the total amount paid per month as well.

            foreach (var debt in debts)
            {
                debt.DebtId = setId;

                // Calculate the minimum payment
                debt.MinimumPaymentThreshold = CalculateDebtPaymentThreshold(debt.DebtAmount, debt.InterestRate);
                debt.MonthlyPayment = debt.MinimumPaymentThreshold;
                monthlyDebtBudget -= debt.MonthlyPayment;


                setId++;
            }

            // I probably have to make a method that loops through the debts like bubble sort.
            // So when the monthly payment for the smallest debt is paid, it goes to the next smallest debt and carries over the monthly payment from the previous debt. (Just remember to set the previous MonthlyPayment to 0)
            // Timecomplexity: O(n^2) - I think it's fine, people won't have that many debts where it would be a problem. (I hope)
            for (int i = 0; i < debts.Count(); i++)
            {
                debts[i].MonthsToPayback = PaybackDebtByInstallment(debts[i].DebtAmount, debts[i].InterestRate, debts[i].MonthlyPayment); // I don't have the monthly payment yet.
                // I could probably set a parameter for the monthly debt payment (The total amount they can pay per month).
                // Keep track of the total amount paid per month.
                // And just set the monthly payment to the minimum payment threshold.
            }

            debts = debts.OrderBy(debt => debt.DebtAmount).ToList(); // Sort the debts by amount. 

            return debts;
        }

        /// <summary>
        /// Calculate the minimum payment needed to pay off a debt without it growing.
        /// </summary>
        /// <param name="debtAmount">The amount of the debt</param>
        /// <param name="interestRate">The interest rate in decimal form (10 = 10% interest)</param>
        /// <returns>The amount that should be paid so the debt doesn't grow</returns>
        private double CalculateDebtPaymentThreshold(double debtAmount, double interestRate)
        {
            double interest = debtAmount * (interestRate / 100);
            double minimumPayment = debtAmount + interest;
            return minimumPayment;
        }
    }
}
