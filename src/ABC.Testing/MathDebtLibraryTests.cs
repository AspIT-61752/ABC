using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.Testing
{
    public class MathDebtLibraryTests
    {
        private readonly Calculator.Debt _calcD = new Calculator.Debt();

        [Fact]
        public void CalcDebtInterest_Loop()
        {
            // Did some testing, looks like this meathod is 3 - 7 times faster than the other one.
            // PaybackDebtByInstallment (1ms - 2ms)
            // PaybackDebtByMonthlyAmount (4ms - 7ms)
            var result = _calcD.PaybackDebtByInstallment(24000, 1.6, 780); // $24000 debt, 1.6% interest, $780 monthly payment

            // Result: 32 months according to some online calculator. 
            // But I think it sould be around 42 - 43 months.
            Assert.Equal(43, result);
        }

        [Fact]
        public void CalcDebtInterest_formula()
        {
            //var result = _calcD.PaybackDebtByInstallment(24000, 1.6, 780); // $24000 debt, 1.6% interest, $780 monthly payment

            var result = _calcD.PaybackDebtByMonthlyAmount(24000, 1.6, 780);

            // Result: 32 months
            Assert.Equal(43, result);
        }

        [Fact]
        public void CalcDebtInterest_Larger_Loop()
        {
            // This doesn't run at all, and apparently the test bellow says it returns nan.
            var result = _calcD.PaybackDebtByInstallment(12421000, 0.05, 16584); // $2421000 debt, 0.6% interest, $6584 monthly payment

            // Result: 32 months according to some online calculator. 
            // But I think it sould be around 42 - 43 months.
            Assert.Equal(43, result);
        }

        [Fact]
        public void CalcDebtInterest_Larger_formula()
        {
            //var result = _calcD.PaybackDebtByInstallment(24000, 1.6, 780); // $24000 debt, 1.6% interest, $780 monthly payment

            var result = _calcD.PaybackDebtByMonthlyAmount(12421000, 0.05, 16584);

            // Result: 32 months
            Assert.Equal(43, result);
        }
    }
}
