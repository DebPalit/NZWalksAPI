using Azure.Core;
using NZWalksAPI.Models;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NZWalksAPI.Services
{
    public class ImageService : IImageService
    {
        private static readonly string[] AllowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
        private const long MaxFileSizeBytes = 10 * 1024 * 1024; // 10 MB

        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public Task<Image?> UploadAsync(ImageUploadRequestDto imageUploadRequestDto, ModelStateDictionary modelState)
        {
            //Validate Extension
            var extension = Path.GetExtension(imageUploadRequestDto.File.FileName).ToLowerInvariant();
            if(!AllowedExtensions.Contains(extension))
            {
                modelState.AddModelError("file", "Unsupported file type. Only .jpg, .jpeg, and .png files are allowed.");
            }
            if(imageUploadRequestDto.File.Length > MaxFileSizeBytes)
            {
                modelState.AddModelError("file", "File size exceeds the maximum allowed size of 10 MB.");
            }

            if (!modelState.IsValid)
            {
                return Task.FromResult<Image?>(null);
            }

            Image image = new()
            {
                Id = Guid.NewGuid(),
                File = imageUploadRequestDto.File,
                FileName = imageUploadRequestDto.FileName,
                FileExtension = extension,
                FileSizeInBytes = imageUploadRequestDto.File.Length,
                FileDescription = imageUploadRequestDto.FileDescription
            };

            return _imageRepository.UploadImageAsync(image);
        }
    }
}