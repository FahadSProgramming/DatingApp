using DatingApp.Application.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.Application.Authentication
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey secretKey;
        public TokenService(SymmetricSecurityKey tokenGenerationKey)
        {
            secretKey = tokenGenerationKey;
        }
        public string GenerateToken(string[] arguments)
        {
            throw new NotImplementedException();
        }
    }
}
