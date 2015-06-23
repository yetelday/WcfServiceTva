// File:    Cheque.cs
using System;

namespace BricachocBo
{
   public class Cheque : Paiement
   {
        public Cheque(decimal mtR)
       {
           Montant = mtR;
           Mr = new ModeReglement() { CodeModR = 2 };
       }
   }
}