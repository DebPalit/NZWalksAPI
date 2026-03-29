using NZWalksAPI.Models;

namespace NZWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk?> CreateAsync(Walk walk);
        Task<Walk?> UpdateByIdAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
