using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface IFizzRules
    {
        string Say(int input);
    }

    public class FizzRules : IFizzRules
    {
        public string Say(int input)
        {
            if (input < 1 || input > 100)
                throw new ArgumentOutOfRangeException();

            if (input % 3 == 0 && input % 5 == 0)
                return "FizzBuzz";

            if (input % 3 == 0)
                return "Fizz";

            return input % 5 == 0 ? "Buzz" : input.ToString();
        }
    }

    public class FizzBuzz
    {
        private readonly IFizzRules _fizzRules;

        public FizzBuzz(IFizzRules fizzRules)
        {
            _fizzRules = fizzRules;
        }

        public IEnumerable<string> CompleteFizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                yield return _fizzRules.Say(i);
            }
        }

    }
}
