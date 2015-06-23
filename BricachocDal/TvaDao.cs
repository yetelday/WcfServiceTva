using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Data.Entity;
using BricachocBo;
using BricachocBo.Exceptions.ProduitExceptions;
using BricachocDal.Configuration;
using BricachocDal.Exceptions;


namespace BricachocDal
{
    public class TvaDao  : IRepository<Tva>
    {

        public TvaDao()
        {
        }


        // Mises à jour de la base
        public void Insert(Tva t)
        {
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    db.Entry(t).State = EntityState.Added;
                    
                    int n = db.SaveChanges();

                }
                catch (System.Exception ex)
                { 
                 
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Delete(Tva t)
        {
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    db.Entry(t).State = EntityState.Deleted;
                    int n = db.SaveChanges();

                }
                catch (System.Exception ex)
                {
                    throw new DaoException("Suppression imposible");
                }
            }
        }
        public void Update(Tva t)
        {
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    db.Entry(t).State = EntityState.Modified;
                    int n = db.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    throw new DaoException(ex.Message);
                }
            }
        }
        // Recherche
        public Tva GetById(object id)
        {
            int code = (int)id;
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    var p = db.Tvas.Find(code);
                    if (p == null) throw new DaoException("Tva inexistante");
                    return p;
                }
                catch (System.Exception ex)
                {
                    throw new DaoException(ex.Message);
                }

            }
        }

        public ICollection<Tva> GetAll()
        {

            List<Tva> lt ;
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    lt = db.Tvas.ToList();
                    return lt.ToList();
                }
                catch (System.Exception ex)
                {
                    throw new DaoException(ex.Message);
                }
            }
            
        }

    }
}
