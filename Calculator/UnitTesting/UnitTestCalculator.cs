using System;
using NUnit.Framework;
using Calculator.Interfaces;

namespace UnitTesting
{
    public class UnitTestCalcucator
    {
        private ICalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator.Calculator();
        }

        [TestCase(1, 2, 3)]
        [TestCase(1 / 3.0, 1 / 3.0, 2 / 3.0)]
        [TestCase(double.MinValue, double.MinValue, 2 * double.MinValue)]
        [TestCase(double.MaxValue, double.MaxValue, 2 * double.MaxValue)]
        public void TestSum(double a, double b, double c)
        {
            var ans = _calculator.Sum(a, b);

            Assert.AreEqual(ans, c);
        }

        [TestCase(1, 2, -1)]
        [TestCase(2 / 3.0, 1 / 3.0, 1 / 3.0)]
        [TestCase(double.MinValue, double.MinValue, 0)]
        [TestCase(double.MaxValue, double.MaxValue, 0)]
        public void TestSubstract(double a, double b, double c)
        {
            var ans = _calculator.Subtract(a, b);

            Assert.AreEqual(ans, c);
        }

        [TestCase(1, 2, 2)]
        [TestCase(2 / 3.0, 1 / 3.0, 2 / 9.0)]
        [TestCase(double.MinValue, double.MinValue, double.MinValue * double.MinValue)]
        [TestCase(double.MaxValue, double.MaxValue, double.MaxValue * double.MaxValue)]
        public void TestMultiply(double a, double b, double c)
        {
            var ans = _calculator.Multiply(a, b);

            Assert.AreEqual(ans, c);
        }

        [TestCase(1, 2, 0.5)]
        [TestCase(2 / 3.0, 1 / 3.0, 2)]
        [TestCase(double.MinValue, double.MinValue, 1)]
        [TestCase(double.MaxValue, double.MaxValue, 1)]
        public void TestDivide(double a, double b, double c)
        {
            var ans = _calculator.Divide(a, b);

            Assert.AreEqual(ans, c);
        }

        [TestCase(1, 0)]
        public void TestDivideException(double a, double b)
        {
            Assert.Throws<ArithmeticException>(() => _calculator.Divide(a, b));
        }
    }
}