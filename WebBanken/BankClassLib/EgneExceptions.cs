using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankClassLib
{
    public class OvertrækException : Exception
    {
        public OvertrækException(string str) : base(str)
        {
        }
    }
}
