using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;

namespace IRM.WebLeilao.Api.Domain.ValueObjects
{
    public class CNPJ : Notifiable
    {
        public string Numero { get; private set; }

        public CNPJ(string numero)
        {
            Numero = numero;

            AddNotifications(new Contract()
                .IsCnpj(numero, "CNPJ.Numero", "CNPJ Inválido.")
            );
        }

    }
}