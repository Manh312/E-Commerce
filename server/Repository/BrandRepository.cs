using server.Data;
using server.Entities;
using server.Interface.Repository;

namespace server.Repository
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly DataContext _context;
        public BrandRepository(DataContext context) : base(context)
        {
            this._context = context;
        }
    }
}
