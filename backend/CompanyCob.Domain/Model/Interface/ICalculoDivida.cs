using System.Collections.Generic;

namespace CompanyCob.Domain.Model.Interface
{
    public interface ICalculoDivida
    {
        bool Accept(Carteira carteira);
        List<ParcelaNegociacao> Calcular(Carteira carteira, Divida divida);
    }
}