using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoodschApp.Exceptions
{
    public class BoodschapException : Exception
    {
        public BoodschapException(string message) : base(message)
        {
            
        }
    }
}
