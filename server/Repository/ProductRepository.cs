using server.Data;
using server.Entities;
using server.Interface.Repository;

namespace server.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context) : base(context)
        {
            this._context = context;
        }
    }
}
