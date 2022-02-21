using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebsiteForms.Helpers
{
    public static class JwtUtils
    {
        private static string Secretkey { get => Environment.GetEnvironmentVariable("SECRET_KEY"); }
        private static string AudienceToken { get => Environment.GetEnvironmentVariable("AUDIENCE_TOKEN"); }
        private static string IssuerToken { get => Environment.GetEnvironmentVariable("ISSUER_TOKEN"); }
        private static string ExpireTime { get => Environment.GetEnvironmentVariable("EXPIRE_TOKEN_MINUTES"); }

        public static string Generate(int id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secretkey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(ExpireTime)),
                Issuer = IssuerToken,
                Audience = AudienceToken,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static int? Verify(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secretkey);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = AudienceToken,
                    ValidIssuer = IssuerToken,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                return userId;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
