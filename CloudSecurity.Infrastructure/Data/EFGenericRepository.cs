using CloudSecurity.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudSecurity.Infrastructure.Data
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        DbContext _context;
        DbSet<TEntity> _dbSet;

        public EFGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            throw new NotImplementedException();
        }

        public TEntity FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
