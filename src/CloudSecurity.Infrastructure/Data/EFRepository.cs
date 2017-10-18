using CloudSecurity.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CloudSecurity.Core.SharedKernel;

namespace CloudSecurity.Infrastructure.Data
{
    public class EFRepository<TEntity> : IRepository<TEntity>, IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<TEntity> ListAll()
        {
            return _dbSet.AsEnumerable();
        }

        public async Task<List<TEntity>> ListAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IEnumerable<TEntity> List(ISpecification<TEntity> specification)
        {
            var queryableResultWithIncludes = specification.Includes
                .Aggregate(_dbSet.AsQueryable(),
                (current, include) => current.Include(include));
            var secondaryResult = specification.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                (current, include) => current.Include(include));
            return secondaryResult
                .Where(specification.Criteria)
                .AsEnumerable();
        }

        public async Task<List<TEntity>> ListAsync(ISpecification<TEntity> specification)
        {
            var queryableResultWithIncludes = specification.Includes
                .Aggregate(_dbSet.AsQueryable(),
                (cuurent, include) => cuurent.Include(include));
            var secondaryResult = specification.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                (current, include) => current.Include(include));
            return await secondaryResult
                .Where(specification.Criteria)
                .ToListAsync();
        }

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        /*
        //DbContext _context;
        //DbSet<TEntity> _dbSet;

        //public EFGenericRepository(DbContext context)
        //{
        //    _context = context;
        //    _dbSet = context.Set<TEntity>();
        //}

        //public void Create(TEntity item)
        //{
        //    _dbSet.Add(item);
        //    _context.SaveChanges();

        //}

        //public TEntity FindById(int id)
        //{
        //    return _dbSet.Find(id);
        //}

        //public IEnumerable<TEntity> Get()
        //{
        //    return _dbSet.AsNoTracking().ToList();
        //}

        //public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        //{
        //    return _dbSet.AsNoTracking().Where(predicate).ToList();
        //}

        //public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        //{
        //    return Include(includeProperties).ToList();
        //}

        //public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        //{
        //    var query = Include(includeProperties);
        //    return query.Where(predicate).ToList();
        //}

        //public void Remove(TEntity item)
        //{
        //    _context.Entry(item).State = EntityState.Deleted;
        //}

        //public void Update(TEntity item)
        //{
        //    _context.Entry(item).State = EntityState.Modified;
        //    _context.SaveChanges();
        //}

        //private IQueryable<TEntity> Include(params Expression<Func<TEntity,object>>[] includeProperties)
        //{
        //    IQueryable<TEntity> query = _dbSet.AsNoTracking();
        //    return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        //}
        */
    }
}
