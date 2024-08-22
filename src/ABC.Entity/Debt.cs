using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Entities
{
    public class Debt
    {
        private int debtId; // Probably not needed, but it's good to have if we want to store this in a database

        private double debtAmount; // The amount of the debt
        private double interestRate; // The interest rate in decimal form (10 = 10% interest)

        private double minimumPaymentThreshold; // The minimum amount that should be paid so the debt doesn't grow
        private double monthlyPayment; // The amount paid per month by the debtor (Person who owes money) (Is this needed?)
        
        private int monthsToPayback; // The amount of months it will take to pay back the debt with the given interest and installment (monthlyPayment)

        // This is a bit more advanced, but it would be interesting to make
        private DateOnly startDate; // The date the debt was created
        private double projectedInterestPaid; // The estimated amount of interest paid
        private DateOnly projectedEndDate; // The date the debt is projected to be paid off
        private double totalInterestPaid; // The total amount of interest paid
        private DateOnly endDate; // The date the debt was paid off

        public Debt(double debtAmount, double interestRate)
        {
            DebtAmount = debtAmount;
            InterestRate = interestRate;
        }

        public int DebtId { get => debtId; set => debtId = value; }
        public double DebtAmount { get => debtAmount; set => debtAmount = value; }
        public double InterestRate { get => interestRate; set => interestRate = value; }
        public double MinimumPaymentThreshold { get => minimumPaymentThreshold; set => minimumPaymentThreshold = value; }
        public double MonthlyPayment { get => monthlyPayment; set => monthlyPayment = value; }
        public int MonthsToPayback { get => monthsToPayback; set => monthsToPayback = value; }
        public DateOnly StartDate { get => startDate; set => startDate = value; }
        public double ProjectedInterestPaid { get => projectedInterestPaid; set => projectedInterestPaid = value; }
        public DateOnly ProjectedEndDate { get => projectedEndDate; set => projectedEndDate = value; }
        public double TotalInterestPaid { get => totalInterestPaid; set => totalInterestPaid = value; }
        public DateOnly EndDate { get => endDate; set => endDate = value; }
    }
}
