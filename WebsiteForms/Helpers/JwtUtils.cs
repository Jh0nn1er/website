using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebsiteForms.Helpers
{
    public class JwtUtils
    {
        private string Secretkey { get; set; }
        private string AudienceToken { get; set; }
        private string IssuerToken { get; set; }
        private double ExpireTime { get; set; }

        public JwtUtils(AppSettings appSettings)
        {
            Secretkey = appSettings.SecretKey;
            AudienceToken = appSettings.AudienceToken;
            IssuerToken = appSettings.IssuerToken;
            ExpireTime = appSettings.ExpireTokenMinutes;
        }

        public string Generate(int id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secretkey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(ExpireTime),
                Issuer = IssuerToken,
                Audience = AudienceToken,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public int? Verify(string token)
        {
            if (token == null) return null;

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
            catch
            {
                return null;
            }
        }
    }
}
