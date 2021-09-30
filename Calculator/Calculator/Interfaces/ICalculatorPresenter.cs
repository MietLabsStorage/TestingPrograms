using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    interface ICalculatorPresenter
    {
        /// <summary>
        /// Вызывается формой в тот момент, когда пользователь нажал на кнопку '+'
        /// </summary>
        void OnPlusClicked(object sender, EventArgs e);

        /// <summary>
        /// Вызывается формой в тот момент, когда пользователь нажал на кнопку '-'
        /// </summary>
        void OnMinusClicked(object sender, EventArgs e);

        /// <summary>
        /// Вызывается формой в тот момент, когда пользователь нажал на кнопку '/'
        /// </summary>
        void OnDivideClicked(object sender, EventArgs e);

        /// <summary>
        /// Вызывается формой в тот момент, когда пользователь нажал на кнопку '*'
        /// </summary>
        void OnMultiplyClicked(object sender, EventArgs e);
    }
}
