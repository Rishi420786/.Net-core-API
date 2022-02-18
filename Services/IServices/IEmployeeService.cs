using ServiceLayer.Dto;

namespace ServiceLayer.IServices
{
    public interface IEmployeeService
    {
        Task<bool> SaveEmployee(EmployeeDto employee);
        Task<IList<EmployeeListingDto>> GetAllEmployees();
        Task<EmployeeDto> GetEmployeeById(int? id);
        Task<bool> UpdateEmployee(EmployeeDto employee);
        Task<bool> DeleteEmployee(int? empId);
        Task<bool> IsEmployeeExist(string username);
    }
}
