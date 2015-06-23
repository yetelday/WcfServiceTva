using System.Collections.Generic;
using System.ServiceModel;
using BricachocBo;

namespace WcfServiceTva
{
    [ServiceContract]
    public interface IServiceTva
    {
        [OperationContract]
        ICollection<Tva> ChargerLesTvas();

        [OperationContract]
        void CreerTva(Tva t);

        [OperationContract]
        void MettreAJourTva(Tva t);

        [OperationContract]
        void Supprimer(int id);

        [OperationContract]
        Tva RechercherTva(int code);
        
    }
}