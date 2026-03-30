using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Services
{
    public interface IAuthSercive
    {
        Task<string> RegisterAsync(RegisterRequestDto registerRequestDto);
        Task<string> LoginAsync(LoginRequestDto loginRequestDto);
    }
}
