using System.Data.Entity;
using BricachocBo;

namespace BricachocDal.Configuration
{
  public class BricachocInitializer :DropCreateDatabaseAlways<BricachocContext>
  {
    protected override void Seed(BricachocContext context)
    {

        // Les parametres
        Parametre p1 = new Parametre()
        {
            IdParametre=1,
            LibParametre="Nom magasin",
            ValString= "Bricachoc"
        };
        Parametre p2 = new Parametre()
        {
            IdParametre = 2,
            LibParametre = "Message bienvenue",
            ValString= "Bienvenue, gentils clients"
        };
        Parametre p3 = new Parametre()
        {
            IdParametre = 3,
            LibParametre = "Fond de caisse",
            ValDec = 200
        };

        Parametre p4 = new Parametre()
        {
            IdParametre = 4,
            LibParametre = "Remise fixe",
            ValDec= 0.10M
        };

         Parametre p5 = new Parametre()
        {
            IdParametre = 5,
            LibParametre = "A partir de ",
            ValDec= 200
        };

         Parametre p6 = new Parametre()
         {
             IdParametre = 6,
             LibParametre = "PourcRemise ",
             ValDec = 0.10M
         };
        // ajout
         context.Parametres.Add(p1);
         context.Parametres.Add(p2);
         context.Parametres.Add(p3);
         context.Parametres.Add(p4);
         context.Parametres.Add(p5);
         context.Parametres.Add(p6);

        // La tva
        Tva tva1 = new Tva();
        tva1.Taux = 0.200M;
        tva1.Code = 1;
        Tva tva2 = new Tva();
        tva2.Taux = 0.055M;
        tva2.Code = 2;

    

        // Lesfamilles
        Famille fam1 = new Famille()
           {
               CodeFamille = 1,
               LibelleFamille = "Alimentaire",
               LaTva = tva1
           };
        Famille fam2 = new Famille()
           {
               CodeFamille = 2,
               LibelleFamille = "Boissons sans alcool",
               LaTva = tva1
           };
        Famille fam3 = new Famille()
           {
               CodeFamille = 3,
               LibelleFamille = "Boissons alcoolisées",
               LaTva = tva1
           };

        // Les produits génériques
        Produit gen1 = new Produit()
        {
            Cpu = "Gen01",
            Description = "Article Generic",
            PrixHt = 0,
            Generic = true,
            LaFamille=fam1
        };

        Produit gen2 = new Produit()
        {
            Cpu = "Gen02",
            Description = "Article Generic",
            PrixHt = 0,
            Generic = true,
            LaFamille=fam2
        };

        Produit gen3 = new Produit()
        {
            Cpu = "Gen03",
            Description = "Article Generic",
            PrixHt = 0,
            Generic = true,
            LaFamille=fam3
        };

        Produit gen4 = new Produit()
        {
            Cpu = "Gen04",
            Description = "Article Generic",
            PrixHt = 0,
            Generic = true,
            LaFamille = fam1
        };

        // ajout 
        context.Produits.Add(gen1);
        context.Produits.Add(gen2);
        context.Produits.Add(gen3);
        context.Produits.Add(gen4);


        // Les produits
        context.Produits.Add(new Produit
       {
           Cpu = "Art01",
           Description = "Plaquette de beurre",
           PrixHt = 10.00M,
           Generic = false,
           LaFamille=fam1
       });

        context.Produits.Add(new Produit
        {
            Cpu = "Art02",
            Description = "Coca",
            PrixHt = 11.00M,
            Generic = false,
            LaFamille = fam2
        });

        context.Produits.Add(new Produit
        {
            Cpu = "Art03",
            Description = "Finger x 24",
            PrixHt = 5.00M,
            Generic = false,
            LaFamille=fam1
        });

    }
  }
}
