﻿using System;
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

        class PlusPanic : Exception { }
        class MinusPanic : Exception { }
        class MultiplyPanic : Exception { }
        class DividePanic : Exception { }

        private class TestCalculatorPresenter : ICalculatorPresenter
        {
            public void OnDivideClicked()
            {
                throw new DividePanic();
            }

            public void OnMinusClicked()
            {
                throw new MinusPanic();
            }

            public void OnMultiplyClicked()
            {
                throw new MultiplyPanic();
            }

            public void OnPlusClicked()
            {
                throw new PlusPanic();
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

        [TearDown]
        public void Setdown()
        {
            _form.Close();
        }

        [TestCase("", "")]
        [TestCase("1", "")]
        [TestCase("", "1")]
        [TestCase("1", "1")]
        public void TestBtSum(string a, string b)
        {
            _a["Text"] = a;
            _b["Text"] = b;
            var button = "btSum";
            var okButton = new ButtonTester(button);

            try
            {
                okButton.Click();
                Assert.Fail();
            }
            catch(Exception e)
            {
                Assert.IsTrue(e?.InnerException is PlusPanic);
            }
        }

        [TestCase("", "")]
        [TestCase("1", "")]
        [TestCase("", "1")]
        [TestCase("1", "1")]
        public void TestBtMultiply(string a, string b)
        {
            _a["Text"] = a;
            _b["Text"] = b;
            var button = "btMultiply";
            var okButton = new ButtonTester(button);

            try
            {
                okButton.Click();
                Assert.Fail();
            }
            catch(Exception e)
            {
                Assert.IsTrue(e?.InnerException is MultiplyPanic);
            }
        }

        [TestCase("", "")]
        [TestCase("1", "")]
        [TestCase("", "1")]
        [TestCase("1", "1")]
        public void TestBtbtDevide(string a, string b)
        {
            _a["Text"] = a;
            _b["Text"] = b;
            var button = "btDevide";
            var okButton = new ButtonTester(button);

            try
            {
                okButton.Click();
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e?.InnerException is DividePanic);
            }
        }

        [TestCase("", "")]
        [TestCase("1", "")]
        [TestCase("", "1")]
        [TestCase("1", "1")]
        public void TestBtSubstract(string a, string b)
        {
            _a["Text"] = a;
            _b["Text"] = b;
            var button = "btSubstract";
            var okButton = new ButtonTester(button);

            try
            {
                okButton.Click();
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.IsTrue(e?.InnerException is MinusPanic);
            }
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
