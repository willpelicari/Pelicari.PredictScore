using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Models.Context;
using Pelicari.PredictScore.Data.Repositories.Interfaces;

namespace Pelicari.PredictScore.Data.Repositories
{
    public class TeamRepository : Repository<Team>, IRepository<Team>
    {
        public TeamRepository(PredictScoreContext dbContext) : base(dbContext)
        {
        }
    }
}
