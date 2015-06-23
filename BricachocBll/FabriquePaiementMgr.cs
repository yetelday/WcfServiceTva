using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBll
{
    class FabriquePaiementMgr
    {
        internal PaiementManager GetPaiementMgr(ModeReg modeReglement)
        {
           // Fabrique les différents manager 
           // utilisation d'une bonne pratique Grasp (Pure Fabrication)
            
            PaiementManager pmgr=null;
            switch (modeReglement)
            {
                case ModeReg.Cb:
                    pmgr = new CbManager();
                    break;

                case ModeReg.Ch:
                    pmgr = new ChManager();
                    break;

                case ModeReg.Especes:
                    pmgr = new EspeceManager();
                    break;
            }
            return pmgr;
        }
    }
}
