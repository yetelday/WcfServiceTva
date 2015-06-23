using System;

namespace BricachocBo
{
   public abstract class Paiement
   {
       public int NumPaiement { get; set; }
       public int NumVente { get; set; }
       public decimal Montant { get; set; }

       // rajout type paiement 
       public ModeReglement Mr { get; set; }
       // FK
       public int CodeModR { get; set; }


   }
   
   }
