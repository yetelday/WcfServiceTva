using System;

using BricachocBo;
using BricachocDal;

namespace BricachocBll
{
   public class EspeceManager : PaiementManager
   {
       internal override Paiement CreerPaiement(decimal montantReglement, decimal aRegler)
       {
           return new Espece(montantReglement, aRegler);
       }

   }
}