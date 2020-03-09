using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Enum;
using System;

namespace CompanyCob.Service.CalculoDividaImpl
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
            var jurosPercentual = carteira.PercentualJuros / 100;
            var jurosTotalDias = Math.Pow(Convert.ToDouble(1 + jurosPercentual), divida.DiasAtraso);

            return divida.ValorOriginal * Convert.ToDecimal(jurosTotalDias);
        }
    }
}
