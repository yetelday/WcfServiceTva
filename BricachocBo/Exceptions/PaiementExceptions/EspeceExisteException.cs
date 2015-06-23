using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBo.Exceptions.PaiementExceptions
{
    public class EspeceExisteException : PaiementException
    {
         public EspeceExisteException()
        {
        }
        public EspeceExisteException(string message): base(message)
        {
        }
        public EspeceExisteException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
