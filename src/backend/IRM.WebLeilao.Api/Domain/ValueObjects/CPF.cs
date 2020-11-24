using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using IRM.WebLeilao.Api.Infra.CrossCutting.Extensions;

namespace IRM.WebLeilao.Api.Domain.ValueObjects
{
    public class CPF : Notifiable
    {
        public string Numero { get; private set; }

        public CPF(string numero)
        {
            numero = numero.JustDigits(numero);

            AddNotifications(new Contract()
                .IsCpf(numero, "CPF.Numero", "CPF Inválido.")
            );

            Numero = numero;

        }

    }
}