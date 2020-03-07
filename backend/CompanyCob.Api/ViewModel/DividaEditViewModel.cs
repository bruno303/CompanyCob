using CompanyCob.Domain.Model;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyCob.Api.ViewModel
{
    public class DividaEditViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public int IdDevedor { get; set; }
        public int IdCarteira { get; set; }
        public string NumeroDivida { get; set; }
        public decimal ValorOriginal { get; set; }
        public DateTime Vencimento { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .HasMaxLen(NumeroDivida, 60, "NumeroDivida", "O número da dívida deve conter até 60 caracteres")
                .IsNotNullOrWhiteSpace(NumeroDivida, "NumeroDivida", "O número da dívida não pode estar vazio")

                .IsGreaterThan(ValorOriginal, 0, "ValorOriginal", "O valor original deve ser maior que zero")

                .IsNotNull(Vencimento, "Vencimento", "O vencimento não pode ser nulo")
            );
        }
    }
}
