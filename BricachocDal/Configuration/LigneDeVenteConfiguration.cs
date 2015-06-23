using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BricachocBo;

namespace BricachocDal.Configuration
{
    class LigneDeVenteConfiguration : EntityTypeConfiguration<LigneDeVente>
    {
        public LigneDeVenteConfiguration()
            : base()
        {
            HasKey(o => new { o.NumVente, o.Numlig }).
                Property(p => p.NumVente).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None). // pas d'autoincrémentation
                IsRequired();
            Property(p => p.Numlig).
                //HasColumnType("tinyint").
               HasDatabaseGeneratedOption(DatabaseGeneratedOption.None). // pas d'autoincrémentation
               IsRequired();
            Property(p => p.PrixUttc)
                .HasColumnType("money");
            //
            Property(p => p.DescriptionProduit).
                HasColumnType("varchar").
               HasMaxLength(30).
               IsRequired();
           Property(p => p.Cpu).
               HasColumnType("varchar").
                HasMaxLength(10).
                IsRequired();
            Property(p => p.Qte)
                //.HasColumnType("smallint")
                .IsRequired();

            Ignore(p => p.SousTotalHt);
            Ignore(p => p.SousTotalTtc);

            
            // Association  (pour LeProduit) 
            HasRequired(p => p.LeProduitReference)
                .WithMany()
                .HasForeignKey(p => p.Cpu);
                
        }


    }
   }
