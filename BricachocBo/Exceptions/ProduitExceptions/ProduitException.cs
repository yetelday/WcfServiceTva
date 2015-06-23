using System;

namespace BricachocBo.Exceptions.ProduitExceptions
{
    public class ProduitException : ApplicationBricachocException
    {
        public ProduitException()
        {
        }
        public ProduitException(string message): base(message)
        {
        }
        public ProduitException(string message, System.Exception inner): base(message, inner)
        {
        }
    }
}
