﻿using Pelicari.PredictScore.Core.Services.Interfaces;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Core.Services
{
    public class GroupService : Service<Group>, IGroupService
    {
        private IRepository<Group> _groupRepository;
        private IRepository<Schedule> _scheduleRepository;
        private IUserService _userService;

        public GroupService(IRepository<Group> groupRepository, IRepository<Schedule> scheduleRepository, IUserService userService) : base(groupRepository)
        {
            _groupRepository = groupRepository;
            _scheduleRepository = scheduleRepository;
            _userService = userService;
        }

        public async override Task AddAsync(Group group)
        {
            var admin = await _userService.GetAsync(group.AdminId);
            if (admin == null)
                throw new ArgumentException("AdminId is not valid");

            var users = group.Users.Select(u => _userService.GetAsync(u.Id).Result).ToArray();
            group.Users = users;

            var schedules = group.Schedules.Select(u => _scheduleRepository.GetByIdAsync(u.Id).Result).ToArray();
            group.Schedules = schedules;

            await base.AddAsync(group);
        }

        public async Task AddUserAsync(int groupId, int userId)
        {
            var group = await _groupRepository.GetByIdAsync(groupId);
            if (group == null)
                throw new ArgumentException($"group {groupId} was not found");

            var user = await _userService.GetAsync(userId);
            if (user == null)
                throw new ArgumentException($"user {userId} was not found");

            group.Users?.Add(user);
            await base.UpdateAsync(group);
        }
    }
}
