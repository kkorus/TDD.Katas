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
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            return int.Parse(numbers);
        }
    }
}
