using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SimpleCalc
{
    [TestFixture]
    internal class CalcTests
    {
        calcForm form;
        [OneTimeSetUp]
        public void SetupFix()
        {
            form = new calcForm();
        }
        [Test]
        [TestCase("3+2", 5)]
        [TestCase("3*2", 6)]
        [TestCase("3-2", 1)]
        [TestCase("3/2", 1.5)]
        [TestCase("12*12", 144)]
        [TestCase("144/12", 12)]
        [TestCase("144-12", 132)]
        [TestCase("144+12", 156)]
        public void SingleOper(string input, decimal expected)
        {
            Assert.That(Calculator.Calc(input), Is.EqualTo(expected));
        }
        [Test]
        [Ignore("Testing ignore")]
        public void Ignorance()
        {

        }
        [Test]
        [TestCase("1+1^10",2)]
        [TestCase("1+2^10", 1025)]
        [TestCase("1+2+3+4+5+6+7+8+9+10", 55)]
        [TestCase("5+2/10", 5.2)]
        [TestCase("5+5*5+5*5", 55)]
        [TestCase("1+2^5*2^5", 1025)]
        [TestCase("1024/2^5", 32)]
        public void MultiOper(string input, decimal expected)
        {
            Assert.That(Calculator.Calc(input), Is.EqualTo(expected));
        }
        [Test]
        [Ignore("Trigger to test failure")]
        public void AlwaysFail()
        {
            Assert.Fail();
        }
        [Test]
        [TestCase("5/0")]
        [TestCase("5/0*0")]
        [TestCase("3/0.0")]
        [TestCase("3+2/0+1")]
        public void DivideByZeroTests(string input)
        {
            Errors(input, "Attempted to divide by zero.");
        }


        [Test]
        [TestCase("4+(2+1)")]   // barracks NOT implemented. Remove or Ignore when it is.
        [TestCase("1+2+")]
        [TestCase("4*4+2*")]
        [TestCase("43*abc*23")]
        [TestCase("a")]
        public void IncorrectFormating(string input)
        {
            Errors(input, "Input string was not in a correct format.");
        }
        private void Errors(string input, string errorMsg)
        {
            try
            {
                Calculator.Calc(input);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo(errorMsg));
            }
        }
    }
}
