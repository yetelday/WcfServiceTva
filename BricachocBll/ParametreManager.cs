using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BricachocBo;
using BricachocDal;

namespace BricachocBll
{
    class ParametreManager
    {

        // son repository
        private IRepository<Parametre> pDao;
        
        public ParametreManager(IRepository<Parametre> repos )
        {
            pDao = repos;
        }
        
        internal Parametre RechercherParametre(int idp)
        {
            Parametre p = pDao.GetById(idp);
            return p;

        }
    }
}
