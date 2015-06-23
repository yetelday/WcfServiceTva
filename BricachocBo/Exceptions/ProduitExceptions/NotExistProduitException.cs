using System;

namespace BricachocBo.Exceptions.ProduitExceptions
{
    public class NotExistProduitException : ProduitException
    {
        public NotExistProduitException()
        {
        }
        public NotExistProduitException(string message): base(message)
        {
        }
        public NotExistProduitException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
