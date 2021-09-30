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
    public partial class CalculatorForm : Form, ICalculatorPresenter, ICalculatorView
    {
        private readonly Calculator _calculator;

        public CalculatorForm()
        {
            InitializeComponent();
            tbMessage.Enabled = false;
            _calculator = new Calculator();
        }

        public void OnMultiplyClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(GetFirstArgumentAsString()) ||
                    string.IsNullOrEmpty(GetSecondArgumentAsString()))
                {
                    throw new EmptyParametrException();
                }
                double.TryParse(GetFirstArgumentAsString(), out double a);
                double.TryParse(GetSecondArgumentAsString(), out double b);
                PrintResult(_calculator.Multiply(a, b));
            }
            catch(Exception exception)
            {
                DisplayError(exception.Message);
            }
        }

        public void OnDivideClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(GetFirstArgumentAsString()) ||
                    string.IsNullOrEmpty(GetSecondArgumentAsString()))
                {
                    throw new EmptyParametrException();
                }
                double.TryParse(GetFirstArgumentAsString(), out double a);
                double.TryParse(GetSecondArgumentAsString(), out double b);
                PrintResult(_calculator.Divide(a, b));
            }
            catch (Exception exception)
            {
                DisplayError(exception.Message);
            }
        }

        public void OnMinusClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(GetFirstArgumentAsString()) ||
                    string.IsNullOrEmpty(GetSecondArgumentAsString()))
                {
                    throw new EmptyParametrException();
                }
                double.TryParse(GetFirstArgumentAsString(), out double a);
                double.TryParse(GetSecondArgumentAsString(), out double b);
                PrintResult(_calculator.Subtract(a, b));
            }
            catch (Exception exception)
            {
                DisplayError(exception.Message);
            }
        }

        public void OnPlusClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(GetFirstArgumentAsString()) ||
                    string.IsNullOrEmpty(GetSecondArgumentAsString()))
                {
                    throw new EmptyParametrException();
                }
                double.TryParse(GetFirstArgumentAsString(), out double a);
                double.TryParse(GetSecondArgumentAsString(), out double b);
                PrintResult(_calculator.Sum(a, b));
            }
            catch (Exception exception)
            {
                DisplayError(exception.Message);
            }
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
