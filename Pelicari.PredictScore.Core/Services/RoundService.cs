using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Core.Services
{
    public class RoundService : Service<Round>
    {
        private readonly IService<Match> _matchService;

        public RoundService(IRepository<Round> roundRepository, IService<Match> matchService) : base(roundRepository)
        {
            _matchService = matchService;
        }

        public override async Task AddAsync(Round round)
        {
            await base.AddAsync(round);
        }
    }
}
