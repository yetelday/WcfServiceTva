using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BricachocBo;
using BricachocDal;

namespace BricachocBll
{
    class FamilleManager
    {
        private ProduitManager pManager;

        // son repository
        private IRepository<Famille> fDao;
         public FamilleManager(){}

        public FamilleManager(IRepository<Famille> repos)
        {
            fDao = repos;
        }

        public ICollection<Famille> ChargerLesFamilles()
        {
            return fDao.GetAll();
        }

        public void CreerFamille(Famille f)
        {
            
        }
        public Famille RechercherFamille(int id)
        {
            return fDao.GetById(id);
        }
    }


}
