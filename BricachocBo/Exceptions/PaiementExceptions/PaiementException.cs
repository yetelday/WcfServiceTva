using System;


namespace BricachocBo.Exceptions.PaiementExceptions
{
    public class PaiementException : ApplicationBricachocException
    {
        public PaiementException()
        {
        }
        public PaiementException(string message): base(message)
        {
        }
        public PaiementException(string message, System.Exception inner): base(message, inner)
        {
        }
    }
}
