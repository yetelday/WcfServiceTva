using System;

namespace BricachocBo.Exceptions.PaiementExceptions
{
    public class SoldeCBCHtException : PaiementException
    {
        public SoldeCBCHtException()
        {
        }
        public SoldeCBCHtException(string message): base(message)
        {
        }
        public SoldeCBCHtException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
