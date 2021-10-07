using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Models.Context;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Data.Repositories
{
    public class RoundRepository : Repository<Round>
    {
        public RoundRepository(PredictScoreContext context) : base(context)
        {
        }

        public override Task<Round> AddAsync(Round entity)
        {
            return base.AddAsync(entity);
        }
    }
}
