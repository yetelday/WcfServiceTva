using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BricachocBo;
// Entity

namespace BricachocDal.Configuration
{
    public class BricachocContext : DbContext
    {

        public BricachocContext(): base("name=BricachocCs") {}

        public DbSet<Famille> Familles { get; set; }
        public DbSet<LigneDeVente> LigneDeVentes { get; set; }
        public DbSet<ModeReglement> ModeReglements { get; set; }
         // si TPH, pas de DbSet pour les classes enfant, DbSet pour Paiement
        public DbSet<Paiement> Paiements { get; set; }
        //public DbSet<Espece> Especes { get; set; }
        //public DbSet<Cb> Cbs { get; set; }
        //public DbSet<Cheque> Cheques { get; set; }
         public DbSet<Parametre> Parametres { get; set; }
         public DbSet<Produit> Produits { get; set; }
         public DbSet<Tva> Tvas { get; set; }
         public DbSet<Vente> Ventes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            // par défaut, nom de la table = nom de la classe au pluriel 
            // => lui dire l'inverse
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            // Solution 2 : classes de configuration instanciée dans la méthode
            //---------------------------------------------------------------------
            modelBuilder.Configurations.Add(new FamilleConfiguration());
            modelBuilder.Configurations.Add(new LigneDeVenteConfiguration());
            modelBuilder.Configurations.Add(new ModeReglementConfiguration());
            // si TPH
            modelBuilder.Configurations.Add(new PaiementConfiguration());
            modelBuilder.Configurations.Add(new CbConfiguration());
            modelBuilder.Configurations.Add(new EspeceConfiguration());
            modelBuilder.Configurations.Add(new ChequeConfiguration());
            
            modelBuilder.Configurations.Add(new ParametreConfiguration());

            modelBuilder.Configurations.Add(new ProduitConfiguration());
            modelBuilder.Configurations.Add(new TvaConfiguration());
            modelBuilder.Configurations.Add(new VenteConfiguration());

            
            modelBuilder.Ignore<Caisse>();
            modelBuilder.Ignore<Catalogue>();

            base.OnModelCreating(modelBuilder);

        }


    }
}

