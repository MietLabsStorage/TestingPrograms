using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Interfaces;

namespace Calculator
{
    public class CalculatorPresenter: ICalculatorPresenter
    {
        private ICalculatorView _calculatorView;
        private ICalculator _calculator;

        public CalculatorPresenter(
            ICalculatorView calculatorView,
            ICalculator calculator
            )
        {
            _calculatorView = calculatorView;
            _calculator = calculator;
        }

        public void OnMultiplyClicked()
        {
            try
            {
                if (string.IsNullOrEmpty(_calculatorView.GetFirstArgumentAsString()) ||
                    string.IsNullOrEmpty(_calculatorView.GetSecondArgumentAsString()))
                {
                    throw new EmptyParametrException();
                }
                double.TryParse(_calculatorView.GetFirstArgumentAsString(), out double a);
                double.TryParse(_calculatorView.GetSecondArgumentAsString(), out double b);
                _calculatorView.PrintResult(_calculator.Multiply(a, b));
            }
            catch (Exception exception)
            {
                _calculatorView.DisplayError(exception.Message);
            }
        }

        public void OnDivideClicked()
        {
            try
            {
                if (string.IsNullOrEmpty(_calculatorView.GetFirstArgumentAsString()) ||
                    string.IsNullOrEmpty(_calculatorView.GetSecondArgumentAsString()))
                {
                    throw new EmptyParametrException();
                }
                double.TryParse(_calculatorView.GetFirstArgumentAsString(), out double a);
                double.TryParse(_calculatorView.GetSecondArgumentAsString(), out double b);
                _calculatorView.PrintResult(_calculator.Divide(a, b));
            }
            catch (Exception exception)
            {
                _calculatorView.DisplayError(exception.Message);
            }
        }

        public void OnMinusClicked()
        {
            try
            {
                if (string.IsNullOrEmpty(_calculatorView.GetFirstArgumentAsString()) ||
                    string.IsNullOrEmpty(_calculatorView.GetSecondArgumentAsString()))
                {
                    throw new EmptyParametrException();
                }
                double.TryParse(_calculatorView.GetFirstArgumentAsString(), out double a);
                double.TryParse(_calculatorView.GetSecondArgumentAsString(), out double b);
                _calculatorView.PrintResult(_calculator.Subtract(a, b));
            }
            catch (Exception exception)
            {
                _calculatorView.DisplayError(exception.Message);
            }
        }

        public void OnPlusClicked()
        {
            try
            {
                if (string.IsNullOrEmpty(_calculatorView.GetFirstArgumentAsString()) ||
                    string.IsNullOrEmpty(_calculatorView.GetSecondArgumentAsString()))
                {
                    throw new EmptyParametrException();
                }
                double.TryParse(_calculatorView.GetFirstArgumentAsString(), out double a);
                double.TryParse(_calculatorView.GetSecondArgumentAsString(), out double b);
                _calculatorView.PrintResult(_calculator.Sum(a, b));
            }
            catch (Exception exception)
            {
                _calculatorView.DisplayError(exception.Message);
            }
        }
    }
}
