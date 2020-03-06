using CompanyCob.Domain.Model;
using CompanyCob.Repository.Data;

namespace CompanyCob.Repository
{
    public class DevedorRepository : AbstractRepository<Devedor, int>
    {
        private readonly CobDbContext _context;

        public DevedorRepository(CobDbContext context) : base(context)
        {
            _context = context;
        }
    }
}