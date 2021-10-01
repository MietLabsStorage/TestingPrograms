using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface ICalculator
    {
        /// <summary>
        /// Вычисляет сумму двух чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        double Sum(double a, double b);


        /// <summary>
        /// Вычисляет разность двух чисел a - b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        double Subtract(double a, double b);

        /// <summary>
        /// Вычисляет произведение двух чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        double Multiply(double a, double b);

        /// <summary>
        /// Вычисляет отношение числа а к числу b.
        /// Должен выбросить { ArithmeticException } если |b| < 10e-8
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        double Divide(double a, double b);
    }
}
