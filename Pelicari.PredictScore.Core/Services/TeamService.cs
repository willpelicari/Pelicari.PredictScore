using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Repositories.Interfaces;

namespace Pelicari.PredictScore.Core.Services
{
    public class TeamService : Service<Team>, IService<Team>
    {
        public TeamService(IRepository<Team> teamRepository) : base(teamRepository)
        {
        }
    }
}
