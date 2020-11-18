using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;

namespace IRM.WebLeilao.Api.Domain.ValueObjects
{
    public class CNPJ : Notifiable
    {
        public string Numero { get; private set; }

        // EF 
        protected CNPJ() { }

        public CNPJ(string numero)
        {
            AddNotifications(new Contract()
                .IsCnpj(numero, "CNPJ.Numero", "CNPJ Inválido.")
            );

            Numero = numero;

        }

    }
}