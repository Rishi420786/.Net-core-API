using Domain.Entities;
using ServiceLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IServices
{
    public interface IUserService
    {
        Task<TblUser> GetById(int id);
        Task<UserDto> GetUserDetails(string username);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<bool> SaveUser(UserDto user);
        Task<IList<UserDto>> GetAllUsers();
    }
}
