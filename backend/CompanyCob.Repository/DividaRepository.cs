using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Interface;
using CompanyCob.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyCob.Repository
{
    public class DividaRepository : AbstractRepository<Divida, int>, IDividaRepository
    {
        private readonly CobDbContext _context;

        public DividaRepository(CobDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Divida>> GetByDevedorAsync(Devedor devedor)
        {
            return await _context.Dividas
                .Where(div => div.IdDevedor == devedor.Id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Divida>> GetByCarteiraAsync(Carteira carteira)
        {
            return await _context.Dividas
                .Where(div => div.IdCarteira == carteira.Id)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}