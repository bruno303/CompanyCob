using System.Collections.Generic;
using CompanyCob.Domain.Model.Enum;

namespace CompanyCob.Domain.Model.Interface
{
    public interface ICalculoDivida
    {
        double CalcularJuros(Divida divida);
    }
}