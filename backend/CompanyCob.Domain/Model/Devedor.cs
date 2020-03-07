using System.Collections.Generic;

namespace CompanyCob.Domain.Model
{
    public class Devedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public IEnumerable<Divida> Dividas { get; set; }
    }
}