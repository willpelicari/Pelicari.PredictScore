using Pelicari.PredictScore.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Core.Services.Interfaces
{
    public interface IService<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetAsync(int entityId);
        IEnumerable<TEntity> GetAll();
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}