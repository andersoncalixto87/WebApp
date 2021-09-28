using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Interfaces;

namespace WebApp.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public WebAppContext _webAppContext { get; }

        public Repository(WebAppContext webAppContext)
        {
            _webAppContext = webAppContext;

        }

        public void Add(TEntity obj)
        {
            try
            {
                _webAppContext.Set<TEntity>().Add(obj);
                _webAppContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _webAppContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(Guid Id)
        {
            return _webAppContext.Set<TEntity>().Find(Id);
        }

        public void Remove(TEntity obj)
        {
            try
            {
                _webAppContext.Set<TEntity>().Remove(obj);
                _webAppContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                _webAppContext.Entry(obj).State = EntityState.Modified;
                _webAppContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}