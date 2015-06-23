using System;
using BricachocBo;


namespace BricachocBll.Strategy
{
   internal interface ITarificateur
   {
      void CalculerRemise(Vente venteEnCours);
   }
}