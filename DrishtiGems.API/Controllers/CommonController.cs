using Common.CommonUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dto;
using ServiceLayer.IServices;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DrishtiGems.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CommonController : ControllerBase
    {
        private readonly IHostingEnvironment _env;
        private readonly ICommonService _commonService;
        private readonly IMailService _mailService;
        public CommonController(IHostingEnvironment env, ICommonService commonService, IMailService mailService)
        {
            _env = env;
            _commonService = commonService;
            _mailService = mailService;
        }
        /// <summary>
        /// This method is use to upload images.
        /// </summary>
        /// <param name="imageFile"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UploadImages")]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            try
            {
                string path = Path.Combine(_env.WebRootPath, Constants.ProductImages);
                string uniqueImageName = Guid.NewGuid().ToString() + Constants.Hyphen + imageFile.FileName;
                using (FileStream stream = new(Path.Combine(path, uniqueImageName), FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                return Ok(new { Message = CommonResource.ImageUploaded, StatusCode = StatusCodes.Status200OK, ImageName = path + "\\" + uniqueImageName });
            }
            catch
            {
                return BadRequest();
            }
        }
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [DisableRequestSizeLimit]
        [HttpPost]
        [Route("UploadVideos")]
        public async Task<IActionResult> UploadVideo(IFormFile videoFile)
        {
            try
            {
                string path = Path.Combine(_env.WebRootPath, Constants.ProductVideos);
                string uniqueVideoName = Guid.NewGuid().ToString() + Constants.Hyphen + videoFile.FileName;
                using (FileStream stream = new(Path.Combine(path, uniqueVideoName), FileMode.Create))
                {
                    await videoFile.CopyToAsync(stream);
                }
                return Ok(new { Message = CommonResource.VideoUploaded, StatusCode = StatusCodes.Status200OK, ImageName = path + "\\" + uniqueVideoName });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("CreateRating")]
        public async Task<IActionResult> CreateRating(RatingDto rating)
        {
            try
            {
                bool isRatingSaved = await _commonService.CreateRating(rating);
                if (isRatingSaved)
                {
                    return Ok(new OkResponse(CommonResource.RatingCreated));
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
        [Route("GetAllRatings")]
        public async Task<IActionResult> GetAllRatings(int? id)
        {
            try
            {
                return Ok(new { message = CommonResource.RatingFecthed, StatusCode = StatusCodes.Status200OK, data = await _commonService.GetRating(id) });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateRating")]
        public async Task<IActionResult> UpdateRating(RatingDto rating)
        {
            try
            {
                bool isRatingUpdated = await _commonService.UpdateRating(rating);
                if (isRatingUpdated)
                {
                    return Ok(new { message = CommonResource.RatingUpdated, StatusCode = StatusCodes.Status200OK });
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
        [Route("DeleteRating")]
        public async Task<IActionResult> DeleteRating(int? id)
        {
            try
            {
                bool isRatingDeleted = await _commonService.DeleteRating(id);
                if (isRatingDeleted)
                {
                    return Ok(new { message = CommonResource.RatingDeleted, StatusCode = StatusCodes.Status200OK });
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
        [HttpPost]
        [Route("SaveUserRating")]
        public async Task<IActionResult> SaveUserRating(UserRatingDto userRating)
        {
            try
            {
                bool isUserRatingSaved = await _commonService.SaveUserRating(userRating);
                if (isUserRatingSaved)
                {
                    return Ok(new { message = CommonResource.UserRatingSaved, StatusCode = StatusCodes.Status200OK });
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
        [Route("GetUserRating")]
        public async Task<IActionResult> GetUserRating(int? userId)
        {
            try
            {
                return Ok(new { message = CommonResource.DataFetched, StatusCode = StatusCodes.Status200OK, data = await _commonService.GetUserRating(userId) });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("SendEmail")]
        public async Task<IActionResult> SendEmail([FromForm] MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                return Ok(new OkResponse(CommonResource.EmailSent));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
