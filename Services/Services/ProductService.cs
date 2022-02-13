using Domain.DataContext;
using ServiceLayer.IServices;

namespace ServiceLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext _context;
        public ProductService(ApplicationDBContext context)
        {
            _context= context;
        }
    }
}
