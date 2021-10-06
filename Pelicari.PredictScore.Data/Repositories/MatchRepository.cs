using Microsoft.EntityFrameworkCore;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Models.Context;
using System.Linq;

namespace Pelicari.PredictScore.Data.Repositories
{
    public class MatchRepository : Repository<Match>
    {
        public MatchRepository(PredictScoreContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Match> GetAll()
        {
            return _dbContext.Set<Match>().Include(g => g.HomeTeam).Include(g => g.GuestTeam);
        }
    }
}
