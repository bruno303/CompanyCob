using Flunt.Notifications;
using Flunt.Validations;

namespace CompanyCob.Api.ViewModel
{
    public class DevedorEditViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .HasMaxLen(Nome, 200, "Nome", "O nome deve conter até 200 caracteres")
                .IsNotNullOrWhiteSpace(Nome, "Nome", "O nome não pode estar vazio")

                .IsGreaterThan(Cpf, 0, "Cpf", "O cpf deve ser maior que zero")
            );
        }
    }
}