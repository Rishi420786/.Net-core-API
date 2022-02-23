using ServiceLayer.Dto;

namespace ServiceLayer.IServices
{
    public interface IDealerService
    {
        Task<bool> AddRecord(DealerDto dealer);
        Task<IList<DealerListingDto>> GetAllRecords();
        Task<DealerDto> GetRecordById(int? id);
        Task<bool> UpdateRecord(DealerDto dealerDto);
        Task<bool> DeleteRecord(int? dealerId);
        Task<bool> IsRecordExist(string username);
    }
}
