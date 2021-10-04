using Microsoft.EntityFrameworkCore;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Models.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pelicari.PredictScore.Data.Repositories
{
    public class GroupRepository : Repository<Group>
    {
        public GroupRepository(PredictScoreContext dbContext) : base(dbContext)
        {
        }

        public async override Task<Group> GetByIdAsync(int id)
        {
            return await IncludeRelatedData().FirstOrDefaultAsync(g => g.Id == id);
        }

        public override IQueryable<Group> GetAll()
        {
            return IncludeRelatedData();
        }

        public async override Task<Group> UpdateAsync(Group entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                var entry = _dbContext.Groups.Include(g => g.Users).First(e => e.Id == entity.Id);

                entry.AdminId = entity.AdminId;
                entry.Name = entity.Name;
                UpdateUsers(entry, entity);
                UpdateSchedules(entry, entity);

                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        private void UpdateSchedules(Group original, Group modified)
        {
            var newScheduleList = modified.Schedules.Select(ue => ue.Id);

            var entriesToRemove = original.Schedules.Where(u => !newScheduleList.Contains(u.Id)).ToList();
            foreach (var entryRemoved in entriesToRemove)
                original.Schedules.Remove(entryRemoved);

            var entriesToAdd = newScheduleList.Except(original.Schedules.Select(u => u.Id));
            foreach (var schedule in _dbContext.Schedules.Where(u => entriesToAdd.Contains(u.Id)))
                original.Schedules.Add(schedule);
        }

        private void UpdateUsers(Group original, Group modified)
        {
            var newUserList = modified.Users.Select(ue => ue.Id);

            var entriesToRemove = original.Users.Where(u => !newUserList.Contains(u.Id)).ToList();
            foreach (var entryRemoved in entriesToRemove)
                original.Users.Remove(entryRemoved);

            var entriesToAdd = newUserList.Except(original.Users.Select(u => u.Id));
            foreach (var user in _dbContext.Users.Where(u => entriesToAdd.Contains(u.Id)))
                original.Users.Add(user);
        }

        private IQueryable<Group> IncludeRelatedData()
        {
            return _dbContext.Groups.Include(g => g.Users).Include(g => g.Admin);
        }
    }
}
