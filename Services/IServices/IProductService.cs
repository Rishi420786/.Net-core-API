using ServiceLayer.Dto;

namespace ServiceLayer.IServices
{
    public interface IProductService
    {
        Task<bool> CreateProduct(ProductDto product);
        Task<IList<ProductListDto>> GetProductList();
        Task<ProductListDto> GetProductById(int? Id);
        Task<bool> UpdateProduct(ProductDto product);
        Task<bool> DeleteProduct(int? Id);
    }
}
