using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Enum;
using System;

namespace CompanyCob.Service.CalculoDividaImpl
{
    public class CalculoDividaJurosSimples : CalculoDivida
    {
        public override bool Accept(Carteira carteira)
        {
            if (carteira == null)
            {
                throw new ArgumentNullException(nameof(carteira));
            }

            return carteira.TipoJuros == TipoJurosEnum.Simples;
        }

        protected override decimal CalcularValorFinal(Carteira carteira, Divida divida)
        {
            return divida.ValorOriginal * (1 + carteira.PercentualJuros / 100 * divida.DiasAtraso);
        }
    }
}
