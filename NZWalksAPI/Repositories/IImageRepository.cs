using NZWalksAPI.Models;
namespace NZWalksAPI.Repositories
{
    public interface IImageRepository
    {
        Task<Image> UploadImageAsync(Image image);
    }
}
