using System;
using BricachocBo.Exceptions;
using BricachocBo.Exceptions.LigneDeVenteExceptions;

namespace BricachocBo
{
    public class LigneDeVente
    {

        public LigneDeVente(Produit produit, int qte)
        {
            // controles
            if (produit == null) throw new ProduitNullLigneDeVenteException("Produit ne peut être null !");
            if (qte == 0) throw new QuantiteLigneDeVenteException("La quantité ne peut être égale à 0!");
            this.Qte = qte;
            LeProduitReference = produit;

            DescriptionProduit = LeProduitReference.Description;
            PrixUttc = LeProduitReference.PrixTtc;
        }
        public LigneDeVente(Produit produit, int qte, string designation, decimal pTTC)
        {
            // controles
            if (produit == null) throw new ProduitNullLigneDeVenteException("Produit ne peut être null !");
            if (qte == 0) throw new QuantiteLigneDeVenteException("La quantité ne peut être égale à 0!");
            this.Qte = qte;
            LeProduitReference = produit;

            DescriptionProduit = designation;
            PrixUttc = pTTC;
        }


        public int NumVente { get; set; }

        public int Numlig { get; set; }

        private int qte;
        public int Qte
        {
            get { return qte; }
            set {
                if (value == 0) throw new QuantiteLigneDeVenteException("La quantité ne peut être égale à 0!");
                qte = value; 
                 }
        }

        public decimal PrixUttc { get; set; }

        public string DescriptionProduit { get; set; }

        private Produit leProduitReference;
        public Produit LeProduitReference
        {
            get { return leProduitReference; }
            set {
                if (value == null) throw new ProduitNullLigneDeVenteException("Produit ne peut être null !");
                leProduitReference = value;
            }
        }
        //FK
        public string Cpu { get; set; }


        // Equals : code identique
        public override bool Equals(Object obj)
        {
            if (obj is LigneDeVente)
                return
                   ((LigneDeVente)obj).Numlig.Equals(this.Numlig);
            else
                return false;
        }


        // Propriétés calculées

        //Sous-total HT
        public decimal SousTotalHt
        {
            get { return LeProduitReference.PrixHt * Qte; }
        }

        // Sous-total TTC
        public decimal SousTotalTtc
        {
            get { return PrixUttc * Qte; }
        }
    }
}