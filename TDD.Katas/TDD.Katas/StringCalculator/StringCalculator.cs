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
        public int Add(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return 0;
            }

            var args = GetIntArrayFromExpression(expression);
            return args.Sum();
        }

        private IEnumerable<int> GetIntArrayFromExpression(string expression)
        {
            var delimiters = new char[] {',', '\n'};

            if (expression.StartsWith("//"))
            {
                //var delimiter = expression.Skip(2).TakeWhile(x => x == Environment.NewLine);
            }

            return expression.Split(delimiters).Select(Int32.Parse);
        }
    }
}
