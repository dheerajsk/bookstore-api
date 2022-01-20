using Ehealthcare.Entities.Dto;
using EHealthcare.Entities;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ehealthcare.Api
{
    public class AuthService
    {
        private readonly IBaseRepository<User> UserRepository;
        public AuthService(IBaseRepository<User> UserRepo)
        {
            UserRepository = UserRepo;
        }

        public async Task<AuthUserModel> Authenticate(LoginDto login)
        {
            User result = null;
            if (login.Type == "admin")
            {

                result = UserRepository.Get().Where(u => u.Email == login.Email && u.Password == login.Password && u.IsAdmin).FirstOrDefault();
            }
            else
            {
                result = UserRepository.Get().Where(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefault();
            }
            if (result is null)
            {
                return null;
            }
            return await this.AddJWTToken(result).ConfigureAwait(true);
        }

        public async Task<AuthUserModel> AddJWTToken(User user)
        {
            AuthUserModel model = new AuthUserModel();
            await Task.Run(() =>
            {
                if (user != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("this is a secret for the demo purpose, please change in produ.");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                        }),
                        Expires = DateTime.UtcNow.AddHours(4),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    model.AccessToken = tokenHandler.WriteToken(token);
                    model.FirstName = user.FirstName;
                    model.LastName = user.LastName;
                    model.IsAdmin = user.IsAdmin;
                }
            }).ConfigureAwait(true);
            return model;
        }
    }
}
