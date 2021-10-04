using Pelicari.PredictScore.Data.Models;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Core.Services.Interfaces
{
    public interface IScheduleService : IService<Schedule>
    {
        Task AddGroupAsync(int scheduleId, int groupId);
    }
}
