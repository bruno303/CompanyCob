using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyCob.Domain.Model.Interface
{
    public interface ICalculoDividaService
    {
        Task<ResultadoPadrao<List<ParcelaNegociacao>>> Calcular(int idDivida, int idDevedor);
    }
}
