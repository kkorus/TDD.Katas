using FluentAssertions;
using NUnit.Framework;

namespace TDD.Katas.FizzBuzz
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [Test]
        public void Print_To2_PrintsResultWitoutFizzAndBuzz()
        {
            // Arrange
            const string expectedResult = "1, 2";
            const int printTo = 2;

            // Act
            var result = _fizzBuzz.Print(printTo);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        public void Print_To3_PrintsResultWithFizz()
        {
            // Arrange
            const string expectedResult = "1, 2, Fizz";
            const int printTo = 3;

            // Act
            var result = _fizzBuzz.Print(printTo);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        public void Print_To5_PrintsResultWithFizzAndBuzz()
        {
            // Arrange
            const string expectedResult = "1, 2, Fizz, 4, Buzz";
            const int printTo = 5;

            // Act
            var result = _fizzBuzz.Print(printTo);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        public void Print_To15_PrintsResultWithFizzAndBuzzAndFizzBuzz()
        {
            // Arrange
            const string expectedResult = "1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, FizzBuzz";
            const int printTo = 15;

            // Act
            var result = _fizzBuzz.Print(printTo);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}