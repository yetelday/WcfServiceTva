using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BricachocBo;

namespace WcfServiceLibraryTva
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
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
