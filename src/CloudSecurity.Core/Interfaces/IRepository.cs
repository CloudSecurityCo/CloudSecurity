using CloudSecurity.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CloudSecurity.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> ListAll();
        IEnumerable<TEntity> List(ISpecification<TEntity> specification);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        
        //void Create(TEntity item);
        //TEntity FindById(int id);
        //IEnumerable<TEntity> Get();
        //IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        //IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        //IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
        //    params Expression<Func<TEntity, object>>[] includeProperties);
        //void Remove(TEntity item);
        //void Update(TEntity item);
    }
}
