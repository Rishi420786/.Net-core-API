using Common.CommonUtility;
using Microsoft.AspNetCore.Authorization;
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
                if (!await _adminService.IsRoleExist(roles.RoleName))
                {
                    bool isRoleCreated = await _adminService.CreateRole(roles);
                    if (isRoleCreated)
                    {
                        return Ok(new OkResponse(CommonResource.RoleSaved));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, CommonResource.Wrong);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, CommonResource.RoleExists);
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
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CategoryDto category)
        {
            try
            {
                if (!await _adminService.IsCategoryExist(category.CategoryName))
                {
                    bool IsCategorySaved = await _adminService.CreateCategory(category);
                    if (IsCategorySaved)
                    {
                        return Ok(new OkResponse(CommonResource.CategoryCreated));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, CommonResource.Wrong);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, CommonResource.CategoryExists);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                return Ok(new OkResponse(CommonResource.Success, await _adminService.GetAllCategories()));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                return Ok(new OkResponse(CommonResource.Success, await _adminService.GetCategoryById(id)));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult>UpdateCategory(CategoryDto category)
        {
            try
            {
                bool result = await _adminService.UpdateCategory(category);
                if (result)
                {
                    return Ok(new OkResponse(CommonResource.CategoryUpdated));
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, CommonResource.CategoryExists);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                bool result = await _adminService.DeleteCategory(id);
                if (result)
                {
                    return Ok(new OkResponse(CommonResource.CategoryDeleted));
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, CommonResource.CategoryExists);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetCategoryColors")]
        public async Task<IActionResult> GetCategoryColors(int? id)
        {
            try
            {
                return Ok(new OkResponse(CommonResource.Success, await _adminService.GetCategoryColors(id)));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("CreateCategoryColor")]
        public async Task<IActionResult> CreateCategoryColor(AddCategoryColorDto addCategoryColor)
        {
            try
            {
                if (!await _adminService.IsColorExist(addCategoryColor.Name))
                {
                    bool result = await _adminService.CreateCategoryColor(addCategoryColor);
                    if (result)
                    {
                        return Ok(new OkResponse(CommonResource.CategoryColorSaved));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, CommonResource.Wrong);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, CommonResource.ColorExists);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeleteCategoryColor")]
        public async Task<IActionResult> DeleteCategoryColorById(int colorId)
        {
            try
            {
                bool result = await _adminService.DeleteCategoryColor(colorId);
                if (result)
                {
                    return Ok(new OkResponse(CommonResource.CategoryColorDeleted));
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
    }
}
