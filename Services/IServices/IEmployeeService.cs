using ServiceLayer.Dto;

namespace ServiceLayer.IServices
{
    public interface IEmployeeService
    {
        Task<bool> AddRecord(EmployeeDto employee);
        Task<IList<EmployeeListingDto>> GetAllRecords();
        Task<EmployeeDto> GetRecordById(int? id);
        Task<bool> UpdateRecord(EmployeeDto employee);
        Task<bool> DeleteRecord(int? empId);
        Task<bool> IsRecordExist(string username);
    }
}
