using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BricachocBo;
//using Microsoft.Data.Schema.SchemaModel;

namespace BricachocDal.Configuration
{
    class ParametreConfiguration : EntityTypeConfiguration<Parametre>
    {
        public ParametreConfiguration()
            : base()
        {
            HasKey(p => p.IdParametre);
            Property(p => p.IdParametre).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None). // pas d'autoincrémentation
                IsRequired();

            Property(p => p.LibParametre).
                HasMaxLength(30).
                IsRequired();

            //Property(p => p.TypeVal)
            //    .HasColumnType("string")
            //    .IsRequired();

            Property(p => p.ValString).
                HasColumnType("varchar").
                 HasMaxLength(50);
            Property(p => p.ValDec).
                   HasColumnType("money")
                   .IsOptional();
            // RAs pour valint
            Property(p => p.ValInt)
                  .IsOptional();
        }
    }
}
