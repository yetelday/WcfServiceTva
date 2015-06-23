using System;
using System.Collections.Generic;
using System.Linq;
using BricachocBo;
using BricachocBo.Exceptions;
using BricachocBo.Exceptions.ProduitExceptions;
using BricachocDal.Configuration;
using System.Data.Entity;
using System.Linq.Expressions;
using BricachocBo.Exceptions.TvaExceptions;
using BricachocDal.Exceptions;

namespace BricachocDal
{
    public class ProduitDao : IRepository<Produit>
    {

        public ProduitDao()
        {
        }


        // Mises à jour de la base
        public void Insert(Produit a)
        {
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    db.Entry(a).State = EntityState.Added;
                    // les produits connexes
                    db.Entry(a.LaFamille).State = EntityState.Unchanged;
                    db.Entry(a.LaFamille.LaTva).State = EntityState.Unchanged;

                    int n = db.SaveChanges();
                }
                catch (System.Exception ex)
                {
                     throw new System.Exception(ex.Message);
                }

            }
        }

        public void Delete(Produit a)
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
                    throw new DaoException("Suppression imposible");
                }
            }
        }

        public void Update(Produit a)
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
                    throw new DaoException(ex.Message);
                }
            }
        }

        // Recherche
        public Produit GetById(object id)
        {
            string cpu = (string) id;
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    var a = db.Produits.Find(cpu);
                    if (a == null) throw new NotExistProduitException("Article inexistant");

                    db.Entry(a).Reference(q => q.LaFamille).Load();
                    db.Entry(a.LaFamille).Reference(q => q.LaTva).Load();
                    
                    
                    return a;
                }
                catch (System.Exception ex)
                {
                    throw new DaoExceptionAfficheMessage(ex.Message);
                }

            }
        }

        public ICollection<Produit> GetAll()
        {
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    //Inclure Famille et Tva - mais pas la collection Generics de LaFamille
                    // Include ne charge pas le reference Tva de la famille, mais charge la collection Generics avec tous les articles 
                    // Générics ou non du catalogue

                    var query = db.Produits.Include(p => p.LaFamille.LaTva).Where(p => p.Generic == false).ToList();
                   
                    // La même requête avec Load
                    //===========================
                    //var query = db.Produits.Where(p => p.Generic == false).ToList();
                    //foreach (var p in query)
                    //{
                    //    db.Entry(p).Reference(q => q.LaFamille).Load();
                    //    db.Entry(p.LaFamille).Reference(q => q.LaTva).Load();
                    //}

                   

                   


                    return query;
                }
                catch (System.Exception ex)
                {
                    throw new DaoExceptionAfficheMessage(ex.Message);
                }

            }
        }

      

    }
}

