namespace ABC.Calculator
{
    public class Math
    {
        public double SumOf(List<double> numbers)
        {
            double sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        // Converters

        public (int, int) MonthToYear(int months)
        {
            int years = months / 12; // C# rounds down. 16 / 12 = 1
            int remainder = months % 12;

            return (years, remainder);
        }
    }
}
