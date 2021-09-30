using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface ICalculatorView
    {
        /// <summary>
        /// Отображает результат вычисления
        /// </summary>
        /// <param name="result"></param>
        void PrintResult(double result);

        /// <summary>
        /// Показывает ошибку, например деление на 0, пустые аргументы и прочее
        /// </summary>
        /// <param name="message"></param>
        void DisplayError(String message);

        /// <summary>
        /// Возвращает значение, введенное в поле первого аргументы
        /// </summary>
        /// <returns></returns>
        string GetFirstArgumentAsString();

        /// <summary>
        /// Возвращает значение, введенное в поле второго аргументы
        /// </summary>
        /// <returns></returns>
        string GetSecondArgumentAsString();
    }
}
