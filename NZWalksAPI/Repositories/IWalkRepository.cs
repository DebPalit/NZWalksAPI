using NZWalksAPI.Models;

namespace NZWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAsc = true, int pageNumber = 1, int pageSize = 1000);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk?> CreateAsync(Walk walk);
        Task<Walk?> UpdateByIdAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
