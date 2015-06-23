using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BricachocBo;
using BricachocBo.Exceptions.VenteExceptions;




using System.Runtime.CompilerServices;
using BricachocDal;

[assembly: InternalsVisibleTo("BricachocTest")]


namespace BricachocBll
{
    class CaisseManager
    {
        public Caisse LaCaisse { get; set; }

        private VenteManager vMgr;
        private CatalogueManager catMgr;
        private ParametreManager parMgr;

        internal CaisseManager()
        {
            vMgr = new VenteManager(new VenteDao());
            catMgr = new CatalogueManager();
        }

        internal void InitialiserCaisse()
        {
            LaCaisse = new Caisse();
            // Catalogue
            LaCaisse.LeCatalogue = catMgr.ChargerLeCatalogue();
            // Vente 
            LaCaisse.VenteEnCours = vMgr.CreerNouvelleVente(LaCaisse.FamCatalogue);
            // Recherche infos de caisse
            parMgr= new ParametreManager(new ParametreDao());
            // Recherche nom du magasin 
            Parametre p1 = parMgr.RechercherParametre(1);
            LaCaisse.NomDuMagasin= p1.ValString;
            // Recherche message client 
            Parametre p2 = parMgr.RechercherParametre(2);
            LaCaisse.MessageClient = p2.ValString;
        }


        internal Vente SaisirArticle(string cpu, int qte)
        {
            // Rechercher article
            Produit unArticle = catMgr.RechercherArticle(LaCaisse.LeCatalogue,cpu);
            // Ajouter ligne de vente
            vMgr.AjouterLigneDeVente(LaCaisse.VenteEnCours, unArticle, qte);
            return LaCaisse.VenteEnCours;

        }

        internal Vente AnnulerArticle(string cpu, int qte)
        {
            // Ajouter ligne de vente
            vMgr.AjouterLigneDeVente(LaCaisse.VenteEnCours, cpu, qte);
            return LaCaisse.VenteEnCours;

        }

        internal Vente SaisirPaiement(ModeReg modeReglement, decimal montantReglement)
        {
            vMgr.CreerPaiement(LaCaisse.VenteEnCours, modeReglement, montantReglement);
            return LaCaisse.VenteEnCours;
        }
        

        internal Vente MettreVenteEnAttente()
        {
            // s'il existe une vente en attente
            if (LaCaisse.VenteEnAttente != null) throw new VenteException("Il existe déjà une vente en attente !");
            // si la vente en cours n'est pas démarrée
            if (LaCaisse.VenteEnCours.LigneDeVentes.Count == 0) throw new VenteException("Inutile de mettre cette vente en attente !");

            // sauver la vente sur vente en attente
            LaCaisse.VenteEnAttente = LaCaisse.VenteEnCours;
            // nouvelle vente
            LaCaisse.VenteEnCours = vMgr.CreerNouvelleVente(LaCaisse.FamCatalogue);
            return LaCaisse.VenteEnCours;
        }

        internal Vente ReprendreVenteEnAttente(out bool existVea)
        {
            // s'il n'existe pas de vente en attente
            if (LaCaisse.VenteEnAttente == null) throw new VenteException("Il n'existe pas de vente en attente !");
            // modif du type de retour et du parametre de la méthode pour info caissier
            // retourne la vente pour affichage total et booleen existence d'une vente en attente
            if (LaCaisse.VenteEnCours.LigneDeVentes.Count != 0)
            {
                // sauvegarde de la vente en cours
                Vente v = new Vente(LaCaisse.VenteEnCours);
                // la vente en attente devient vente en cours
                LaCaisse.VenteEnCours = LaCaisse.VenteEnAttente;
                // la vente en cours sauvegardée devient vente en attente
                LaCaisse.VenteEnAttente = v;
                existVea = true;
            }
            else
            {
                // la vente en attente devient vente en cours
                LaCaisse.VenteEnCours = LaCaisse.VenteEnAttente;
                // il n'y a plus de vente en attente
                LaCaisse.VenteEnAttente = null;
                existVea = false;
            }
            return LaCaisse.VenteEnCours;

        }

        internal Vente AnnulerVente()
        {
            // nouvelle instance
            LaCaisse.VenteEnCours = vMgr.CreerNouvelleVente(LaCaisse.FamCatalogue);
            return LaCaisse.VenteEnCours;
        }

        // Calcul le total A regler
        public Vente CalculerARegler(TypeRemise tr)
        {
            vMgr.CalculerARegler(LaCaisse.VenteEnCours, tr);
            return LaCaisse.VenteEnCours;
        }

    }
}
