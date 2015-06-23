using System;
using System.Collections.Generic;

namespace BricachocBo
{
   public class Famille
   {
       public int CodeFamille { get; set; }
       public string LibelleFamille { get; set; }
       public Tva LaTva { get; set; }
       // FK
       public int Code { get; set; }

       // ajout d'une propriété calculée : TxTVa
       public decimal TxTva
       {
           get { return LaTva.Taux; }
       }

       // Equals : code identique
       public override bool Equals(Object obj)
       {
           var famille = obj as Famille;
           if (famille != null)
               return
                  famille.CodeFamille.Equals(this.CodeFamille);
           else
               return false;
       }
   
   }
}