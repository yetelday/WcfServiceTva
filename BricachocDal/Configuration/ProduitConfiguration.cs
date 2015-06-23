using System.Data.Entity.ModelConfiguration;
using BricachocBo;
//using Microsoft.Data.Schema.SchemaModel;

namespace BricachocDal.Configuration
{
    class ProduitConfiguration : EntityTypeConfiguration<Produit>
    {
        public ProduitConfiguration()
            : base()
        {
            HasKey(p => p.Cpu);
            Property(p => p.Cpu).
                HasMaxLength(10).
                HasColumnType("varchar").
                IsRequired();
            Property(p => p.CodeFamille).
                 //HasColumnType("tinyint").
                IsRequired();
            Property(p => p.Description).
                HasColumnType("varchar").
                HasMaxLength(30).
                IsRequired();
           
            Property(p => p.PrixHt)
                .HasColumnType("money");
            //  Generic
            Property(p => p.Generic).
               IsRequired();


            Ignore(p => p.PrixTtc);
            
            // Association  (pour LaFamille)
            HasRequired(p => p.LaFamille)
                .WithMany()
                .HasForeignKey(p => p.CodeFamille);


        }


    }
   }
