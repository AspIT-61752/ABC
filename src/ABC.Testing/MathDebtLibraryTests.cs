namespace ABC.Testing
{
    public class MathDebtLibraryTests
    {
        private readonly Calculator.DebtManager _calcD = new Calculator.DebtManager();

        [Fact]
        public void CalcDebtInterest_Loop()
        {
            var result = _calcD.PaybackDebtByInstallment(2000, 1.0, 1000); // $2000 debt, 1.0% interest, $1000 monthly payment
            Assert.Equal(3, result);
        }

        [Fact]
        public void CalcDebtInterest_formula()
        {
            var result = _calcD.PaybackDebtByInstallment_formula(2000, 1.0, 1000); // $2000 debt, 1.0% interest, $1000 monthly payment
            Assert.Equal(3, result);
        }

        [Fact]
        public void CalcDebtInterest_Larger_Loop()
        {
            var result = _calcD.PaybackDebtByInstallment(12421000, 0.05, 16584); // $2421000 debt, 0.6% interest, $6584 monthly payment
            Assert.Equal(939, result);
        }

        [Fact]
        public void CalcDebtInterest_Larger_formula()
        {
            var result = _calcD.PaybackDebtByInstallment_formula(12421000, 0.05, 16584); // $24000 debt, 1.6% interest, $780 monthly payment
            Assert.Equal(939, result);
        }
    }
}
