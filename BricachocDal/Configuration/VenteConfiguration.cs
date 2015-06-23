using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BricachocBo;

namespace BricachocDal.Configuration
{
    class VenteConfiguration : EntityTypeConfiguration<Vente>
    {
        public VenteConfiguration()
            : base()
        {
            HasKey(p => p.NumVente);
            Property(p => p.NumVente).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity). //autoincrémentation
                IsRequired();
            Property(p => p.Remise)
                .HasColumnType("money")
                .IsRequired();
            
            //rien à spécifier pour la date 
          
            Ignore(p => p.TotalHt);
            Ignore(p => p.TotalTtc);
            Ignore(p => p.ResteARegler);
            Ignore(p => p.TotalARendre);


            // Association one to many  LigneDeVente 
            HasMany(d => d.LigneDeVentes)
                .WithRequired()
                .HasForeignKey(o =>o.NumVente);

            // Association (pour Paiement)
            HasMany(p => p.Paiements)
                .WithRequired()
                .HasForeignKey(p => p.NumVente);

            // TPC: Association (pour Paiement)
            //HasOptional(p => p.LePaiement)
            //    .WithMany()
            //    //.Map(p=>p.MapKey("ChequeId").ToTable("Cheque"));
            //    .HasForeignKey(p => p.CbId);
            
            //HasOptional(p => p.LePaiement)
            //  .WithMany()
            //  //.Map(p=>p.MapKey("EspeceId").ToTable("Espece"));
            //  .HasForeignKey(p => p.ChequeId);

            //HasOptional(p => p.LePaiement)
            // .WithMany()
            // //.Map(p => p.MapKey("CbId").ToTable("Cb"));
            // .HasForeignKey(p => p.EspeceId);

        }

    }
   }
