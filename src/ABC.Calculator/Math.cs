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

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double SubtractWithList(double input, List<double> numbers)
        {
            double res = input;
            foreach (var number in numbers)
            {
                res -= number;
            }

            return res;
        }

        public (int, int) MonthToYear(int months)
        {
            int years = months / 12;
            int remainingMonths = months % 12;

            return (years, remainingMonths);
        }


    }
}
