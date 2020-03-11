using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCob.Domain.Model.Interface.Repository
{
    public interface IDividaRepository : IRepository<Divida, int>
    {
        Task<IEnumerable<Divida>> GetByDevedorAsync(Devedor devedor);

        Task<IEnumerable<Divida>> GetByCarteiraAsync(Carteira carteira);
    }
}
