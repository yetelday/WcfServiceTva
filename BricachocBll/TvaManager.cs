using System;
using System.Collections.Generic;
using System.Linq;
using BricachocBo;
using BricachocDal;

// Persistance


namespace BricachocBll
{
   public class TvaManager
   {
       // son repository
       IRepository<Tva> tvaDao;

       public TvaManager(IRepository<Tva> repos)
       {
           tvaDao = repos;
       }

       public ICollection<Tva> ChargerLesTvas()
       {
           return tvaDao.GetAll().ToList();
       }

       public void CreerTva(Tva t)
       {
           tvaDao.Insert(t);
       }

       public void MettreAJourTva(Tva t)
       {
           tvaDao.Update(t);
       }

       public void Supprimer(int id)
       {
           tvaDao.Delete(new Tva(){Code=id});
       }

       public Tva RechercherTva(int code)
       {
           return tvaDao.GetById(code);
       }

   }
}