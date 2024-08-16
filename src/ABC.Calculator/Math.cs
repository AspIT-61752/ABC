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
    }
}
