using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public class EmptyParametrException: Exception
    {
        public override string Message => "Empty parametr";
    }
}
