using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Enum;
using System;

namespace CompanyCob.Service
{
    public class CalculoDividaJurosCompostos : CalculoDivida
    {
        public override bool Accept(Carteira carteira)
        {
            if (carteira == null)
            {
                throw new ArgumentNullException(nameof(carteira));
            }

            return carteira.TipoJuros == TipoJurosEnum.Composto;
        }

        protected override decimal CalcularValorFinal(Carteira carteira, Divida divida)
        {
            var jurosTotalDias = 1 + Math.Pow(Convert.ToDouble(carteira.PercentualJuros / 100), divida.DiasAtraso);

            return divida.ValorOriginal * Convert.ToDecimal(jurosTotalDias);
        }
    }
}
