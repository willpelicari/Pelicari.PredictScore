using Microsoft.EntityFrameworkCore;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Data.Models.Context;
using System;
using System.Collections.Generic;
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
                entry.ScheduleId = entity.ScheduleId;
                UpdateUsers(entry, entity.Users.Select(ue => ue.Id));

                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        private void UpdateUsers(Group entry, IEnumerable<int> usersList)
        {
            var entriesToRemove = entry.Users.Where(u => !usersList.Contains(u.Id)).ToList();
            foreach (var entryRemoved in entriesToRemove)
                entry.Users.Remove(entryRemoved);
        }

        private IQueryable<Group> IncludeRelatedData()
        {
            return _dbContext.Groups.Include(g => g.Users).Include(g => g.Admin);
        }
    }
}
