using AutoMapper;
using Common.CommonUtility;
using Domain.DataContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepositoryService;
using ServiceLayer.Dto;
using ServiceLayer.IServices;

namespace ServiceLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TblEmployeeMaster> _genericRepository;
        public EmployeeService(ApplicationDBContext context, IMapper mapper, IGenericRepository<TblEmployeeMaster> genericRepository)
        {
            _context = context;
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<bool> AddRecord(EmployeeDto employee)
        {
            try
            {
                TblUser tblUser = new()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Password = employee.PasswordHash,
                    Username = employee.UserName,
                    IsActive = true,
                    IsDeleted = false,
                    RoleId = 1,
                    CreatedDateTime = DateTime.Now
                };
                await _context.AddAsync(tblUser);
                bool result = Convert.ToBoolean(await _context.SaveChangesAsync());
                if (result)
                {
                    TblEmployeeMaster tblEmployee = _mapper.Map<TblEmployeeMaster>(employee);
                    tblEmployee.UserId = tblUser.Id;
                    result = await _genericRepository.Add(tblEmployee);
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IList<EmployeeListingDto>> GetAllRecords()
        {
            try
            {
                var employees = await (from employee in _context.tblEmployeeMaster
                                       join user in _context.tblUsers on employee.UserId equals user.Id
                                       select new EmployeeListingDto
                                       {
                                           Id = employee.Id,
                                           Address = employee.Address,
                                           FullName = user.FirstName + Constants.Space + user.LastName,
                                           Aadhaar = employee.Aadhaar,
                                           IsActive = employee.IsActive,
                                           MobileNo = employee.MobileNo,
                                           PAN = employee.PAN,
                                           UserName = user.Username
                                       }).ToListAsync();
                return employees;
            }
            catch
            {
                throw;
            }
        }
        public async Task<EmployeeDto> GetRecordById(int? id)
        {
            try
            {
                var employee = await (from emp in _context.tblEmployeeMaster
                                      join user in _context.tblUsers on emp.UserId equals user.Id
                                      select new EmployeeDto
                                      {
                                          Id = emp.Id,
                                          UniqueId = emp.UniqueId,
                                          Address = emp.Address,
                                          Aadhaar = emp.Aadhaar,
                                          DOB = emp.DOB,
                                          FirstName = user.FirstName,
                                          PAN = emp.PAN,
                                          ImageFileName = emp.ImageFileName,
                                          LastName = user.LastName,
                                          MobileNo = emp.MobileNo,
                                          Designation = emp.Designation,
                                          Destination = emp.Destination,
                                          State = emp.State,
                                          UserName = user.Username
                                      }).FirstOrDefaultAsync();
                return employee;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> UpdateRecord(EmployeeDto employeeDto)
        {
            try
            {
                bool result = false;
                TblUser? tblUser = await (from emp in _context.tblEmployeeMaster
                                          join user in _context.tblUsers on emp.UserId equals user.Id
                                          where emp.Id == employeeDto.Id
                                          select user).FirstOrDefaultAsync();
                if (tblUser != null)
                {
                    tblUser.FirstName = employeeDto.FirstName;
                    tblUser.LastName = employeeDto.LastName;
                    tblUser.LastUpdatedDateTime = DateTime.Now;
                    tblUser.Username = employeeDto.UserName;
                    _context.Entry(tblUser).State = EntityState.Modified;
                    result = Convert.ToBoolean(_context.SaveChangesAsync());
                    if (result)
                    {
                        TblEmployeeMaster? tblEmployee = await _context.tblEmployeeMaster.FindAsync(employeeDto.Id);
                        tblEmployee.Aadhaar = employeeDto.Aadhaar;
                        tblEmployee.DOB = employeeDto.DOB;
                        tblEmployee.Address = employeeDto.Address;
                        tblEmployee.PAN = employeeDto.PAN;
                        tblEmployee.State = employeeDto.State;
                        if (tblEmployee.ImageFileName != null || tblEmployee.ImageFileName != string.Empty)
                        {
                            tblEmployee.ImageFileName = employeeDto.ImageFileName;
                        }
                        tblEmployee.MobileNo = employeeDto.MobileNo;
                        tblEmployee.UniqueId = employeeDto.UniqueId;
                        tblEmployee.Designation = employeeDto.Designation;
                        tblEmployee.Destination = employeeDto.Destination;
                        _context.Entry(tblEmployee).State = EntityState.Modified;
                        result = Convert.ToBoolean(await _context.SaveChangesAsync());
                    }
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> DeleteRecord(int? empId)
        {
            try
            {
                bool result = false;
                TblEmployeeMaster? tblEmployee = await _context.tblEmployeeMaster.FindAsync(empId);
                if (tblEmployee != null)
                {
                    _context.tblEmployeeMaster.Remove(tblEmployee);
                    result = Convert.ToBoolean(await _context.SaveChangesAsync());
                    TblUser? tblUser = await _context.tblUsers.FindAsync(tblEmployee.UserId);
                    if (tblUser != null)
                    {
                        _context.tblUsers.Remove(tblUser);
                        result = Convert.ToBoolean(await _context.SaveChangesAsync());
                    }
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> IsRecordExist(string username)
        {
            try
            {
                return await _context.tblUsers.AnyAsync(x => x.Username == username);
            }
            catch
            {
                throw;
            }
        }
    }
}
