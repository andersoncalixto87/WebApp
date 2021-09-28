using System;
using System.Collections.Generic;

namespace WebApp.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
         void Add(TEntity obj);
         void Update(TEntity obj);
         void Remove(TEntity obj);
         IEnumerable<TEntity> GetAll();
         TEntity GetById(Guid Id);
    }
}