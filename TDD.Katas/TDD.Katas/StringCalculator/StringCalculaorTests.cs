using System;
using FluentAssertions;
using NUnit.Framework;

namespace TDD.Katas.StringCalculator
{
    [TestFixture]
    public class StringCalculaorTests
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void SetUp()
        {
            _stringCalculator = new StringCalculator();
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("  ")]
        public void Add_WhenNumbersAreEmpty_Returns0(string testNumbers)
        {
            // Arrange
            const int expectedResult = 0;

            // Act
            var result = _stringCalculator.Add(testNumbers);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        public void Add_SingleNumbers_ReturnsThatNumber()
        {
            // Arrange
            const int expectedResult = 1;
            string testNumbers = "1";

            // Act
            var result = _stringCalculator.Add(testNumbers);

            // Assert 
            result.Should().Be(expectedResult);
        }

        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        public void Add_MultipleNumbersWithCommaSeperator_ReturnsSumOfNumbers(
            string testNumbers,
            int expectedResult)
        {
            // Arrange

            // Act
            var result = _stringCalculator.Add(testNumbers);

            // Assert
            result.Should().Be(expectedResult);
        }

        [TestCase("1\n2", 3)]
        [TestCase("1\n2\n3", 6)]
        [TestCase("1\n2\n3,4", 10)]
        public void Add_MultipleNumbersWithNewlineSeperator_ReturnsSumOfNumbers(
            string testNumbers,
            int expectedResult)
        {
            // Arrange

            // Act
            var result = _stringCalculator.Add(testNumbers);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        public void Add_MultipleNumbersWithCustomDelimeter_ReturnsSumOfNumbers()
        {
            // Arrange
            var testNumbers = "//;\n1;2";
            const int expectedResult = 3;


            // Act
            var result = _stringCalculator.Add(testNumbers);

            // Assert
            result.Should().Be(expectedResult);
        }


        [TestCase("-1", "Negatives not allowed: -1")]
        [TestCase("-1,-2", "Negatives not allowed: -1, -2")]
        [TestCase("-1,2\n-3", "Negatives not allowed: -1, -3")]
        [TestCase("//;\n-1;-2;-3", "Negatives not allowed: -1, -2, -3")]
        public void Add_NegativeNumberInNumbers_ThrowsExceptionWithMessage(
            string testNumbers,
            string expectedExceptionMessage)
        {
            // Arrange

            // Act
            Action act = () => _stringCalculator.Add(testNumbers);

            // Assert
            act.ShouldThrow<InvalidOperationException>()
                .And.Message.Should().Be(expectedExceptionMessage);
        }

        [TestCase("1, 1001, 10000", 1)]
        [TestCase("1, 2, 3, 1001, 10000", 6)]
        [TestCase("1, 2, 3, 1000, 1001, 10000", 1006)]
        public void Add_NumbersBiggerThan1000AreIgnored_ReturnsSumOfNumbers(
            string testNumbers,
            int expectedSumResult)
        {
            // Arrange

            // Act
            var result = _stringCalculator.Add(testNumbers);

            // Assert
            result.Should().Be(expectedSumResult);
        }
    }
}