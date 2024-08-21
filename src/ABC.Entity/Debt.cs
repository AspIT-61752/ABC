using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Entities
{
    public class Debt
    {
        private int debtId;
        private double debtAmount;
        private double interestRate;
        private double monthlyPayment;
        private int monthsToPayback;
        private DateOnly startDate;
        private DateOnly projectedEndDate;
        private DateOnly endDate;
    }
}
