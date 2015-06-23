using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBo.Dto
{
    public class CaisseDto
    {
        public List<Famille> Familles { get; set; }

        public string NomDuMagasin { get; set; }
        public string MessageClient { get; set; }
    }
 }

