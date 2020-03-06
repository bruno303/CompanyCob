using System.Collections.Generic;

namespace CompanyCob.Domain.Model
{
    public class Contrato
    {
        public int Id { get; set; }
        public Devedor Devedor { get; set; }
        public Carteira Carteira { get; set; }
        public string NumeroContrato { get; set; }
        public IEnumerable<Parcela> Parcelas { get; set; }
    }
}