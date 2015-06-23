using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BricachocBo;
using BricachocBo.Dto;

namespace BricachocBll
{
    public class GestionnaireEnregistrerVente
    {

        private CaisseManager cMgr;

        
        public GestionnaireEnregistrerVente()
        {
            cMgr = new CaisseManager();
        }


        // Modif retour de Initialiser Caisse
        //public CaisseDto InitialiserCaisse()
        public void InitialiserCaisse()
        {
            cMgr.InitialiserCaisse();
            // Retour vers l'ihm d la caisse légere : caisseDto
            //return Assembler.CreateCaisseDto(cMgr.LaCaisse);

        }

        public Vente SaisirArticle(string cpu, int qte)
        {
            // delegation à VenteManager
            return cMgr.SaisirArticle(cpu, qte);
        }

        public Vente SaisirPaiement(ModeReg modeReglement, decimal montantReglement)
        {
            return cMgr.SaisirPaiement(modeReglement, montantReglement);
        }


        public Vente AnnulerArticle(string cpu, int qte)
        {
            qte *= -1;
            return cMgr.AnnulerArticle(cpu, qte);
        }


        public Vente MettreVenteEnAttente()
        {
            return cMgr.MettreVenteEnAttente();
        }

        public Vente ReprendreVenteEnAttente(out bool existVea)
        {
            return cMgr.ReprendreVenteEnAttente(out existVea);

        }

        public Vente AnnulerVente()
        {
            return cMgr.AnnulerVente();
        }


        public Vente CalculerARegler(TypeRemise tr)
        {
            return cMgr.CalculerARegler(tr);
        }

    }
}
