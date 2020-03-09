using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyCob.Domain.Model
{
    public class Negociacao
    {
        public Divida divida { get; set; }
        public int QtdParcelas { get; set; }
        public List<ParcelaNegociacao> parcelas { get; set; }
        public string TelefoneContato { get; set; }
    }
}
