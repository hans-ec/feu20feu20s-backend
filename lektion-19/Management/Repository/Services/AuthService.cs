using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace Repository.Services
{
    public interface IAuthService
    {
        public byte[][] GenerateHash(string value);
        public bool ValidateHash(string value, byte[] hash, byte[] salt);
        public string GenerateJwtToken(string userId);
        public bool ValidateJwtToken(string jwtToken);
    }


    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        #region GenerateHash
        public byte[][] GenerateHash(string value)
        {
            byte[][] result = new byte[2][];

            using var hmac = new HMACSHA512();
            result[0] = hmac.Key;
            result[1] = hmac.ComputeHash(Encoding.UTF8.GetBytes(value));

            return result;
        }
        #endregion

        #region ValidateHash
        public bool ValidateHash(string value, byte[] hash, byte[] salt)
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
        #endregion

        #region GenerateJwtToken
        public string GenerateJwtToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.AddHours(1),
                Subject = new ClaimsIdentity(new Claim[] { new Claim("UserId", userId) }),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("SecretKey").Value)),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
        #endregion

        #region ValidateJwtToken
        public bool ValidateJwtToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("SecretKey").Value)),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = true
            };

            var claims = tokenHandler.ValidateToken(jwtToken, validations, out var tokenSecure);
            var expiration = claims.Claims.First(x => x.Type == "exp").Value;

            if (long.Parse(expiration) > DateTimeOffset.Now.ToUnixTimeSeconds())
                return true;

            return false;
        }
        #endregion

    }
}
