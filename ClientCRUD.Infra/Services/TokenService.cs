using ClientCRUD.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClientCRUD.Infra.Services
{
    public class TokenService
    {
        public string Create(User user)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
            
            var handler = new JwtSecurityTokenHandler();
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(4),
                Subject = GenerateClaims(user),
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);

        }

        private ClaimsIdentity GenerateClaims(User user)
        {
            var ci = new ClaimsIdentity();

            ci.AddClaim(new Claim("_id", user.Id.ToString()));

            return ci;
        }
    }
}
