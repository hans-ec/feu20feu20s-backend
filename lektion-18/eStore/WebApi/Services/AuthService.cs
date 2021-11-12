using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Text;

namespace WebApi.Services
{

    public interface IAuthService
    {
        public bool CompareHash(string value, byte[] hash, byte[] salt);
        public void GenerateHash(string value, out byte[] hash, out byte[] salt);
        public string GenerateJwtToken(string userId);
        public bool ValidateJwtToken(string jwtToken);
    }

    public class AuthService : IAuthService
    {
        private readonly string secretKey = "dethärärensäkerhetsnyckeldenmåstevaralång";

        public bool CompareHash(string value, byte[] hash, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                var computed = hmac.ComputeHash(Encoding.UTF8.GetBytes(value));
                for (int i = 0; i < computed.Length; i++)
                    if (computed[i] != hash[i])
                        return false;
            }

            return true;
        }

        public void GenerateHash(string value, out byte[] hash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(value));
        }






        public string GenerateJwtToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddHours(1),
                Subject = new ClaimsIdentity(new Claim[] { new Claim("UserId", userId) }),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(secretKey)),
                        SecurityAlgorithms.HmacSha512Signature
                )
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }

        public bool ValidateJwtToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var claims = tokenHandler.ValidateToken(jwtToken, validations, out var tokenSecure);
            var expiration = claims.Claims.First(x => x.Type == "exp").Value;

            if (long.Parse(claims.Claims.First(x => x.Type == "exp").Value) > DateTimeOffset.Now.ToUnixTimeSeconds())
                return true;

            return false;
        }


        public ClaimsPrincipal ReadJwtToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            };

            return tokenHandler.ValidateToken(jwtToken, validations, out var tokenSecure);
        }
    }
}
