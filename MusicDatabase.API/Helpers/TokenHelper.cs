using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase.API
{
    public class TokenHelper
    {
        public static string GenerateToken(int UserId, string Username, string Email)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bhl1lIyDBPPyeXj8TCLnHd1YI1NMTD6S"));
            var claims = new Claim[] {
                new Claim("Id",UserId.ToString()),
                new Claim(ClaimTypes.Name, Username),
                new Claim(ClaimTypes.Email, Email)
            };
            var token = new JwtSecurityToken(
                issuer: "MusicDb",
                audience: "MusicDb",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(28),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
