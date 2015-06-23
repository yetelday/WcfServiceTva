using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BricachocBll;
using BricachocBo;
using BricachocDal;

namespace WcfServiceTva
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceTva : IServiceTva
    {
        private TvaManager tvaMgr = new TvaManager(new TvaDao());

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
