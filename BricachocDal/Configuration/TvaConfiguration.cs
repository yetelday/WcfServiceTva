using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BricachocBo;
//using Microsoft.Data.Schema.SchemaModel;

namespace BricachocDal.Configuration
{
    class TvaConfiguration : EntityTypeConfiguration<Tva>
    {
        public TvaConfiguration()
            : base()
        {
            HasKey(p => p.Code);
            Property(p => p.Code).
                HasColumnName("TvaId").
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None). // pas d'autoincrémentation
                //HasColumnType("tinyint").
                IsRequired();
            Property(p => p.Taux).
                HasPrecision(5, 3);
            

        }


    }
   }
