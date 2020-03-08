using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyCob.Domain.Model
{
    public class ParcelaNegociacao
    {
        public int Numero { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
    }
}
