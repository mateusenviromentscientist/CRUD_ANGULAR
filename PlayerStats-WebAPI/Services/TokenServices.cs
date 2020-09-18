using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PlayerStats_WebAPI.Services
{
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim []
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString())
                }),
                Expires = System.DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = TokenHandler.CreateToken(tokenDescriptor);
            return TokenHandler.WriteToken(token);
        }
    }
}