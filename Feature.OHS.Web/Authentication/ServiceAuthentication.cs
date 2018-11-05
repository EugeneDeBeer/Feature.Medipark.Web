using Feature.OHS.Web.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feature.OHS.Web.Authentication
{
    public class ServiceAuthentication : IServiceAuthentication
    {
        private const string secretKey = "2618785E94AD41EDF4056F3C04848021ADF7913795770639E1CD86E7037A952D1E5127968395FD6EB3196FB25A4AADF0E8032AAC16C62141B5033693502C89CC";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

        public string GenerateToken(string issuer, string audience, TimeSpan expirationMinutes)
        {
            var now = DateTime.UtcNow.AddMinutes(-5);

            SigningCredentials signature = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256Signature);
            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                notBefore: now,
                expires: now.Add(expirationMinutes),
                signingCredentials: signature);


            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
            // Serialize and return the response
            //context.Response.ContentType = "application/json";
            // await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
    }
}
