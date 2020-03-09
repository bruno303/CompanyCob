namespace CompanyCob.Domain.Model
{
    public class ResultadoPadrao<T> where T : class
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T Resultado { get; set; }
    }
}
