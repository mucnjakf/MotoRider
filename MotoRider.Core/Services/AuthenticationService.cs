using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MotoRider.Core.Services.Interfaces;
using MotoRider.Shared.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MotoRider.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public AuthenticationService(IConfiguration config, IUserService userService)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public string Authenticate(string username, string password)
        {
            User user = _userService.GetUser(username, password);

            if (user is null)
            {
                return "";
            }

            JwtSecurityTokenHandler tokenHandler = new();
            byte[] tokenKey = Encoding.ASCII.GetBytes(_config["TokenKey"]);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
