using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBo.Exceptions.VenteExceptions
{
    public class QteTotaleInfQuantiteAnnulee:ApplicationBricachocException
    {
         public QteTotaleInfQuantiteAnnulee()
        {
        }
        public QteTotaleInfQuantiteAnnulee(string message): base(message)
        {
        }
        public QteTotaleInfQuantiteAnnulee(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
