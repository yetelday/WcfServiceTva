using System;

namespace BricachocBo.Exceptions.LigneDeVenteExceptions
{
    public class LigneDeVenteException : ApplicationBricachocException
    {
        public LigneDeVenteException()
        {
        }
        public LigneDeVenteException(string message): base(message)
        {
        }
        public LigneDeVenteException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
