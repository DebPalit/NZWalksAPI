using NZWalksAPI.Models;
namespace NZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region?> GetByNameAsync(string name);
        Task<Region?> GetByCodeAsync(string code);
        Task<Region?> CreateAsync(Region region);
        Task<Region?> UpdateByIdAsync(Guid id, Region region);
        Task<Region?> DeleteAsync(Guid id);
    }
}
