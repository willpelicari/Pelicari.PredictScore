using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Core.Services
{
    public interface IGroupService : IService<Group>
    {
        new Task AddAsync(Group entity);
    }
}