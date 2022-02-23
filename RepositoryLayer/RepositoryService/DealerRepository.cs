using Domain.DataContext;
using Domain.Entities;
using RepositoryLayer.IRepositoryService;

namespace RepositoryLayer.RepositoryService
{
    public class DealerRepository : GenericRepository<TblDealers>, IDealerRepository
    {
        public DealerRepository(ApplicationDBContext context) : base(context)
        {

        }
    }
}
