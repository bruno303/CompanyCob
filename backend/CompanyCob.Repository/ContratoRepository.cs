using CompanyCob.Domain.Model;
using CompanyCob.Repository.Data;

namespace CompanyCob.Repository
{
    public class ContratoRepository : AbstractRepository<Contrato, int>
    {
        private readonly CobDbContext _context;

        public ContratoRepository(CobDbContext context) : base(context)
        {
            _context = context;
        }
    }
}