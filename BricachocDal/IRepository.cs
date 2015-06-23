using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BricachocDal
{
    public interface IRepository<T> where T : class 
    {
        void Insert(T obj);
        void Delete(T obj);
        void Update(T obj);
        ICollection<T> GetAll();
        T GetById(object id);
    }
}
