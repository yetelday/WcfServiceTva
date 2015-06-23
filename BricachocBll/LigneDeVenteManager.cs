using System;

using BricachocBo;
using BricachocDal;

namespace BricachocBll
{
   public class LigneDeVenteManager
   {
        private IRepository<LigneDeVente> ldvDao;
        
        public LigneDeVenteManager(IRepository<LigneDeVente> repos )
        {
            ldvDao = repos;
        }

      public LigneDeVente CreerLigneDeVente(Produit article, int qte)
      {
          return new LigneDeVente(article, qte);
      }

      public void MettreAJourLigneDeVente(LigneDeVente ldv, int qte)
      {
          ldv.Qte += qte;
      }
   
   }
}