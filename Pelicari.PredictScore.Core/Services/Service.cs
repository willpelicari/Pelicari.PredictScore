using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Core.Services
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class, new()
    {
        private IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public virtual Task<TEntity> GetAsync(int teamId)
        {
            return _repository.GetByIdAsync(teamId);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
