using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models;
namespace NZWalksAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbcontext;

        public SQLRegionRepository(NZWalksDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // Get all regions from the database
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _dbcontext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await _dbcontext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
