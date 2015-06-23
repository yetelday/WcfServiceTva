using System.Data.Entity.ModelConfiguration;
using BricachocBo;

namespace BricachocDal.Configuration
{
    class CbConfiguration : EntityTypeConfiguration<Cb>
    {
        public CbConfiguration()
            : base()
        {

            // TPH : configuration du discriminator
            Map<Cb>(pe =>
            {
                pe.Requires("MR").HasValue("cb").HasMaxLength(2);
            });


        }

    }
}
