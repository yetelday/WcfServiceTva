using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BricachocBo;
using BricachocDal.Configuration;
using BricachocDal.Exceptions;

namespace BricachocDal
{
    public class ParametreDao : IRepository<Parametre>
    {
      
        public ParametreDao()
        { 
        }
       
       
        // Mises à jour de la base
        public void Insert(Parametre p)
        {
            throw new NotImplementedException();
        }

        public void Delete(Parametre p)
        {
            throw new NotImplementedException();
        }
        public void Update(Parametre p)
        {
            throw new NotImplementedException();
        }
        // Recherche
        public Parametre GetById(object id)
        {
            int idP = (int)id;
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    var a = db.Parametres.Find(idP);
                    if (a == null) throw new DaoExceptionAfficheMessage("Parametre inexistant");
                    return a;
                }
                catch (System.Exception ex)
                {
                    throw new DaoExceptionAfficheMessage(ex.Message);
                }

             }
        }

        public ICollection<Parametre> GetAll()
        {
            throw new NotImplementedException();

        }

        


    }
}

