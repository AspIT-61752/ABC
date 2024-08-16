namespace ABC.Calculator
{
    public class Math
    {
        public int SumOf(List<int> numbers)
        {
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }
    }
}
