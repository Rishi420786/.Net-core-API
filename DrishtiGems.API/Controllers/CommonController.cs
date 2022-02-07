using Common.CommonUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DrishtiGems.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CommonController : ControllerBase
    {
        private readonly IHostingEnvironment _env;
        public CommonController(IHostingEnvironment env)
        {
            _env = env;
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
                using (FileStream stream = new FileStream(Path.Combine(path, uniqueImageName), FileMode.Create))
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
                using (FileStream stream = new FileStream(Path.Combine(path, uniqueVideoName), FileMode.Create))
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
    }
}
