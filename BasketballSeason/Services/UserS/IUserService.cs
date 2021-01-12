using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasketballSeason.Models;
using BasketballSeason.Models.DTOs;
using BasketballSeason.Models.DTOs.UserDTOs;

namespace BasketballSeason.Services.UserS
{
    public interface IUserService
    {
        UserResponseDTO Authentificate(UserRequestDTO model);
        IEnumerable<User> GetAllUsers();
        User GetById(Guid id);
        bool Register(CreateUserRequestDTO model);
        bool SaveFcmToken(SaveFcmTokenDTO model, Guid userId);
    }
}
