using System;
using System.Globalization;
using System.Windows.Forms;
using Calculator;
using Calculator.Interfaces;
using NUnit.Extensions.Forms;
using NUnit.Framework;


namespace UnitTesting
{
    public class UnitTestCalculatorView
    {
        private CalculatorForm _form;
        private TextBoxTester _a;
        private TextBoxTester _b;
        private TextBoxTester _message;

        private class TestCalculatorPresenter : ICalculatorPresenter
        {
            public void OnDivideClicked()
            {
                throw new Exception("/");
            }

            public void OnMinusClicked()
            {
                throw new Exception("-");
            }

            public void OnMultiplyClicked()
            {
                throw new Exception("*");
            }

            public void OnPlusClicked()
            {
                throw new Exception("+");
            }
        }

        [SetUp]
        public void Setup()
        {
            _form = new CalculatorForm(new TestCalculatorPresenter());            
            _form.Show();
            _a = new TextBoxTester("tbA", _form);
            _b = new TextBoxTester("tbB", _form);            
            _message = new TextBoxTester("tbMessage", _form);
        }

        public void TestBtSum()
        {
            var button = "btSum";
            var message = "+";
            var okButton = new ButtonTester(button);

            var eMes = Assert.Catch(() => okButton.Click())?.InnerException?.Message;

            Assert.AreEqual(eMes, message);
        }

        public void TestBtMultiply()
        {
            var button = "btMultiply";
            var message = "*";
            var okButton = new ButtonTester(button);

            var eMes = Assert.Catch(() => okButton.Click())?.InnerException?.Message;

            Assert.AreEqual(eMes, message);
        }

        public void TestBtbtDevide()
        {
            var button = "btbtDevide";
            var message = "/";
            var okButton = new ButtonTester(button);

            var eMes = Assert.Catch(() => okButton.Click())?.InnerException?.Message;

            Assert.AreEqual(eMes, message);
        }

        public void TestBtSubstract()
        {
            var button = "btSubstract";
            var message = "-";
            var okButton = new ButtonTester(button);

            var eMes = Assert.Catch(() => okButton.Click())?.InnerException?.Message;

            Assert.AreEqual(eMes, message);
        }

        [TestCase("1")]
        public void TestGetFirstArgumentAsString(string a)
        {
            _a["Text"] = a;

            var result = _form.GetFirstArgumentAsString();

            Assert.AreEqual(a, result);
        }

        [TestCase("1")]
        public void TestGetSecondArgumentAsString(string b)
        {
            _b["Text"] = b;

            var result = _form.GetSecondArgumentAsString();

            Assert.AreEqual(b, result);
        }

        [TestCase(1.1)]
        public void TestPrintResult(double result)
        {
            _form.PrintResult(result);

            Assert.AreEqual(_message["Text"], result.ToString(CultureInfo.InvariantCulture));
        }

        [TestCase("Empty parameter")]
        public void TestDisplayError(string message)
        {
            _form.DisplayError(message);

            Assert.AreEqual(_message["Text"], message);
        }
    }
}
