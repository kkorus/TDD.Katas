using System.Collections.Generic;
using NSubstitute.Core;

namespace TDD.Katas.FizzBuzz
{
    // Write a program that prints the numbers from 1 to 100. 
    // But for multiples of three print "Fizz"
    // instead of the number and for the multiples of five print "Buzz". 
    // For numbers which are multiples of both three and five print "FizzBuzz".
    public class FizzBuzz
    {
        public string Print(int printTo)
        {
            var result = new List<string>(printTo);

            for (var i = 1; i <= printTo; i++)
            {
                if (IsFizzBuzz(i))
                {
                    result.Add("FizzBuzz");
                }
                else if (IsFizz(i))
                {
                    result.Add("Fizz");
                }
                else if (IsBuzz(i))
                {
                    result.Add("Buzz");
                }
                else
                {
                    result.Add(i.ToString());
                }
            }

            return result.Join(", ");
        }

        private bool IsFizz(int value)
        {
            return value % 3 == 0;
        }

        private bool IsBuzz(int value)
        {
            return value % 5 == 0;
        }

        private bool IsFizzBuzz(int value)
        {
            return IsFizz(value) && IsBuzz(value);
        }
    }
}