using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BricachocBo;
//using Microsoft.Data.Schema.SchemaModel;

namespace BricachocDal.Configuration
{
    class PaiementConfiguration : EntityTypeConfiguration<Paiement>
    {
        public PaiementConfiguration()
            : base()
        {
            HasKey(o => new {o.NumVente, o.NumPaiement});
            
            Property(p => p.NumVente).
            HasDatabaseGeneratedOption(DatabaseGeneratedOption.None). // pas d'autoincrémentation
            IsRequired();
            Property(p => p.NumPaiement).
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.None). // pas d'autoincrémentation
               //HasColumnType("tinyint").
               IsRequired();

            Property(p => p.Montant)
                .HasColumnType("money")
                .IsRequired();

            Property(p => p.CodeModR).
              IsRequired()
              //.HasColumnType("tinyint")
              ;
            // Association  (pour Mr) 
            HasRequired(p => p.Mr)
                .WithMany()
                .HasForeignKey(p => p.CodeModR);
        }


    }
   }
