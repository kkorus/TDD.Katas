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
            var delimiters = new char[] {',', '\n'}.ToList();

            if (expression.StartsWith("//"))
            {
                var delimiter = expression[2];
                delimiters.Add(delimiter);
            }

            var test = expression.SkipWhile(x => x != '\n');
            return expression.SkipWhile(x => x != '\n').ToString().Split(delimiters.ToArray()).Select(Int32.Parse);
        }
    }
}
