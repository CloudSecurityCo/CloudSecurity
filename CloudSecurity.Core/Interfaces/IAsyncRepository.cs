using CloudSecurity.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CloudSecurity.Core.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity: BaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> ListAllAsync();
        Task<List<TEntity>> ListAsync(ISpecification<TEntity> specification);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
