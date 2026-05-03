using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.DTO
{
    public class ImageUploadRequestDto
    {
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string? FileDescription { get; set; }

    }
}
