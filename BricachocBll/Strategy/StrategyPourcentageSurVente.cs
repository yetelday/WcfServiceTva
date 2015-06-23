using System;
using BricachocBo;

namespace BricachocBll.Strategy
{
   public class StrategyPourcentageSurVente : ITarificateur
   {
       
       private decimal pourcentage;
       
       
       public StrategyPourcentageSurVente()
       {
           pourcentage = 0.10M;
       }
       public StrategyPourcentageSurVente(decimal pourc)
       {
           pourcentage = pourc;
       }

       public void CalculerRemise(Vente venteEncours)
       {
           venteEncours.Remise = venteEncours.TotalTtc * pourcentage;
       }
   
   }
}