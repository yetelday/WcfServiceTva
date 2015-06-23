using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BricachocBo;
using BricachocDal;

namespace BricachocBll
{
    public class GestionnaireGererTva
    {
        private TvaManager tvaMgr=new TvaManager(new TvaDao());

        public ICollection<Tva> ChargerLesTvas()
        {
            return tvaMgr.ChargerLesTvas();
        }
        public void CreerTva(Tva t)
        {
            tvaMgr.CreerTva(t);
        }

        public void MettreAJourTva(Tva t)
        {
            tvaMgr.MettreAJourTva(t);
        }

        public void Supprimer(int id)
        {
            tvaMgr.Supprimer(id);
        }

        public Tva RechercherTva(int code)
        {
            return tvaMgr.RechercherTva(code);
        }


    }
}
