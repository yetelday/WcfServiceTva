using System;
using BricachocBo;

namespace BricachocBll.Strategy
{
   public class StrategyRemiseFixe : ITarificateur
   {
       
       private decimal remiseFixe;
       private decimal aPartirDe;

       public StrategyRemiseFixe()
       {
           remiseFixe = 10;
           aPartirDe = 200;
       }
       
       public StrategyRemiseFixe(decimal rem, decimal plancher)
       {
           remiseFixe = rem;
           aPartirDe =plancher;
       }

       public void CalculerRemise(Vente venteEncours)
       {
           if (venteEncours.TotalTtc > aPartirDe)
               venteEncours.Remise = remiseFixe;
           else venteEncours.Remise = 0;
       }

       
   
   }
}