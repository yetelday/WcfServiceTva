using System;
using BricachocBo;
using BricachocDal;
using BricachocBo.Exceptions.PaiementExceptions;


namespace BricachocBll
{
   public class ChManager : PaiementManager
   {

       internal override Paiement CreerPaiement(decimal montantReglement, decimal aRegler)
       {
           if (montantReglement <= aRegler)
               return new Cheque(montantReglement);
           else throw new SoldeCBCHtException("Montant reglement ne peut pas �tre sup�rieur au montant de la vente");

       }
       
   }
}