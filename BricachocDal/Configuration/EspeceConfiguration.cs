using System.Data.Entity.ModelConfiguration;
using BricachocBo;
//using Microsoft.Data.Schema.SchemaModel;

namespace BricachocDal.Configuration
{
    class EspeceConfiguration : EntityTypeConfiguration<Espece>
    {
        public EspeceConfiguration()
            : base()
        {

            Property(p => p.Rendu).
                HasColumnName("rendu").HasColumnType("money");

            // TPH : configuration du discriminator
            Map<Espece>(pe =>
            {
                pe.Requires("MR").HasValue("es").HasMaxLength(2);
            });

        }
    }
}
