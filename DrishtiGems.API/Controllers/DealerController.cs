using AutoMapper;
using Common.CommonUtility;
using DrishtiGems.API.Model;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dto;
using ServiceLayer.IServices;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DrishtiGems.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {
        private readonly IDealerService _dealerService;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;
        public DealerController(IDealerService dealerService, IMapper mapper, IHostingEnvironment env)
        {
            _dealerService = dealerService;
            _mapper = mapper;
            _env = env;
        }
        [HttpPost]
        [Route("SaveDealer")]
        public async Task<IActionResult> SaveDealer([FromForm] DealerModel dealer)
        {
            try
            {
                if (!await _dealerService.IsRecordExist(dealer.UserName))
                {
                    if (dealer.ImageFile != null)
                    {
                        string path = Path.Combine(_env.WebRootPath, Constants.DealerImages);
                        string uniqueImageName = Guid.NewGuid().ToString() + Constants.Hyphen + dealer.ImageFile.FileName;
                        dealer.ImageFileName = uniqueImageName;
                        using (FileStream stream = new(Path.Combine(path, uniqueImageName), FileMode.Create))
                        {
                            await dealer.ImageFile.CopyToAsync(stream);
                        }
                    }
                    DealerDto dealerDto = _mapper.Map<DealerDto>(dealer);
                    dealerDto.PasswordHash = EncryptionDecryption.Encrypt(dealer.Password, Constants.EncryDecryKey);
                    bool result = await _dealerService.AddRecord(dealerDto);
                    if (result)
                    {
                        return Ok(new OkResponse(CommonResource.DealerSaved));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, CommonResource.Wrong);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, CommonResource.DealerExists);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetAllDealers")]
        public async Task<IActionResult> GetAllDealers()
        {
            try
            {
                return Ok(new OkResponse(CommonResource.Success, await _dealerService.GetAllRecords()));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetDealerById")]
        public async Task<IActionResult> GetDealerById(int? id)
        {
            try
            {
                return Ok(new OkResponse(CommonResource.Success, await _dealerService.GetRecordById(id)));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateDealer")]
        public async Task<IActionResult> UpdateDealer([FromForm] DealerModel dealer)
        {
            try
            {
                if (dealer.ImageFile != null)
                {
                    string path = Path.Combine(_env.WebRootPath, Constants.DealerImages);
                    string uniqueImageName = Guid.NewGuid().ToString() + Constants.Hyphen + dealer.ImageFile.FileName;
                    dealer.ImageFileName = uniqueImageName;
                    FileInfo fileInfo = new FileInfo(uniqueImageName);
                    if (!fileInfo.Exists)
                    {
                        using (FileStream stream = new(Path.Combine(path, uniqueImageName), FileMode.Create))
                        {
                            await dealer.ImageFile.CopyToAsync(stream);
                        }
                    }
                }
                DealerDto dealerDto = _mapper.Map<DealerDto>(dealer);
                bool result = await _dealerService.UpdateRecord(dealerDto);
                if (result)
                {
                    return Ok(new OkResponse(CommonResource.DealerUpdated));
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
        [Route("DeleteDealer")]
        public async Task<IActionResult> DeleteDealer(int? id)
        {
            try
            {
                bool result = await _dealerService.DeleteRecord(id);
                if (result)
                {
                    return Ok(new OkResponse(CommonResource.DealerDeleted));
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
