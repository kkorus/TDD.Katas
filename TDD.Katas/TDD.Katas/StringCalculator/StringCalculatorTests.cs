using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDD.Katas.StringCalculator
{
    public class StringCalculatorTest
    {
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            var sc = CreateCalculator();

            int result = sc.Add("");

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

        [Test]
        public void Add_MultipleNumbers_SumsThemUp()
        {
            var sc = CreateCalculator();

            int result = sc.Add("1,2");
            
            Assert.AreEqual(3, result);


        }
        private static StringCalculator CreateCalculator()
        {
            return new StringCalculator();
        }
    }
}
