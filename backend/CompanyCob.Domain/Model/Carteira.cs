using System.Collections.Generic;
using CompanyCob.Domain.Model.Enum;

namespace CompanyCob.Domain.Model
{
    public class Carteira
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public int QtdParcelasMaxima { get; set; }
        public TipoJurosEnum TipoJuros { get; set; }
        public decimal PercentualJuros { get; set; }
        public decimal Comissao { get; set; }
        public IEnumerable<Divida> Dividas { get; set; }
    }
}