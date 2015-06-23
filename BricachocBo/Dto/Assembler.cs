using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BricachocBo;

namespace BricachocBo.Dto
{
    public static class Assembler
    {
        public static CaisseDto CreateCaisseDto(Caisse c)
        {
            CaisseDto cDto = new CaisseDto();
            cDto.Familles = c.FamCatalogue;

            cDto.MessageClient = c.MessageClient;
            cDto.NomDuMagasin = c.NomDuMagasin;
            return cDto;

        }

       

    }
}
