using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BricachocBo;
using BricachocDal.Configuration;
using System.Data.Entity;
using BricachocBo.Exceptions.FamilleExceptions;
using BricachocBo.Exceptions.ProduitExceptions;

namespace BricachocDal
{
    public class FamilleDao : IRepository<Famille>
    {

        public FamilleDao()
        {
        }


        // Mises à jour de la base
        public void Insert(Famille a)
        {
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    db.Entry(a).State = EntityState.Added;
                    int n = db.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception(ex.Message);
                }

            }
        }

        public void Delete(Famille a)
        {
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    db.Entry(a).State = EntityState.Deleted;
                    int n = db.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception(ex.Message);
                }

            }
        }

        public void Update(Famille a)
        {
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    db.Entry(a).State = EntityState.Modified;
                    int n = db.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception(ex.Message);
                }

            }
        }

        // Recherche
        public Famille GetById(object id)
        {
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    int cf = (int) id;
                    var f= db.Familles.Find(cf);
                    if (f == null) throw new NotExistFamilleException("Famille inexistante");
                    // chargement Tva
                    db.Entry(f).Reference(q => q.LaTva).Load();
                    return f;

                }
                catch (System.Exception ex)
                {
                    throw new System.Exception(ex.Message);
                }

            }
        }

        public ICollection<Famille> GetAll()
        {

            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    var f=db.Familles.Include(p =>p.LaTva).ToList();
                    return f;
                }
                catch (System.Exception ex)
                {
                    throw new System.Exception(ex.Message);
                }

            }
        }

    }
}
