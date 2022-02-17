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
    public class StoneShapeController : ControllerBase
    {
        private readonly IStoneShapeService _stoneShapeService;
        public StoneShapeController(IStoneShapeService stoneShapeService)
        {
            _stoneShapeService = stoneShapeService;
        }
        [HttpPost]
        [Route("CreateStoneShape")]
        public async Task<IActionResult> CreateStoneShape(StoneShapeDto stoneShape)
        {
            try
            {
                if (!await _stoneShapeService.IsStoneShapeExist(stoneShape.ShapeName))
                {
                    bool result = await _stoneShapeService.CreateStoneShape(stoneShape);
                    if (result)
                    {
                        return Ok(new OkResponse(CommonResource.StoneShapeSaved));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, CommonResource.Wrong);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, CommonResource.StoneShapeExists);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetAllStoneShapes")]
        public async Task<IActionResult> GetAllStoneShapes()
        {
            try
            {
                return Ok(new OkResponse(CommonResource.Success, await _stoneShapeService.GetAllStoneShapes()));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetStoneShapeById")]
        public async Task<IActionResult> GetStoneShapeById(int? id)
        {
            try
            {
                return Ok(new OkResponse(CommonResource.Success, await _stoneShapeService.GetStoneShapeById(id)));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateStoneShape")]
        public async Task<IActionResult> UpdateStoneShape(StoneShapeDto stoneShape)
        {
            try
            {
                bool result = await _stoneShapeService.UpdateStoneShape(stoneShape);
                if (result)
                {
                    return Ok(new OkResponse(CommonResource.StoneShapeUpdated));
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
        [HttpDelete]
        [Route("DeleteStoneShape")]
        public async Task<IActionResult> DeleteStoneShape(int? id)
        {
            try
            {
                bool result = await _stoneShapeService.DeleteStoneShape(id);
                if (result)
                {
                    return Ok(new OkResponse(CommonResource.StoneShapeDeleted));
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
