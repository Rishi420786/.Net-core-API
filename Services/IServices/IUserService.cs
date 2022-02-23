using Domain.Entities;
using ServiceLayer.Dto;

namespace ServiceLayer.IServices
{
    public interface IUserService
    {
        Task<TblUser> GetById(int id);
        Task<UserDto> GetUserDetails(string username);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<bool> AddRecord(UserDto user);
        Task<IList<UserDto>> GetAllRecords();
    }
}
