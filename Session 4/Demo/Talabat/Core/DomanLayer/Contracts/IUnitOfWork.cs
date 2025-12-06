using DomainLayer.Contracts;
using DomanLayer.Models;

namespace DomanLayer.Contracts
{
    public interface IUnitOfWork
    {
        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;

        Task<int> SaveChangesAsync();
    }
}
