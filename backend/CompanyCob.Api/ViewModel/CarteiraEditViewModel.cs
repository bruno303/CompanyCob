using Flunt.Notifications;
using Flunt.Validations;

namespace CompanyCob.Api.ViewModel
{
    public class CarteiraEditViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public int QtdParcelasMaxima { get; set; }
        public int TipoJuros { get; set; }
        public decimal PercentualJuros { get; set; }
        public decimal PercentualComissao { get; set; }
        public string TelefoneContato { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .HasMaxLen(Nome, 300, "Nome", "O nome deve conter até 300 caracteres")
                .IsNotNullOrWhiteSpace(Nome, "Nome", "O nome não pode estar vazio")

                .HasMaxLen(RazaoSocial, 300, "RazaoSocial", "A razão social deve conter até 300 caracteres")
                .IsNotNullOrWhiteSpace(RazaoSocial, "RazaoSocial", "A razão social não pode estar vazia")

                .IsGreaterThan(QtdParcelasMaxima, 0, "QtdParcelasMaxima", "A quantidade máxima de parcelas deve ser maior que zero")

                .IsBetween(TipoJuros, 0, 1, "TipoJuros", "O tipo de juros deve ser 0 (simples) ou 1 (composto)")

                .IsGreaterThan(PercentualJuros, 0, "PercentualJuros", "O juros deve ser maior que zero")
                
                .IsGreaterThan(PercentualComissao, 0, "PercentualComissao", "A comissão deve ser maior que zero")

                .HasMaxLen(TelefoneContato, 30, "TelefoneContato", "O telefone para contato deve conter até 30 caracteres")
                .IsNotNullOrWhiteSpace(TelefoneContato, "TelefoneContato", "O telefone para contato não pode estar vazio")
            );
        }
    }
}