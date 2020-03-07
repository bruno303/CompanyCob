using CompanyCob.Domain.Model;
using CompanyCob.Repository.Data;
using CompanyCob.Domain.Model.Interface;

namespace CompanyCob.Repository
{
    public class CarteiraRepository : AbstractRepository<Carteira, int>, ICarteiraRepository
    {
        private readonly CobDbContext _context;

        /* Importante manter o CodDbContext também nessa classe,
           caso seja necessário criar algum método específico para o repositório.
         */
        public CarteiraRepository(CobDbContext context) : base(context)
        {
            this._context = context;   
        }
    }
}