using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models;

namespace NZWalksAPI.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _dbcontext;

        public SQLWalkRepository(NZWalksDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await _dbcontext.Walks.Include("Region").Include("Difficulty").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Walks.Include("Region").Include("Difficulty").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> CreateAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await _dbcontext.Walks.AddAsync(walk);
            await _dbcontext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> UpdateByIdAsync(Guid id, Walk walk)
        {
            Walk? ExistingWalk = await _dbcontext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (ExistingWalk == null)
            {
                return null;
            }
            ExistingWalk.Name = walk.Name;
            ExistingWalk.Description = walk.Description;
            ExistingWalk.LengthInKm = walk.LengthInKm;
            ExistingWalk.RegionId = walk.RegionId;
            ExistingWalk.DifficultyId = walk.DifficultyId;
            await _dbcontext.SaveChangesAsync();
            return ExistingWalk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            Walk? ExistingWalk = await _dbcontext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (ExistingWalk == null)
            {
                return null;
            }
            _dbcontext.Walks.Remove(ExistingWalk);
            await _dbcontext.SaveChangesAsync();
            return ExistingWalk;
        }
    }
}
