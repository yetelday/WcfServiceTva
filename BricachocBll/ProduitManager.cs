using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BricachocBo;
using BricachocDal;

namespace BricachocBll
{
    class ProduitManager
    {

        // son repository
        private IRepository<Produit> pDao;
        
        public ProduitManager(){}

        public ProduitManager(IRepository<Produit> repos)
        {
            pDao = repos;
        }
        
        
        internal ICollection<Produit> RechercherLesProduits()
        {
            // Appel du Dao
            ICollection<Produit> cp =pDao.GetAll();
            return cp;
        }

        public void CreerProduit(Produit p)
        {
            pDao.Insert(p);
        }

        public Produit RechercherUnProduit(string id)
        {
            return pDao.GetById(id);
        }
        public void MettreAJourProduit(Produit p)
        {
            pDao.Update(p);
        }

        public void MettreAJourTva(Produit p)
        {
            pDao.Update(p);
        }

        public void Supprimer(string id)
        {
            pDao.Delete(new Produit() { Cpu=id });
        }

    }
}
