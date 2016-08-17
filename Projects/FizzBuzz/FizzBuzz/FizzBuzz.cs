using System.Linq;

namespace FizzBuzz
{
    public class FizzBuzz
    {
        public string[] Run()
        {
            var enumerable = Enumerable.Range(1, 100).ToList();

            var results = new string[enumerable.Count];
            for (var i = 1; i <= results.Length; i++)
            {
                results[i - 1] = ApplyFizzBuzzRules(i);
            }

            return results;
        }

        private string ApplyFizzBuzzRules(int input)
        {
            if (input % 3 == 0 && input % 5 == 0)
            {
                return "FizzBuzz";
            }

            if (input % 3 == 0)
            {
                return "Fizz";
            }

            if (input % 5 == 0)
            {
                return "Buzz";
            }

            return input.ToString();
        }
    }
}