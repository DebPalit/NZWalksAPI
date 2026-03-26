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

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> GetByNameAsync(string name)
        {
            return await _dbcontext.Regions.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Region?> GetByCodeAsync(string code)
        {
            return await _dbcontext.Regions.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<Region?> CreateAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await _dbcontext.Regions.AddAsync(region);
            await _dbcontext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateByIdAsync(Guid id, Region region)
        {
            Region? ExistingRegion = await _dbcontext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (ExistingRegion == null)
            {
                return null;
            }

            ExistingRegion.Code = region.Code;
            ExistingRegion.Name = region.Name;
            ExistingRegion.RegionImageUrl = region.RegionImageUrl;

            await _dbcontext.SaveChangesAsync();
            return ExistingRegion;

        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            Region? ExistingRegion = await _dbcontext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (ExistingRegion == null)
            {
                return null;
            }
            _dbcontext.Regions.Remove(ExistingRegion);
            await _dbcontext.SaveChangesAsync();
            return ExistingRegion;
        }
    }
}
