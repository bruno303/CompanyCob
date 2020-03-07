using System.Threading.Tasks;

namespace CompanyCob.Domain.Model.Interface
{
    public interface IDevedorRepository : IRepository<Devedor, int>
    {
        Task<Devedor> GetByCpfAsync(long cpf);
    }
}