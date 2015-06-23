using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBo.Exceptions.TvaExceptions
{
    public class TvaException : ApplicationBricachocException
    {
        public TvaException()
        {
        }
        public TvaException(string message): base(message)
        {
        }
        public TvaException(string message, System.Exception inner): base(message, inner)
        {
        }
    }
}
