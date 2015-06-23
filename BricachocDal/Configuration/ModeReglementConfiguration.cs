using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BricachocBo;

namespace BricachocDal.Configuration
{
    class ModeReglementConfiguration : EntityTypeConfiguration<ModeReglement>
    {
        public ModeReglementConfiguration()
            : base()
        {
            HasKey(p => p.CodeModR);
            Property(p => p.CodeModR).
                HasDatabaseGeneratedOption(DatabaseGeneratedOption.None). // pas d'autoincrémentation
                IsRequired()
                //HasColumnType("tinyint")
                ;
            Property(p => p.LibModR).
              HasMaxLength(30).
              HasColumnType("varchar").
              IsRequired();

        }
    }
}
