using AutoMapper;
using Common.CommonUtility;
using DrishtiGems.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dto;
using ServiceLayer.IServices;

namespace DrishtiGems.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(AuthenticateRequest authenticateRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userDetails = await _userService.GetUserDetails(authenticateRequest.Username);
                    var response = await _userService.Authenticate(authenticateRequest);
                    if (response == null)
                    {
                        return BadRequest(new { message = CommonResource.IncorrectCredentials });
                    }
                    string decryptPassword = EncryptionDecryption.Decrypt(userDetails.Password, Constants.EncryDecryKey);
                    if (!string.Equals(authenticateRequest.Password, decryptPassword))
                    {
                        return BadRequest(new { message = CommonResource.IncorrectCredentials });
                    }
                    else
                    {
                        return Ok(response);
                    }
                }
                else
                {
                    return BadRequest(new { message = CommonResource.IncorrectCredentials });
                }
            }
            catch
            {
                throw;
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> SaveUser(UserModel userModel)
        {
            try
            {
                UserDto userDto = _mapper.Map<UserDto>(userModel);
                userDto.PasswordHash = EncryptionDecryption.Encrypt(userModel.Password, Constants.EncryDecryKey);
                bool isUserSaved = await _userService.SaveUser(userDto);
                if (isUserSaved)
                {
                    return Ok(CommonResource.UserSaved);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, CommonResource.Wrong);
                }
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var allUsers = await _userService.GetAllUsers();
                return Ok(new { data = allUsers, message = CommonResource.UserFetched, StatusCode = StatusCodes.Status200OK });
            }
            catch
            {
                throw;
            }
        }

    }
}
