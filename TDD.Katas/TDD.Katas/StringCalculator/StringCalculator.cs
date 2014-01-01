using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return expression.Split(',').Select(Int32.Parse);
        }
    }
}
