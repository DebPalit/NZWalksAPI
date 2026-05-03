using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Services;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageUploadRequestDto)
        {
            var modelState = new ModelStateDictionary();
            var image = await _imageService.UploadAsync(imageUploadRequestDto, modelState);

            if (!modelState.IsValid)
            {
                return BadRequest(modelState);
            }

            return Ok(image);
        }
    }
}
