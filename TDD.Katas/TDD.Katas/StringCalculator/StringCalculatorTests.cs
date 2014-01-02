using NUnit.Framework;

namespace TDD.Katas.StringCalculator
{
    public class StringCalculatorTest
    {
        [TestCase("")]
        [TestCase(null)]
        public void Add_EmptyString_ReturnsZero(string numbers)
        {
            var sc = CreateCalculator();

            int result = sc.Add(numbers);

            Assert.That(result, Is.EqualTo(0));
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void Add_SingleNumber_ReturnsThatNumber(string numbers, int exptected)
        {
            var sc = CreateCalculator();

            var result = sc.Add(numbers);

            Assert.AreEqual(exptected, result);
        }

        [TestCase("0,0", 0)]
        [TestCase("1,2", 3)]
        [TestCase("2,3", 5)]
        [TestCase("3,4", 7)]
        public void Add_TwoCommaDelimitedNumbers_SumsThemUp(string numbers, int expected)
        {
            var sc = CreateCalculator();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1,2,3", 6)]
        [TestCase("3,4,5", 12)]
        public void Add_MultipleCommaDelimitedNumbers_SumsThemUp(string numbers, int expected)
        {
            var sc = CreateCalculator();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1\n2\n3", 6)]
        [TestCase("0\n1\n2", 3)]
        public void Add_MultipleNewLineDelimitedNumbers_SumsThemUp(string numbers, int expected)
        {
            var sc = CreateCalculator();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("1,2\n3", 6)]
        public void Add_MultipleCommaAndNewLineDelimitedNumbers_SumsThemUp(string numbers, int expected)
        {
            var sc = CreateCalculator();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [TestCase("//;\n1;2", 3)]
        public void Add_MultipleNumbersWithCustomDelimiter_SumsThemUp(string numbers, int expected)
        {
            var sc = CreateCalculator();

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result); 
        }

        private static StringCalculator CreateCalculator()
        {
            return new StringCalculator();
        }
    }
}
