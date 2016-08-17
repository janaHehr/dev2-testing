using Shouldly;
using Xunit;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(8, "8")]

        [InlineData(3, "Fizz")]
        [InlineData(99, "Fizz")]
        [InlineData(66, "Fizz")]

        [InlineData(5, "Buzz")]
        [InlineData(55, "Buzz")]
        [InlineData(35, "Buzz")]

        [InlineData(15, "FizzBuzz")]
        [InlineData(45, "FizzBuzz")]
        [InlineData(60, "FizzBuzz")]

        [InlineData(100, "Buzz")]
        public void Should_(int number, string expected)
        {
            var fizzBuzz = new FizzBuzz();
            var completeFizzBuzz = fizzBuzz.Run();

            completeFizzBuzz.ShouldNotBeNull();
            completeFizzBuzz.Length.ShouldBe(100);

            completeFizzBuzz[number - 1].ShouldBe(expected);
        }
    }
}
