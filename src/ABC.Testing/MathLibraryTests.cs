namespace ABC.Testing
{
    public class MathLibraryTests
    {
        [Fact]
        public void CalcSumOfList()
        {
            Calculator.Math math = new Calculator.Math();
            List<double> numbers = new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 };
            double result = math.SumOf(numbers);

            Assert.NotNull(result);
            Assert.Equal(15, result);
        }
    }
}