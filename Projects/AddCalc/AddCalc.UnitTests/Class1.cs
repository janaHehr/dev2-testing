using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AddCalc.UnitTests
{
    public class AddCalcTests
    {

        public AddCalcTests()
        {
            
        }

        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(5, 5, 10)]
        [InlineData(5, -5, 0)]
        [InlineData(4, 2, 6)]
        public void AddShouldNumbersToASumCalcTest(int value1, int value2, int expectedResult)
        {
            var calculator = new Calculator();
            calculator.Sum(value1, value2).ShouldBe(expectedResult);
        }

        [Fact]
        public void AddShouldThreeAndFiveToASumCalcTest()
        {
            var calculator = new Calculator();
            calculator.Sum(3, 5).ShouldBe(8);
        }
    }

    public class Calculator
    {
        public int Sum(int i, int i1)
        {
            return i + i1;
        }
    }
}
