using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBo
{
    public class ModeReglement
    {
        public int CodeModR { get; set; }
        public string LibModR { get; set; }

        public override string ToString()
        {
            return LibModR;
        }
    }
}
