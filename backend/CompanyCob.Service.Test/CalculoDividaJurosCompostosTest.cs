﻿using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Interface;
using CompanyCob.Service.CalculoDividaImpl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CompanyCob.Service.Test
{
    [TestClass]
    public class CalculoDividaJurosCompostosTest
    {
        private readonly ICalculoDivida calculo = new CalculoDividaJurosCompostos();

        [TestMethod]
        public void TestJurosCompostos1()
        {
            Carteira carteira = new Carteira
            {
                PercentualComissao = 10M,
                PercentualJuros = 0.2M,
                QtdParcelasMaxima = 3,
                TipoJuros = Domain.Model.Enum.TipoJurosEnum.Composto
            };

            Divida divida = new Divida()
            {
                ValorOriginal = 3000,
                Vencimento = DateTime.Today.AddDays(-10)
            };

            Assert.IsTrue(calculo.Accept(carteira));
            var result = calculo.Calcular(carteira, divida);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<ParcelaNegociacao>));
            Assert.AreEqual(carteira.QtdParcelasMaxima, result.Count);

            Assert.AreEqual(Math.Round(result[0].Valor, 2), 1020.18M);
            Assert.AreEqual(result[0].Vencimento, DateTime.Today.AddDays(1));

            Assert.AreEqual(Math.Round(result[1].Valor, 2), 1020.18M);
            Assert.AreEqual(result[1].Vencimento, DateTime.Today.AddMonths(1).AddDays(1));

            Assert.AreEqual(Math.Round(result[2].Valor, 2), 1020.18M);
            Assert.AreEqual(result[2].Vencimento, DateTime.Today.AddMonths(2).AddDays(1));
        }

        [TestMethod]
        public void TestJurosCompostos2()
        {
            Carteira carteira = new Carteira
            {
                PercentualComissao = 10M,
                PercentualJuros = 0.2M,
                QtdParcelasMaxima = 2,
                TipoJuros = Domain.Model.Enum.TipoJurosEnum.Composto
            };

            Divida divida = new Divida()
            {
                Vencimento = DateTime.Today.AddDays(-10)
            };

            Assert.IsTrue(calculo.Accept(carteira));
            var result = calculo.Calcular(carteira, divida);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<ParcelaNegociacao>));
            Assert.AreEqual(carteira.QtdParcelasMaxima, result.Count);

            Assert.AreEqual(Math.Round(result[0].Valor, 2), 0);
            Assert.AreEqual(result[0].Vencimento, DateTime.Today.AddDays(1));

            Assert.AreEqual(Math.Round(result[1].Valor, 2), 0);
            Assert.AreEqual(result[1].Vencimento, DateTime.Today.AddMonths(1).AddDays(1));
        }

        [TestMethod]
        public void TestJurosCompostos3()
        {
            Carteira carteira = new Carteira
            {
                PercentualComissao = 10M,
                PercentualJuros = 0.2M,
                QtdParcelasMaxima = 6,
                TipoJuros = Domain.Model.Enum.TipoJurosEnum.Composto
            };

            Divida divida = new Divida()
            {
                ValorOriginal = 3000,
                Vencimento = DateTime.Today.AddDays(-10)
            };

            Assert.IsTrue(calculo.Accept(carteira));
            var result = calculo.Calcular(carteira, divida);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<ParcelaNegociacao>));
            Assert.AreEqual(carteira.QtdParcelasMaxima, result.Count);

            Assert.AreEqual(Math.Round(result[0].Valor, 2), 510.09M);
            Assert.AreEqual(result[0].Vencimento, DateTime.Today.AddDays(1));

            Assert.AreEqual(Math.Round(result[1].Valor, 2), 510.09M);
            Assert.AreEqual(result[1].Vencimento, DateTime.Today.AddMonths(1).AddDays(1));

            Assert.AreEqual(Math.Round(result[2].Valor, 2), 510.09M);
            Assert.AreEqual(result[2].Vencimento, DateTime.Today.AddMonths(2).AddDays(1));

            Assert.AreEqual(Math.Round(result[3].Valor, 2), 510.09M);
            Assert.AreEqual(result[3].Vencimento, DateTime.Today.AddMonths(3).AddDays(1));

            Assert.AreEqual(Math.Round(result[4].Valor, 2), 510.09M);
            Assert.AreEqual(result[4].Vencimento, DateTime.Today.AddMonths(4).AddDays(1));

            Assert.AreEqual(Math.Round(result[5].Valor, 2), 510.09M);
            Assert.AreEqual(result[5].Vencimento, DateTime.Today.AddMonths(5).AddDays(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJurosCompostos4()
        {
            Carteira carteira = new Carteira
            {
                PercentualComissao = 10M,
                PercentualJuros = 0.2M,
                QtdParcelasMaxima = 6,
                TipoJuros = Domain.Model.Enum.TipoJurosEnum.Composto
            };

            Assert.IsTrue(calculo.Accept(carteira));
            calculo.Calcular(carteira, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJurosCompostos5()
        {
            Divida divida = new Divida()
            {
                ValorOriginal = 3000,
                Vencimento = DateTime.Today.AddDays(-10)
            };

            Assert.IsTrue(calculo.Accept(null));
            calculo.Calcular(null, divida);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestJurosCompostos6()
        {
            Assert.IsTrue(calculo.Accept(null));
            calculo.Calcular(null, null);
        }
    }
}
