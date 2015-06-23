using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBo
{
    public class Vente
    {

        public int NumVente { get; set; }
        public DateTime DateVente { get; set; }
        public List<LigneDeVente> LigneDeVentes { get; set; }
        public List<Paiement> Paiements { get; set; }

        // ajout remise
        public decimal Remise { get; set; }

        public Vente()
        {
            LigneDeVentes = new List<LigneDeVente>();
            Paiements = new List<Paiement>();
        }

        public Vente(Vente venteEnCours)
        {
            this.DateVente = venteEnCours.DateVente;
            this.LigneDeVentes = venteEnCours.LigneDeVentes;
            this.Paiements = venteEnCours.Paiements;
        } 


        // Propriétés calculées
        //====================

        /// <summary>
        /// Total HT
        /// </summary>

        public decimal TotalHt
        {
            get { return LigneDeVentes.Sum(p => p.SousTotalHt); }
        }

        /// <summary>
        /// Total TTC
        /// </summary>

        public decimal TotalTtc 
        {
            get { return LigneDeVentes.Sum(p => p.SousTotalTtc); }
        }

        /// <summary>
        /// Reste a régler = TotalTTC - déjà réglé - remise
        /// </summary>
        public decimal ResteARegler
        {
            get { return TotalTtc - this.Paiements.Sum(p => p.Montant) + TotalARendre - Remise; }
        }

        /// <summary>
        /// Total a rendre
        /// </summary>

        public decimal TotalARendre
        {
            get
            {
                return  this.Paiements.OfType<Espece>().Sum(p => p.Rendu);
            }
        }

    }
}
