using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Models.Context;
using Pelicari.PredictScore.Data.Repositories.Interfaces;

namespace Pelicari.PredictScore.Data.Repositories
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(PredictScoreContext dbContext) : base(dbContext)
        {
        }
    }
}
