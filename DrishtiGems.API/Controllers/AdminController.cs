using Common.CommonUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dto;
using ServiceLayer.IServices;

namespace DrishtiGems.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(RolesDto roles)
        {
            try
            {
                bool isRoleCreated=await _adminService.CreateRole(roles);
                if(isRoleCreated)
                {
                    return Ok(new OkResponse(CommonResource.RoleSaved));
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, CommonResource.Wrong);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                return Ok(new OkResponse(CommonResource.RolesFetched, await _adminService.GetRoleDetails()));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
