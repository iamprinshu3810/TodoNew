using Manager.Implementation;
using Manager.Shared;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoListApi.Dto;
using ToDoListApi.Models;

namespace ToDoListApi.Service
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;
        IManagerShared _manager;
        public AuthenticateService(IOptions<AppSettings> appSettings,IManagerShared manager)
        {
            _appSettings = appSettings.Value;
            _manager = manager;
        }

        public UserCredentials Authenticate(string UserId, string password)
        {
            bool isTrue = _manager.CheckCredentials(UserId, password);
            if (isTrue)
            {
                UserCredentials user = new UserCredentials
                {
                    userId = UserId,
                    password = password
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.userId.ToString()),
                    new Claim(ClaimTypes.Role, "User")
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.token = tokenHandler.WriteToken(token);
                user.password = null;
                return user;
            }
            return null;
        }
    }
}
