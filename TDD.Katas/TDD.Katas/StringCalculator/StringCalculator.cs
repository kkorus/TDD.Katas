using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD.Katas.StringCalculator
{
    /// <summary>
    /// http://osherove.com/tdd-kata-1/
    /// </summary>
    public class StringCalculator
    {
        private readonly List<char> _delimeters = new List<char>(3) { ',', '\n' };

        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            if (numbers.StartsWith("//"))
            {
                _delimeters.Add(numbers[2]);
                numbers = numbers.Substring(4);
            }

            return ParseNumbersToPositiveIntegers(numbers).Sum();
        }

        public IList<int> ParseNumbersToPositiveIntegers(string numbers)
        {
            var parsedNumbers = numbers
                .Split(_delimeters.ToArray())
                .Select(int.Parse)
                .Where(x => x <= 1000)
                .ToList();

            var negatives = parsedNumbers.Where(x => x < 0).ToArray();
            if (negatives.Any())
            {
                var message = $"Negatives not allowed: {string.Join(", ", negatives)}";
                throw new InvalidOperationException(message);
            }

            return parsedNumbers;
        }
    }
}