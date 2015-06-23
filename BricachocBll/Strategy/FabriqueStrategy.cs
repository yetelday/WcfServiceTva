using System;
using System.Net.Configuration;
using BricachocBo;
using BricachocDal;

namespace BricachocBll.Strategy
{
 public class FabriqueStrategy
 {
     
     
     private decimal pourc;
     private decimal rfixe;
     private decimal plancher;

    private static FabriqueStrategy instance;
    public static FabriqueStrategy Instance
    {
        get
        {
            if (instance == null) instance = new FabriqueStrategy();
            return instance;
        }
    }

    // constructeur privé 
    private FabriqueStrategy()
    {
        RechercherRemise();
    }

    internal void RechercherRemise()
    {
        // charger les données des différentes Stratégies
       ParametreManager pManager = new ParametreManager(new ParametreDao());
        // valeur Pourcentage
        Parametre p1 = pManager.RechercherParametre(6);
        pourc = p1.ValDec;
        // valeur remise fixe
        Parametre p2 = pManager.RechercherParametre(4);
        rfixe = p2.ValDec;
        // valeur a partir de
        Parametre p3 = pManager.RechercherParametre(5);
        plancher = p3.ValDec;
    }


    internal ITarificateur CreerTarificateur(TypeRemise tr)
    {
        ITarificateur tarificator;
        if (tr==TypeRemise.Pourcentage) tarificator= new StrategyPourcentageSurVente(pourc);
        else if(tr==TypeRemise.Fixe) tarificator = new StrategyRemiseFixe(rfixe,plancher);
        else tarificator = new StrategySansRemise();
        return tarificator;
    }
 }
}