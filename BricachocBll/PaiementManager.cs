using System;

using BricachocBo;
using BricachocDal;

namespace BricachocBll
{
   public abstract class PaiementManager
   {
       internal abstract Paiement CreerPaiement(decimal montantReglement, decimal totalVente);

   }
}