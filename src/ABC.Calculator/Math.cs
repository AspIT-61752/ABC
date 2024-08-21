namespace ABC.Calculator
{
    public class Math
    {
        /// <summary>
        /// Calculate the sum of a list of numbers
        /// </summary>
        /// <param name="numbers">The list of numbers</param>
        /// <returns>The sum of the numbers</returns>
        public double SumOf(List<double> numbers)
        {
            double sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        /// <summary>
        /// Basic subtraction
        /// </summary>
        /// <param name="a">The first number, the minuend</param>
        /// <param name="b">The second number, the subtrahend</param>
        /// <returns>The result of the subtraction</returns>
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Subtract a list of numbers from the input
        /// </summary>
        /// <param name="input">The input number</param>
        /// <param name="numbers">The list of numbers to subtract</param>
        /// <returns>A double with the result of the subtraction</returns>
        public double SubtractWithList(double input, List<double> numbers)
        {
            double res = input;
            foreach (var number in numbers)
            {
                res -= number;
            }

            return res;
        }

        /// <summary>
        /// Calculate the number of years and months from the number of months
        /// </summary>
        /// <param name="months">The number of months</param>
        /// <returns>A tuple with the number of years and the remaining months</returns>
        public (int, int) MonthToYear(int months)
        {
            int years = months / 12;
            int remainingMonths = months % 12;

            return (years, remainingMonths);
        }


    }
}
