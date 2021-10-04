using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Core.Services
{
    public class ScheduleService : Service<Schedule>, IScheduleService
    {
        private readonly IRepository<Schedule> _scheduleRepository;
        private readonly IGroupService _groupService;

        public ScheduleService(IRepository<Schedule> scheduleRepository, IGroupService groupService) : base(scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
            _groupService = groupService;
        }

        public async Task AddGroupAsync(int scheduleId, int groupId)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(scheduleId);
            if (schedule == null)
                throw new ArgumentException($"schedule {scheduleId} was not found");

            var group = await _groupService.GetAsync(groupId);
            if (group == null)
                throw new ArgumentException($"group {groupId} was not found");

            schedule.Groups.Add(group);
            await base.UpdateAsync(schedule);
        }
    }
}
