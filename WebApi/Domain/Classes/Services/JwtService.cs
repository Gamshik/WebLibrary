using Domain.Classes.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Domain.Classes.Services
{
    public class JwtService : IJwtService
    {
        private readonly ILoggerService _loggerService;
        private readonly string? _issuer;
        private readonly string? _audience;
        private readonly int _expireInDay;
        private readonly string? _securityKey;
        public JwtService(ILoggerService loggerService, IConfiguration configuration)
        {
            _loggerService = loggerService;

            var jwtSetting = configuration.GetSection("Jwt");

            _issuer = jwtSetting.GetSection("Issuer").Value;
            _audience = jwtSetting.GetSection("Audience").Value;
            _expireInDay = Int32.Parse(jwtSetting.GetSection("ExpiresInDay").Value);
            _securityKey = jwtSetting.GetSection("SecurityKey").Value;
        }
        public Jwt? CreateJwtToken()
        {
            var signingCredentials = GetSigningCredentials();

            var tokenOptions = GetTokenOptions(signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            _loggerService.LogInfo("Jwt token has been created!");

            return new Jwt { Token = token };
        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_securityKey);

            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private JwtSecurityToken GetTokenOptions(SigningCredentials mySigningCredentials)
        {
            return new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                expires: DateTime.Now.AddDays(_expireInDay),
                signingCredentials: mySigningCredentials
                );
        }
    }
}
