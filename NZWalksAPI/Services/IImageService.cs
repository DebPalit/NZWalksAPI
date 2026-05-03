
using Microsoft.AspNetCore.Http.HttpResults;
using NZWalksAPI.Models;
using NZWalksAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NZWalksAPI.Services
{
    public interface IImageService
    {
        Task<Image?> UploadAsync(ImageUploadRequestDto imageUploadRequestDto, ModelStateDictionary modelState);
    }
}