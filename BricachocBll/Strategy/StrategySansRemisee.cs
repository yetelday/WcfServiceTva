using System;
using BricachocBo;


namespace BricachocBll.Strategy
{
   public class StrategySansRemise : ITarificateur
   {
       
       public void CalculerRemise(Vente venteEncours)
       {
           venteEncours.Remise = 0;

       }
   
   
   }
}