using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBo.Exceptions.VenteExceptions
{
    public class ExisteDejaUnPaiement : ApplicationBricachocException
    {
        public ExisteDejaUnPaiement()
        {
        }
        public ExisteDejaUnPaiement(string message): base(message)
        {
        }
        public ExisteDejaUnPaiement(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
