using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalc
{
    public class Calculator
    {
        public static decimal Calc(string input)
        {
            int opIndex;
            char[] operators = { '+', '-', '*', '/', '^' };
            foreach (char oper in operators)
            {
                opIndex = input.IndexOf(oper);
                if (opIndex != -1)
                    return OperatorCalc(input, opIndex);
            }
            return decimal.Parse(input);
        }
        private static decimal OperatorCalc(string input, int opInd)
        {
            switch (input[opInd])
            {
                case '^':
                    return (decimal)Math.Pow((double)Calc(input.Substring(0, opInd)), (double)Calc(input.Substring(opInd + 1)));
                //return Calc(input.Substring(0, opInd)) * Calc(input.Substring(opInd + 1));
                case '*':
                    return Calc(input.Substring(0, opInd)) * Calc(input.Substring(opInd + 1));
                case '/':
                    return Calc(input.Substring(0, opInd)) / Calc(input.Substring(opInd + 1));
                case '+':
                    return Calc(input.Substring(0, opInd)) + Calc(input.Substring(opInd + 1));
                case '-':   // Horray for power rules...
                    string opers = "*/";   // Operations that works well with - as a sign.
                    if (opInd == 0 || opInd > 1 && opers.Contains(input[opInd - 1]))
                        return -Calc(input.Substring(0, opInd) + input.Substring(opInd + 1));
                    else if (opInd > 1 && input[opInd - 1].Equals('^'))
                        return 1 / Calc(input.Substring(0, opInd) + input.Substring(opInd + 1));
                    return Calc(input.Substring(0, opInd)) - Calc(input.Substring(opInd + 1));
                default:
                    throw new Exception("Invalid Operation");
            }
        }
    }
}
