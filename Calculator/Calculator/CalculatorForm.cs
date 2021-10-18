using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.Interfaces;

namespace Calculator
{
    public partial class CalculatorForm : Form, ICalculatorView
    {
        private readonly ICalculator _calculator;
        private readonly ICalculatorPresenter _calculatorPresenter;

        public CalculatorForm(ICalculatorPresenter calculatorPresenter)
        {
            InitializeComponent();
            tbMessage.Enabled = false;
            _calculator = new Calculator();
            _calculatorPresenter = calculatorPresenter ?? new CalculatorPresenter(this, _calculator);
        }

        public void OnMultiplyClicked(object sender, EventArgs e)
        {
            _calculatorPresenter.OnMultiplyClicked();
        }

        public void OnDivideClicked(object sender, EventArgs e)
        {
            _calculatorPresenter.OnDivideClicked();
        }

        public void OnMinusClicked(object sender, EventArgs e)
        {
            _calculatorPresenter.OnMinusClicked();
        }

        public void OnPlusClicked(object sender, EventArgs e)
        {
            _calculatorPresenter.OnPlusClicked();
        }

        public void PrintResult(double result)
        {
            tbMessage.Text = result.ToString(CultureInfo.InvariantCulture);
        }

        public void DisplayError(string message)
        {
            tbMessage.Text = message;
        }

        public string GetFirstArgumentAsString()
        {
            return tbA.Text;
        }

        public string GetSecondArgumentAsString()
        {
            return tbB.Text;
        }
    }
}
