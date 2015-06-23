using System;

namespace BricachocBo.Exceptions.LigneDeVenteExceptions
{
    public class QuantiteLigneDeVenteException : LigneDeVenteException
    {
        public QuantiteLigneDeVenteException()
        {
        }
        public QuantiteLigneDeVenteException(string message): base(message)
        {
        }
        public QuantiteLigneDeVenteException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
