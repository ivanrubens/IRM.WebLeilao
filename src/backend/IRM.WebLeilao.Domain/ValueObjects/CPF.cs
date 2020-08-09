using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;

namespace IRM.WebLeilao.Domain.ValueObjects
{
    public class CPF : Notifiable
    {
        public string Numero { get; private set; }

        public CPF(string numero)
        {

            Numero = numero;

            AddNotifications(new Contract()
                .IsCpf(numero, "CPF.Numero", "CPF Inválido.")
            );

        }

    }
}