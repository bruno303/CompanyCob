using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Interface;
using CompanyCob.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyCob.Repository
{
    public class DevedorRepository : AbstractRepository<Devedor, int>, IDevedorRepository
    {
        private readonly CobDbContext _context;

        public DevedorRepository(CobDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Devedor> GetByCpfAsync(long cpf)
        {
            return await _context.Devedores.Where(dev => dev.Cpf == cpf).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}