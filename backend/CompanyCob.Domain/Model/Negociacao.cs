using System.Collections.Generic;

namespace CompanyCob.Domain.Model
{
    public class Negociacao
    {
        public Divida Divida { get; set; }
        public int QtdParcelas { get; set; }
        public List<ParcelaNegociacao> Parcelas { get; set; }
        public string TelefoneContato { get; set; }
    }
}
