using System;
using System.Globalization;
using System.Windows.Forms;
using Calculator;
using Calculator.Interfaces;
using NUnit.Extensions.Forms;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UnitTesting
{
    [Binding]
    public class IntegrationTestsSteps
    {
        private CalculatorForm _form;
        private TextBoxTester _a;
        private TextBoxTester _b;
        private TextBoxTester _message;

        [Given(@"init calculator")]
        public void GivenInitCalculator()
        {
            _form = new CalculatorForm(null);
            _form.Show();
            _a = new TextBoxTester("tbA", _form);
            _b = new TextBoxTester("tbB", _form);
            _message = new TextBoxTester("tbMessage", _form);
        }

        [Given(@"A is (.*)")]
        public void GivenTheFirstNumberIs(string p0)
        {
            _a["Text"] = p0;
        }

        [Given(@"B is (.*)")]
        public void GivenTheSecondNumberIs(string p0)
        {
            _b["Text"] = p0;
        }

        [When(@"click to sum")]
        public void WhenClickToSum()
        {
            string button = "btSum";
            var okButton = new ButtonTester(button);
            okButton.Click();
        }

        [When(@"click to minus")]
        public void WhenClicTokMinus()
        {
            string button = "btSubstract";
            var okButton = new ButtonTester(button);
            okButton.Click();
        }

        [When(@"click to multiply")]
        public void WhenClickToMultiply()
        {
            string button = "btMultiply";
            var okButton = new ButtonTester(button);
            okButton.Click();
        }

        [When(@"click to division")]
        public void WhenClickToDivision()
        {
            string button = "btDevide";
            var okButton = new ButtonTester(button);
            okButton.Click();
        }

        [Then(@"result is (.*)")]
        public void ThenReultIs(string p0)
        {
            Assert.AreEqual(p0, _message["Text"]);
        }

        [Then(@"close calculator")]
        public void ThenCloseCalculator()
        {
            _form.Close();
        }
    }
}
