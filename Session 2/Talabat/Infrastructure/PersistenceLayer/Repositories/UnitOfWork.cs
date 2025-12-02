using DomanLayer.Contracts;
using DomanLayer.Models;
using PersistenceLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var TypeName = typeof(TEntity).Name;

            if (_repositories.ContainsKey(TypeName))
            {
                return (IGenericRepository<TEntity, TKey>)_repositories[TypeName];
            }
            else
            {
                var Repo = new GenericRepository<TEntity, TKey>(_dbContext);
                _repositories.Add(TypeName, Repo);

                return Repo;
            }
        }
        public async Task<int> SaveChangesAsync()
       => await _dbContext.SaveChangesAsync();
    }
}
