using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBo.Exceptions.FamilleExceptions
{
    public class FamilleException : ApplicationBricachocException
    {
      
        public FamilleException()
        {
        }
        public FamilleException(string message): base(message)
        {
        }
        public FamilleException(string message, System.Exception inner): base(message, inner)
        {
        }
    }
}
