using ServiceLayer.Dto;

namespace ServiceLayer.IServices
{
    public interface IDealerService
    {
        Task<bool> SaveDealer(DealerDto dealer);
        Task<IList<DealerListingDto>> GetAllDealers();
        Task<DealerDto> GetDealerById(int? id);
        Task<bool> UpdateDealer(DealerDto dealerDto);
        Task<bool> DeleteDealer(int? dealerId);
        Task<bool> IsDealerExist(string username);
    }
}
