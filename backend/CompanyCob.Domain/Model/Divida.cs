using System;

namespace CompanyCob.Domain.Model
{
    public class Divida
    {
        public int Id { get; set; }
        public Devedor Devedor { get; set; }
        public int IdDevedor { get; set; }
        public Carteira Carteira { get; set; }
        public int IdCarteira { get; set; }
        public string NumeroDivida { get; set; }
        public decimal ValorOriginal { get; set; }
        public DateTime Vencimento { get; set; }

        /* Campos calculados no momento da consulta */
        public int DiasAtraso { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorFinal { get; set; }
    }
}