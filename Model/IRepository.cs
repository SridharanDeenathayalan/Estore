using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Estore.Model
{
    public interface IRepository<T> where T:class
    {
        Task<List<T>> GetAll(params Expression<Func<T, object>>[] includes);
        //Task<List<T>> GetAllWithFeatures(int pageindex = 1, int pagesize = 6,int brandid=0,int typename=0, params Expression<Func<T, object>>[] includes);
        Task<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task Add(T entity);
        void Update(T entity);
        void Remove(T entity);

        Task<List<T>> GetAll();
        
    }
}
