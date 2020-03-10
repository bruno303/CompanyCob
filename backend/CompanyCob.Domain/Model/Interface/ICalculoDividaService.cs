using System.Threading.Tasks;

namespace CompanyCob.Domain.Model.Interface
{
    public interface ICalculoDividaService
    {
        Task<ResultadoPadrao<Negociacao>> Calcular(int idDivida, int idDevedor);
    }
}
