using NZWalksAPI.Models;
namespace NZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region?> GetRegionByIdAsync(Guid id);
    }
}
