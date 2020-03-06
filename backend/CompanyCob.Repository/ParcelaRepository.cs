using CompanyCob.Domain.Model;
using CompanyCob.Repository.Data;

namespace CompanyCob.Repository
{
    public class ParcelaRepository : AbstractRepository<Parcela, int>
    {
        private readonly CobDbContext _context;

        public ParcelaRepository(CobDbContext context) : base(context)
        {
            _context = context;
        }
    }
}