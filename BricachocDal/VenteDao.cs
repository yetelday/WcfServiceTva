using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BricachocBo;
using BricachocDal.Configuration;
using System.Linq.Expressions;
using BricachocDal.Exceptions;


namespace BricachocDal
{
    public class VenteDao : IRepository<Vente>
    {

        public VenteDao()
        {
        }

        // Mises à jour de la base
        public void Insert(Vente v)
        {

            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    db.Entry(v).State = EntityState.Added;

                    int numli = 1;
                    foreach (var ldv in v.LigneDeVentes)
                    {
                        
                        ldv.Numlig = numli;
                        numli++;

                        db.Entry(ldv.LeProduitReference).State = EntityState.Unchanged;
                        db.Entry(ldv.LeProduitReference.LaFamille).State = EntityState.Unchanged;
                        db.Entry(ldv.LeProduitReference.LaFamille.LaTva).State = EntityState.Unchanged;
                    }

                    numli = 1;
                    foreach (var p in v.Paiements)
                    {
                        p.NumPaiement = numli;
                        numli++;
                        db.Entry(p.Mr).State = EntityState.Unchanged;
                    }

                    // Version 2
                    //=============
                    //var tvas = db.ChangeTracker.Entries<Tva>().ToList();
                    //var familles = db.ChangeTracker.Entries<Famille>().ToList();
                    //var produits = db.ChangeTracker.Entries<Produit>().ToList();
                    //var mr = db.ChangeTracker.Entries<ModeReglement>().ToList();

                    //// Détacher les articles

                    //foreach (var t in tvas)
                    //{
                    //    t.State = EntityState.Unchanged;
                    //}

                    //foreach (var f in familles)
                    //{
                    //    f.State = EntityState.Unchanged;
                    //}

                    //foreach (var p in produits)
                    //{
                    //    p.State = EntityState.Unchanged;
                    //}

                    //foreach (var p in mr)
                    //{
                    //    p.State = EntityState.Unchanged;
                    //}

                    // Operation base
                    int n = db.SaveChanges();
                }
                catch (System.Exception ex)
                {
                    throw new DaoExceptionAfficheMessage(ex.Message);
                }


            }

        }

        public void Delete(Vente a)
        {
            throw new NotImplementedException();
        }

        public void Update(Vente v)
        {
            throw new NotImplementedException();
        }

        // Recherche
        public Vente GetById(object id)
        {
            using (BricachocContext db = new BricachocContext())
            {
                try
                {
                    int numv = (int)id;
                    var v = db.Ventes.Find(numv);
                    return v;
                }
                catch (System.Exception ex)
                {
                    throw new DaoExceptionAfficheMessage(ex.Message);
                }

            }
        }

        public ICollection<Vente> GetAll()
        {
            throw new NotImplementedException();
        }

      

    }
}

