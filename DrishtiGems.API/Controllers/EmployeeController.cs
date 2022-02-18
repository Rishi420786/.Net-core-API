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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _empService;
        private readonly IHostingEnvironment _env;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService empService, IHostingEnvironment env, IMapper mapper)
        {
            _empService = empService;
            _env = env;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("SaveEmployee")]
        public async Task<IActionResult> SaveEmployee([FromForm] EmployeeModel employee)
        {
            try
            {
                if (!await _empService.IsEmployeeExist(employee.UserName))
                {
                    if (employee.ImageFile != null)
                    {
                        string path = Path.Combine(_env.WebRootPath, Constants.EmployeeImages);
                        string uniqueImageName = Guid.NewGuid().ToString() + Constants.Hyphen + employee.ImageFile.FileName;
                        employee.ImageFileName = uniqueImageName;
                        using (FileStream stream = new(Path.Combine(path, uniqueImageName), FileMode.Create))
                        {
                            await employee.ImageFile.CopyToAsync(stream);
                        }
                    }
                    EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
                    employeeDto.PasswordHash = EncryptionDecryption.Encrypt(employee.Password, Constants.EncryDecryKey);
                    bool result = await _empService.SaveEmployee(employeeDto);
                    if (result)
                    {
                        return Ok(new OkResponse(CommonResource.EmployeeSaved));
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, CommonResource.Wrong);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, CommonResource.EmployeeExists);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(new OkResponse(CommonResource.Success, await _empService.GetAllEmployees()));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int? id)
        {
            try
            {
                return Ok(new OkResponse(CommonResource.Success, await _empService.GetEmployeeById(id)));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromForm] EmployeeModel employee)
        {
            try
            {
                if (employee.ImageFile != null)
                {
                    string path = Path.Combine(_env.WebRootPath, Constants.EmployeeImages);
                    string uniqueImageName = Guid.NewGuid().ToString() + Constants.Hyphen + employee.ImageFile.FileName;
                    employee.ImageFileName = uniqueImageName;
                    FileInfo fileInfo = new FileInfo(uniqueImageName);
                    if (!fileInfo.Exists)
                    {
                        using (FileStream stream = new(Path.Combine(path, uniqueImageName), FileMode.Create))
                        {
                            await employee.ImageFile.CopyToAsync(stream);
                        }
                    }
                }
                EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
                bool result = await _empService.UpdateEmployee(employeeDto);
                if (result)
                {
                    return Ok(new OkResponse(CommonResource.EmployeeUpdated));
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
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            try
            {
                bool result = await _empService.DeleteEmployee(id);
                if (result)
                {
                    return Ok(new OkResponse(CommonResource.EmployeeDeleted));
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
