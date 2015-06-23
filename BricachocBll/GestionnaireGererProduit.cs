using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BricachocBo;
using BricachocDal;

namespace BricachocBll
{
    public class GestionnaireGererProduit
    {
        ProduitManager produitMgr;
        TvaManager tvaMgr;
        FamilleManager familleMgr;

        public GestionnaireGererProduit()
        {
            produitMgr = new ProduitManager(new ProduitDao());
            tvaMgr = new TvaManager(new TvaDao());
            familleMgr = new FamilleManager(new FamilleDao());
        }

        public ICollection<Produit> ChargerLesProduits()
        {
            return produitMgr.RechercherLesProduits();
        }

        public ICollection<Tva> ChargerLesTvas()
        {
            return tvaMgr.ChargerLesTvas();
        }

        public ICollection<Famille> ChargerLesFamilles()
        {
            return familleMgr.ChargerLesFamilles();
        }

        public void CreerProduit(Produit p)
        {
            produitMgr.CreerProduit(p);
        }

        public Produit RechercherProduit(string id)
        {
            return produitMgr.RechercherUnProduit(id);
        }

        public void MettreAJourProduit(Produit p)
        {
             produitMgr.MettreAJourProduit(p);
        }

        public void Supprimer(string id)
        {
            produitMgr.Supprimer(id);
        }
        public Famille RechercherFamille(int id)
        {
            return familleMgr.RechercherFamille(id);
        }

    }
}
