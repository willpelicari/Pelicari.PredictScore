using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Core.Services
{
    public class GroupService : Service<Group>, IService<Group>, IGroupService
    {
        private IRepository<Schedule> _scheduleRepository;
        private IRepository<Group> _groupRepository;
        private IRepository<User> _userRepository;

        public GroupService(IRepository<Group> groupRepository, IRepository<User> userRepository, IRepository<Schedule> scheduleRepository) : base(groupRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async override Task AddAsync(Group entity)
        {
            var admin = await _userRepository.GetByIdAsync(entity.AdminId);
            if (admin == null)
                throw new ArgumentException("AdminId is not valid");

            var schedule = await _scheduleRepository.GetByIdAsync(entity.ScheduleId);
            if (schedule == null)
                throw new ArgumentException("ScheduleId is not valid");
            entity.Schedule = schedule;

            var users = entity.Users.Select(u => Validate(u.Id, _userRepository.GetByIdAsync(u.Id)).Result);
            entity.Users = users;

            await base.AddAsync(entity);
        }

        private Task<User> Validate(int userId, Task<User> user)
        {
            if (user == null)
                throw new ArgumentException($"UserId {userId} is not valid");
            return user;
        }
    }
}
