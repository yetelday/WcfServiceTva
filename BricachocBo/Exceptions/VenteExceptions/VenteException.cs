using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBo.Exceptions.VenteExceptions
{
    public class VenteException :  ApplicationBricachocException
    {
         public VenteException()
        {
        }
        public VenteException(string message): base(message)
        {
        }
        public VenteException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
