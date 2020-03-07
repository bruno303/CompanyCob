using CompanyCob.Domain.Model;
using CompanyCob.Repository.Data;

namespace CompanyCob.Repository
{
    public class DividaRepository : AbstractRepository<Divida, int>
    {
        private readonly CobDbContext _context;

        public DividaRepository(CobDbContext context) : base(context)
        {
            _context = context;
        }
    }
}