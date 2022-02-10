using AutoMapper;
using Common.CommonUtility;
using Domain.DataContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.Dto;
using ServiceLayer.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiceLayer.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _dBContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UserService(ApplicationDBContext dBContext, IConfiguration configuration, IMapper mapper)
        {
            _dBContext = dBContext;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<TblUser> GetById(int id)
        {
            return await _dBContext.tblUsers.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<UserDto> GetUserDetails(string username)
        {
            var userDetails = await _dBContext.tblUsers.Where(x => x.Username == username).FirstOrDefaultAsync();
            UserDto user = _mapper.Map<UserDto>(userDetails);
            return user;
        }
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _dBContext.tblUsers.SingleOrDefaultAsync(x => x.Username == model.Username.ToLower());
            if (user == null)
            {
                return null;
            }
            else
            {
                var token = GenerateJwtToken(user);

                return new AuthenticateResponse(user, token);
            }
        }
        public async Task<bool> SaveUser(UserDto user)
        {
            if (user != null)
            {
                TblUser tblUser = _mapper.Map<TblUser>(user);
                tblUser.Password = user.PasswordHash;
                tblUser.CreatedDateTime = DateTime.Now;
                tblUser.LastUpdatedDateTime = DateTime.Now;
                await _dBContext.AddAsync(tblUser);
                bool result = Convert.ToBoolean(await _dBContext.SaveChangesAsync());
                return result;
            }
            else
            {
                return false;
            }
        }
        public async Task<IList<UserDto>> GetAllUsers()
        {
            return _mapper.Map<IList<UserDto>>(await _dBContext.tblUsers.ToListAsync());
        }
        private string GenerateJwtToken(TblUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[Constants.JwtKeyPath]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new ClaimsIdentity(new[] { new Claim(Constants.UserId, user.Id.ToString()) });
            claims.AddClaim(new Claim(Constants.RoleId, user.RoleId.ToString()));
            var token = new JwtSecurityToken(_configuration[Constants.JwtIssuerPath],
              _configuration[Constants.JwtIssuerPath],
              claims.Claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
