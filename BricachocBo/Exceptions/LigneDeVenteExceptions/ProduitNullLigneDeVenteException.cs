using System;

namespace BricachocBo.Exceptions.LigneDeVenteExceptions
{
    public class ProduitNullLigneDeVenteException : LigneDeVenteException
    {
        public ProduitNullLigneDeVenteException()
        {
        }
        public ProduitNullLigneDeVenteException(string message): base(message)
        {
        }
        public ProduitNullLigneDeVenteException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
