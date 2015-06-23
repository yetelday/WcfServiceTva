using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BricachocBo;
using BricachocBo.Exceptions.ProduitExceptions;
using BricachocBo.Exceptions.VenteExceptions;
using BricachocDal;
using BricachocBll.Strategy;


namespace BricachocBll
{
    class VenteManager
    {
        private LigneDeVenteManager ldvMgr;

        // son repository
        private IRepository<Vente> vDao;

       

        public VenteManager()
        {
            ldvMgr = new LigneDeVenteManager(new LigneDeVenteDao());
        }

        public VenteManager(IRepository<Vente> repos)
        {
            ldvMgr = new LigneDeVenteManager(new LigneDeVenteDao());
            vDao = repos;
        }
        internal Vente CreerNouvelleVente(List<Famille> lstFam )
        {
            Vente v = new Vente();
            return v;
        }

       

        // saisie d'un article non généric
        internal void AjouterLigneDeVente(Vente venteEnCours, Produit article, int qte)
        {
           
            // Je ne peux pas ajouter une ligne de vente si il existe déjà un paiement
            if (venteEnCours.Paiements.Count > 0) throw new ExisteDejaUnPaiement("Impossible d'ajouter une ligne sur une vente tout ou partie réglée");
            
            // Recherch=e existence ligne de vente pour cet article avec qte >0
            var ldv = venteEnCours.LigneDeVentes.FirstOrDefault(l => l.LeProduitReference == article && l.Qte > 0);
            if (ldv == null)
            {
                //création nouvelle ligne 
                ldv = ldvMgr.CreerLigneDeVente(article, qte);
                venteEnCours.LigneDeVentes.Add(ldv);

            }
            else
            {
                // Mise à jour ligne
                ldvMgr.MettreAJourLigneDeVente(ldv, qte);
            }

        }

        // annulation d'un article  ==> qte est negatif
        internal void AjouterLigneDeVente(Vente venteEnCours, string cpu, int qte)
        {

            // Je ne peux pas ajouter une ligne de vente si il existe déjà un paiement
            if (venteEnCours.Paiements.Count > 0) throw new ExisteDejaUnPaiement("Impossible d'ajouter une ligne sur une vente tout ou partie réglée");

            // Recherche de l'article dans la vente : pas prévu initialement, mais me permet d'interdire l'annulation de generics par le caissier
            LigneDeVente ldv= venteEnCours.LigneDeVentes.FirstOrDefault(l => l.LeProduitReference.Cpu == cpu);
            if ((ldv!=null && ldv.LeProduitReference.Generic) | ldv ==null)
                throw new ArticleGenericException("Appelez le manager pour annuler un généric!");
            
            // Somme des qtes pour cet article
            var totalQte = venteEnCours.LigneDeVentes.Where(l => l.LeProduitReference.Cpu == cpu).Sum(m => m.Qte);
            if (totalQte < Math.Abs(qte)) throw new QteTotaleInfQuantiteAnnulee("Quantité totale insuffisante");
          
            //création nouvelle ligne : recherche si existe déjà une ligne pour ce cpu en quantité négative
            ldv = venteEnCours.LigneDeVentes.FirstOrDefault(l => l.LeProduitReference.Cpu == cpu && !l.LeProduitReference.Generic && l.Qte < 0);
            if (ldv == null)
            {
                // recherche de la premiere ligne pour ce cpu pour récup objet article 
                var ldvArt = venteEnCours.LigneDeVentes.First(l => l.LeProduitReference.Cpu == cpu);
                //création nouvelle ligne 
                ldv = ldvMgr.CreerLigneDeVente(ldvArt.LeProduitReference, qte);
                venteEnCours.LigneDeVentes.Add(ldv);

            }
            else
            {
                // Mise à jour ligne
                ldvMgr.MettreAJourLigneDeVente(ldv, qte);
            }

        }
       

        
        internal void CreerPaiement(Vente venteEnCours, ModeReg modeReglement, decimal montantReglement )
        {
            // Calcul reste à regler
            decimal resteARegler = venteEnCours.ResteARegler;
            if (resteARegler == 0) throw new PlusRienAReglerException("Impossible : La vente est terminée !");
         
            // Création du bon PaiementManager à l'aide d'une fabrique Grasp
            var fabPMgr = new FabriquePaiementMgr();
            var pmgr = fabPMgr.GetPaiementMgr(modeReglement);
            
            // création du paiement
            Paiement p= pmgr.CreerPaiement(montantReglement, resteARegler);
            // ajout dans liste paiement
            venteEnCours.Paiements.Add(p);

            // Persiste en base
            if (venteEnCours.ResteARegler == 0)
            {
                venteEnCours.DateVente = DateTime.Now;
                vDao.Insert(venteEnCours);

            }

        }

        // Calcul le total A regler : mise en place Strategy
        public void CalculerARegler(Vente venteEnCours,TypeRemise tr)
        {
            ITarificateur tarificator = FabriqueStrategy.Instance.CreerTarificateur(tr);
            tarificator.CalculerRemise(venteEnCours);
        }

    }
}
