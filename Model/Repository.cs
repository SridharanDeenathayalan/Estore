using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Estore.Model
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected StoreContext db { get; set; }
        protected DbSet<T> dbset;
        public Repository(StoreContext db) 
        {
            this.db = db;
            dbset = db.Set<T>();
        }
        public async Task<List<T>> GetAll()
        {
            return await dbset.ToListAsync();
        }

        public async Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> result = dbset;
            foreach (var item in includes)
            {
                result = result.Include(item);
            }
            return await result.ToListAsync();
        }

        //public  IQueryable<T> GetAllWithFeatures(params Expression<Func<T, object>>[] includes)
        //{
        //    IQueryable<T> result = dbset;
        //    foreach (var item in includes)
        //    {
        //        result = result.Include(item);
        //    } 
        //    return result;
        //}

        public async Task<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> result = dbset;
            foreach (var item in includes)
            {
                result = result.Include(item);
            }
            return await result.SingleOrDefaultAsync(predicate);
        }

        public async Task Add(T entity)
        {
            await dbset.AddAsync(entity);
            await db.SaveChangesAsync();
        }
        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }
        public void Update(T entity)
        {
            dbset.Update(entity);
        }
    }
}
