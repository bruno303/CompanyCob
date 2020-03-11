using System.Threading.Tasks;

namespace CompanyCob.Domain.Model.Interface.Service
{
    public interface IDevedorService
    {
        Task<ValidacaoResult> ValidarAsync(Devedor devedor);
    }
}
