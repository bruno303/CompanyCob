using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Interface;
using System;
using System.Collections.Generic;

namespace CompanyCob.Service
{
    public abstract class CalculoDivida : ICalculoDivida
    {
        public abstract bool Accept(Carteira carteira);

        protected abstract decimal CalcularValorFinal(Carteira carteira, Divida divida);

        /// <summary>
        /// Calcula os juros cobrados na dívida
        /// </summary>
        /// <param name="carteira">Carteira da dívida</param>
        /// <param name="divida">Dívida a ser calculada</param>
        /// <returns>Decimal</returns>
        protected virtual decimal CalcularJuros(Carteira carteira, Divida divida)
        {
            return divida.ValorFinal - divida.ValorOriginal;
        }

        /// <summary>
        /// Calcula a comissão da CompanyCob
        /// </summary>
        /// <param name="carteira">Carteira da dívida</param>
        /// <param name="divida">Dívida a ser calculada</param>
        /// <returns>Decimal</returns>
        protected virtual decimal CalcularComissao(Carteira carteira, Divida divida)
        {
            return divida.ValorFinal * (carteira.PercentualComissao / 100);
        }

        /// <summary>
        /// Calcula o valor atualizado da dívida
        /// </summary>
        /// <param name="carteira">Carteira da dívida</param>
        /// <param name="divida">Dívida a ser calculada</param>
        /// <returns>Lista de ParcelaNegociacao</returns>
        public List<ParcelaNegociacao> Calcular(Carteira carteira, Divida divida)
        {
            if (carteira == null)
            {
                throw new ArgumentNullException(nameof(carteira));
            }
            
            if (divida == null)
            {
                throw new ArgumentNullException(nameof(divida));
            }

            divida.DiasAtraso = CalcularDiasAtraso(divida);
            divida.ValorFinal = CalcularValorFinal(carteira, divida);
            divida.ValorJuros = CalcularJuros(carteira, divida);
            divida.ValorComissao = CalcularComissao(carteira, divida);

            return MontarParcelas(carteira, divida);
        }

        /// <summary>
        /// Monta a lista de parcelas com o valor atualizado.
        /// </summary>
        /// <param name="carteira">Carteira a qual a divida pertence</param>
        /// <param name="divida">Divida que será dividida em parcelas</param>
        /// <returns>Lista de ParcelaNegociacao</returns>
        protected virtual List<ParcelaNegociacao> MontarParcelas(Carteira carteira, Divida divida)
        {
            var parcelas = new List<ParcelaNegociacao>();

            var valorParcela = divida.ValorFinal / carteira.QtdParcelasMaxima;

            for (int i = 0; i < carteira.QtdParcelasMaxima; i++)
            {
                var parcela = new ParcelaNegociacao()
                {
                    Numero = i + 1,
                    Valor = valorParcela,
                    Vencimento = CalcularVencimento(i + 1)
                };

                parcelas.Add(parcela);
            }

            return parcelas;
        }

        /// <summary>
        /// Calcula a data de vencimento com base no número da parcela
        /// </summary>
        /// <param name="numeroParcela">Número da parcela para calcular o vencimento</param>
        /// <returns>DateTime</returns>
        protected virtual DateTime CalcularVencimento(int numeroParcela)
        {
            DateTime dataBase = DateTime.Today.AddDays(1);

            if (numeroParcela == 1)
            {
                return dataBase;
            }

            return dataBase.AddMonths(numeroParcela - 1);
        }

        /// <summary>
        /// Calcula os dias de atraso da dívida em dias.
        /// </summary>
        /// <param name="divida">Dívida que terá seu atraso calculado</param>
        /// <returns>Int</returns>
        protected virtual int CalcularDiasAtraso(Divida divida)
        {
            int atraso = Convert.ToInt32(DateTime.Today.Subtract(divida.Vencimento).TotalDays);
            return atraso < 0 ? 0 : atraso;
        }
    }
}
