using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BricachocBo;
//using Microsoft.Data.Schema.SchemaModel;

namespace BricachocDal.Configuration
{
    class FamilleConfiguration : EntityTypeConfiguration<Famille>
    {
        public FamilleConfiguration()
            : base()
        {
            HasKey(p => p.CodeFamille);
            Property(p => p.CodeFamille).
                //HasColumnType("tinyint").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None). // pas d'autoincrémentation
                IsRequired();
            Property(p => p.LibelleFamille).
              HasMaxLength(30).
              HasColumnType("varchar").
              IsRequired();
            Property(p => p.Code)
                .HasColumnName("CodeTva")
                //.HasColumnType("tinyint")
                .IsRequired();

            Ignore(p => p.TxTva);


            // Association  (pour LaTva) 
            HasRequired(p => p.LaTva)
                .WithMany()
                .HasForeignKey(p => p.Code);

            // association Generics : configuré dans Famille
            //HasMany(p => p.Generics)
            //  .WithRequired()
            //  .HasForeignKey(p => p.);
        }
    }
}
