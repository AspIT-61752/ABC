namespace ABC.Testing
{
    public class MathLibraryTests
    {
        [Fact]
        public void CalcSumOfList()
        {
            Calculator.Math math = new Calculator.Math();
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            int result = math.SumOf(numbers);

            Assert.NotNull(result);
            Assert.Equal(15, result);
        }
    }
}