using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models;

namespace NZWalksAPI.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly NZWalksDbContext _context;
        public ImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor contextAccessor, NZWalksDbContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _contextAccessor = contextAccessor;
            _context = context;
        }
        public async Task<Image> UploadImageAsync(Image image)
        {
            string locaalFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images",
                $"{image.FileName}{image.FileExtension}");

            //Upload the image to the local path
            using var stream = new FileStream(locaalFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            //Build the URL path to access the image
            //e.g. https://localhost:7001/Images/myphoto.jpg

            var request = _contextAccessor.HttpContext!.Request;
            var urlFilePath = $"{request.Scheme}://{request.Host}{request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            //Save record to DB
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();

            return image;
        }
    }
}
