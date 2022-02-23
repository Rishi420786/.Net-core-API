using ServiceLayer.Dto;

namespace ServiceLayer.IServices
{
    public interface IProductService
    {
        Task<bool> AddRecord(ProductDto product);
        Task<IList<ProductListDto>> GetAllRecords();
        Task<ProductListDto> GetRecordById(int? Id);
        Task<bool> UpdateRecord(ProductDto product);
        Task<bool> DeleteRecord(int? Id);
    }
}
