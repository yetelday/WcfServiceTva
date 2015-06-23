using System.Data.Entity.ModelConfiguration;
using BricachocBo;
//using Microsoft.Data.Schema.SchemaModel;

namespace BricachocDal.Configuration
{
    class ChequeConfiguration : EntityTypeConfiguration<Cheque>
    {
        public ChequeConfiguration()
            : base()
        {


            // TPH : configuration du discriminator
            Map<Cheque>(pe =>
            {
                pe.Requires("MR").HasValue("ch").HasMaxLength(2);
            });



        }


    }
}
