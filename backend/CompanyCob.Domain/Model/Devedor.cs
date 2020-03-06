using System.Collections.Generic;

namespace CompanyCob.Domain.Model
{
    public class Devedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public IEnumerable<Contrato> Contratos { get; set; }
    }
}