namespace ABC.Testing
{
    public class MathLibraryTests
    {
        // The math class is used across multiple tests, so I made it at the class level instead of the method level.
        private readonly Calculator.Math _calcM = new Calculator.Math();

        [Fact]
        public void CalcSumOfList()
        {
            List<double> numbers = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
            double result = _calcM.SumOf(numbers);
            Assert.Equal(15, result);
        }

        [Fact]
        public void SubtractTwoNumbers()
        {
            double res = _calcM.Subtract(10, 5);
            Assert.Equal(5, res);
        }

        [Fact]
        public void SubtractWithListOfNumbers()
        {
            List<double> list = new List<double> { 10, 5, 3, 2 }; // -20
            double res = _calcM.SubtractWithList(22, list);
            Assert.Equal(2, res);
        }

        [Fact]
        public void CalcMonthToYear()
        {
            // 16 months = 1 year and 4 months
            (int, int) result = _calcM.MonthToYear(16);
            Assert.Equal(1, result.Item1);
            Assert.Equal(4, result.Item2);
        }
    }
}