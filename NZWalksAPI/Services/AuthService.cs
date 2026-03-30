using Microsoft.AspNetCore.Identity;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Services
{
    public class AuthService : IAuthSercive
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthService(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        public async Task<string> RegisterAsync(RegisterRequestDto registerRequestDto)
        {
            var user = new IdentityUser { UserName = registerRequestDto.Username, Email = registerRequestDto.Username };
            var result = await userManager.CreateAsync(user, registerRequestDto.Password);

            if (!result.Succeeded)
                return "Registration failed. Check your details and try again.";

            var roleResult = await userManager.AddToRoleAsync(user, "Reader");

            if (!roleResult.Succeeded)
                return "Registration failed. Check your details and try again.";
            else
                return "User Successfully Registered";
        }

        public async Task<string> LoginAsync(LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByNameAsync(loginRequestDto.Username);

            if (user == null || !await userManager.CheckPasswordAsync(user, loginRequestDto.Password))
            {
                return null;
            }

            var roles = await userManager.GetRolesAsync(user);

            return tokenRepository.CreateJWTToken(user, roles.ToList());
        }
    }
}
