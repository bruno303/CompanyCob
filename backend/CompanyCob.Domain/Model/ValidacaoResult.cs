using System.Collections.Generic;

namespace CompanyCob.Domain.Model
{
    public class ValidacaoResult
    {
        public bool Valido { get; private set; }
        public bool Invalido => !Valido;
        public List<string> Erros { get; private set; }

        public ValidacaoResult(bool valido, List<string> erros)
        {
            Valido = valido;
            Erros = erros;
        }
    }
}
