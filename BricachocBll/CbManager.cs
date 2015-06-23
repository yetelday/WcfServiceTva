using System;
using BricachocBo;
using BricachocDal;
using BricachocBo.Exceptions.PaiementExceptions;

namespace BricachocBll
{
   public class CbManager : PaiementManager
   {
       
       
       internal override Paiement CreerPaiement(decimal montantReglement, decimal aRegler)
       {
           if (montantReglement <= aRegler)
               return new Cb(montantReglement);
           else throw new SoldeCBCHtException("Montant reglement ne peut pas être supérieur au montant de la vente");
       }
      
   }
}