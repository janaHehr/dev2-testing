using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;


namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        private readonly FizzBuzz _fizzBuzz;
        private FizzRules _fizzRules;
        private IFizzRules _fizzRulesMock;

        public FizzBuzzTests()
        {

            Debug.WriteLine("ctor called.");
            _fizzRules = new FizzRules();
            _fizzRulesMock = Substitute.For<IFizzRules>();
            _fizzBuzz = new FizzBuzz(_fizzRulesMock);
        }

        //[Fact]
        //public void CompleteFizzBuzz_should_return_elements()
        //{
        //    _fizzBuzz.CompleteFizzBuzz().Count(x => x == "Fizz").ShouldBe(27);
        //    _fizzBuzz.CompleteFizzBuzz().Count(x => x == "Buzz").ShouldBe(14);
        //    _fizzBuzz.CompleteFizzBuzz().Count(x => x == "FizzBuzz").ShouldBe(6);
        //}
        
        [Fact]
        public void DivideByThreeShouldSayFizz()
        {
            var list = Enumerable.Range(1, 100).Where(x => x % 3 == 0 && x % 5 != 0);

            foreach (var i in list)
            {
                _fizzRules.Say(i).ShouldBe("Fizz");
            }
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        public void DivideByFiveShouldSayBuzz(int input)
        {
            _fizzRules.Say(input).ShouldBe("Buzz");
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        public void DivideByThreeAndFiveShouldSayFizzBuzz(int input)
        {
            _fizzRules.Say(input).ShouldBe("FizzBuzz");
        }

        [Theory]
        [InlineData(17)]
        [InlineData(19)]

        public void NotDivideByThreeAndFiveShouldSayInputValue(int input)
        {
            _fizzRules.Say(input).ShouldBe(input.ToString());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(101)]
        public void InputNotBetweenOneAndHundredShouldThrowException(int input)
        {
            Should.Throw<ArgumentOutOfRangeException>(() => _fizzRules.Say(input));
        }

        [Fact]
        public void OutputFromOneToHundredShouldContainsHundredElements()
        {
            var actualResult = _fizzBuzz.CompleteFizzBuzz();

            actualResult.ShouldNotBeNull();
            actualResult.Count().ShouldBe(100);

            _fizzRulesMock.Received(100).Say(Arg.Any<int>());

        }
    }
}
