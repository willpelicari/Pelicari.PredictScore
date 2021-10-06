using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Core.Services
{
    public class SeasonService : Service<Season>, ISeasonService
    {
        private readonly IRepository<Season> _seasonRepository;
        private readonly IGroupService _groupService;

        public SeasonService(IRepository<Season> seasonRepository, IGroupService groupService) : base(seasonRepository)
        {
            _seasonRepository = seasonRepository;
            _groupService = groupService;
        }

        public async Task AddGroupAsync(int seasonId, int groupId)
        {
            var season = await _seasonRepository.GetByIdAsync(seasonId);
            if (season == null)
                throw new ArgumentException($"season {seasonId} was not found");

            var group = await _groupService.GetAsync(groupId);
            if (group == null)
                throw new ArgumentException($"group {groupId} was not found");

            season.Groups.Add(group);
            await base.UpdateAsync(season);
        }
    }
}
