using Pelicari.PredictScore.Data.Models;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Core.Services.Interfaces
{
    public interface ISeasonService : IService<Season>
    {
        Task AddGroupAsync(int seasonId, int groupId);
    }
}
