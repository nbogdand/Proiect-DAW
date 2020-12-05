using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BasketballSeason.Helpers;
using BasketballSeason.Mapper;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs;
using BasketballSeason.Models.DTOs.UserDTOs;
using BasketballSeason.Repositories;
using BasketballSeason.Repositories.UserRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BasketballSeason.Services.UserS
{
    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public UserService(
            IOptions<AppSettings> appSettings, 
            IUserRepository userReposiotry, 
            ILogger<UserService> logger
        ) {
            _appSettings = appSettings.Value;
            _userRepository = userReposiotry;
            _logger = logger;
        }
        public bool Register(CreateUserRequestDTO model)
        {
            try {
                var existingUser = _userRepository.GetAllAsQuerable()
                 .Where(u => (u.Email == model.Email || u.Username == model.Username))
                 .FirstOrDefault();

                if (existingUser != null)
                {
                    return false;
                }

                _userRepository.Create(model.ToUser());
                return _userRepository.Save();
                
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return false;
            }
        }

        public UserResponseDTO Authentificate(UserRequestDTO model)
        {
            var user = _userRepository.GetAllAsQuerable()
                .SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null) return null;

            var token = GenerateUserJWTToken(user);

            return new UserResponseDTO(user, token);
        }

        private string GenerateUserJWTToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            try
            {
                return _userRepository.FindById(id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}\r\n{ex.StackTrace}");
                return null;
            }
        }
    }
}
