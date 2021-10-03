using System;
using System.Globalization;
using Calculator;
using NUnit.Framework;
using Calculator.Interfaces;

namespace UnitTesting
{
    class UnitTestCalculatroPresenter
    {
        class TestCalculatorView : ICalculatorView
        {
            public string Result { get; set; }
            public string Error { get; set; }
            public string FirstArgument { get; set; }
            public string SecondArgument { get; set; }

            public void PrintResult(double result)
            {
                Result = result.ToString(CultureInfo.InvariantCulture);
            }

            public void DisplayError(string message)
            {
                Error = message;
            }

            public string GetFirstArgumentAsString()
            {
                return FirstArgument;
            }

            public string GetSecondArgumentAsString()
            {
                return SecondArgument;
            }
        }

        private ICalculatorPresenter _calculatorPresenter;
        private TestCalculatorView _calculatorView;

        [SetUp]
        public void Setup()
        {
            _calculatorView = new TestCalculatorView();
            _calculatorPresenter = new CalculatorPresenter(_calculatorView, new Calculator.Calculator());
        }

        [TestCase("12", "13", "25")]
        [TestCase("x", "y", "0")]
        [TestCase("x", "1", "1")]
        [TestCase("1", "y", "1")]
        public void TestOnPlusClicked(string a, string b, string c)
        {
            _calculatorView.FirstArgument = a;
            _calculatorView.SecondArgument = b;

            _calculatorPresenter.OnPlusClicked();

            Assert.AreEqual(_calculatorView.Result, c);
        }

        [TestCase("12", "13", "-1")]
        [TestCase("x", "y", "0")]
        [TestCase("x", "1", "-1")]
        [TestCase("1", "y", "1")]
        public void TestOnMinusClicked(string a, string b, string c)
        {
            _calculatorView.FirstArgument = a;
            _calculatorView.SecondArgument = b;

            _calculatorPresenter.OnMinusClicked();

            Assert.AreEqual(_calculatorView.Result, c);
        }

        [TestCase("12", "13", "156")]
        [TestCase("x", "y", "0")]
        [TestCase("x", "1", "0")]
        [TestCase("1", "y", "0")]
        public void TestOnMultiplyClicked(string a, string b, string c)
        {
            _calculatorView.FirstArgument = a;
            _calculatorView.SecondArgument = b;

            _calculatorPresenter.OnMultiplyClicked();

            Assert.AreEqual(_calculatorView.Result, c);
        }

        [TestCase("12", "4", "3")]
        [TestCase("x", "y", null)]
        [TestCase("x", "1", "0")]
        [TestCase("1", "y", null)]
        public void TestOnDivideClicked(string a, string b, string c)
        {
            _calculatorView.FirstArgument = a;
            _calculatorView.SecondArgument = b;

            _calculatorPresenter.OnDivideClicked();

            Assert.AreEqual(_calculatorView.Result, c);
        }

        [TestCase("1", "", "Empty parametr")]
        [TestCase("", "1", "Empty parametr")]
        [TestCase("", "", "Empty parametr")]
        public void TestOnPlusClickedThrows(string a, string b, string c)
        {
            _calculatorView.FirstArgument = a;
            _calculatorView.SecondArgument = b;

            _calculatorPresenter.OnPlusClicked();

            Assert.AreEqual(_calculatorView.Error, c);
        }

        [TestCase("1", "", "Empty parametr")]
        [TestCase("", "1", "Empty parametr")]
        [TestCase("", "", "Empty parametr")]
        public void TestOnMinusClickedThrows(string a, string b, string c)
        {
            _calculatorView.FirstArgument = a;
            _calculatorView.SecondArgument = b;

            _calculatorPresenter.OnMinusClicked();

            Assert.AreEqual(_calculatorView.Error, c);
        }

        [TestCase("1", "", "Empty parametr")]
        [TestCase("", "1", "Empty parametr")]
        [TestCase("", "", "Empty parametr")]
        public void TestOnMultiplyClickedThrows(string a, string b, string c)
        {
            _calculatorView.FirstArgument = a;
            _calculatorView.SecondArgument = b;

            _calculatorPresenter.OnMultiplyClicked();

            Assert.AreEqual(_calculatorView.Error, c);
        }

        [TestCase("12", "0", "Division by zero")]
        [TestCase("1", "", "Empty parametr")]
        [TestCase("", "1", "Empty parametr")]
        [TestCase("", "", "Empty parametr")]
        public void TestOnDivideClickedThrows(string a, string b, string c)
        {
            _calculatorView.FirstArgument = a;
            _calculatorView.SecondArgument = b;

            _calculatorPresenter.OnDivideClicked();

            Assert.AreEqual(_calculatorView.Error, c);
        }
    }
}
