using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBo.Exceptions.VenteExceptions
{
   public class PlusRienAReglerException : ApplicationBricachocException
    {
        public PlusRienAReglerException()
        {
        }
        public PlusRienAReglerException(string message): base(message)
        {
        }
        public PlusRienAReglerException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
