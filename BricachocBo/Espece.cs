using System;

namespace BricachocBo
{
   public class Espece : Paiement
   {
       public decimal Rendu { get; set; }

       public Espece(decimal mtR, decimal totV)
       {
           Mr = new ModeReglement() {CodeModR=3};
           if (mtR < totV) Rendu = 0;
           else Rendu = mtR - totV;
           Montant = mtR;
       }
   
   }
}