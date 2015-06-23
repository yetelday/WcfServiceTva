
using System;

namespace BricachocBo
{
   public class Cb : Paiement
   {
        public Cb(decimal mtR)
       {
           Mr = new ModeReglement() { CodeModR = 1 };
           Montant = mtR;
       }
   }
}