using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Nunit
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_ReturnsCorrectSum()
        {
            var result = _calculator.Add(2, 3);
            Assert.Equals(5, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }
    }
}
