using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BricachocBo;
using BricachocBo.Exceptions.ProduitExceptions;

using System.Runtime.CompilerServices;
using BricachocDal;

[assembly : InternalsVisibleTo("BricachocTest")]



namespace BricachocBll
{
    
    class CatalogueManager
    {
        private ProduitManager pMgr;
        private FamilleManager fMgr;

        internal CatalogueManager()
        {
            pMgr= new ProduitManager(new ProduitDao());
            fMgr= new FamilleManager(new FamilleDao());
        }


        internal Catalogue ChargerLeCatalogue()
        {
            Catalogue leCatalogue = new Catalogue();

            leCatalogue.Produits = pMgr.RechercherLesProduits().ToList();
            
            return leCatalogue;

        }
        internal Produit RechercherArticle(Catalogue leCatalogue, string cpu)
        {
            //Produit oProduit = leCatalogue.Produits.Find(p => p.Cpu == cpu);

            var oProduit = leCatalogue.Produits.SingleOrDefault(p => p.Cpu == cpu);
            if (oProduit == null) throw new NotExistProduitException("Article inconnu au catalogue ");
            if(oProduit.Generic) throw  new ArticleGenericException("Article généric interdit");
            return oProduit;
        }


    }
}
