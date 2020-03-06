using System;

namespace CompanyCob.Domain.Model
{
    public class Parcela
    {
        public int Id { get; set; }
        public Contrato Contrato { get; set; }
        public decimal ValorOriginal { get; set; }
        public DateTime Vencimento { get; set; }

        /* Campos calculados no momento da consulta */
        public int DiasAtraso { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorFinal { get; set; }
    }
}