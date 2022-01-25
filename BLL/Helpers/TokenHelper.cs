using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using MMS.BLL.Interfaces;
using MMS.DAL.Entities;

namespace MMS.BLL.Helpers
{
    public class TokenHelper : ITokenHelper
    {
        private readonly IConfiguration config;
        private readonly UserManager<User> userManager;

        public TokenHelper(UserManager<User> userManager, IConfiguration config)
        { 
            this.userManager = userManager;
            this.config = config;
        }

        public async Task<string> CreateAccessToken(User user)
        {
            var userId = user.Id.ToString();
            var username = user.UserName.ToString();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, username)
            };

            var roles = await this.userManager.GetRolesAsync(user);
            foreach (var role in roles) claims.Add(new Claim(ClaimTypes.Role, role));

            var secret = this.config.GetSection("Jwt").GetSection("Token").Get<String>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(60),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string _token)
        {
            var tokenValidationParam = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Jwt:Token"])),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            IdentityModelEventSource.ShowPII = true;
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(_token, tokenValidationParam, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals("hs512", StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        
           }


    }
}
