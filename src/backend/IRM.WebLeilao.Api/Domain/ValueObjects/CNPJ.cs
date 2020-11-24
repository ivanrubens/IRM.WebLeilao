using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using IRM.WebLeilao.Api.Infra.CrossCutting.Extensions;

namespace IRM.WebLeilao.Api.Domain.ValueObjects
{
    public class CNPJ : Notifiable
    {
        public string Numero { get; private set; }

        // EF 
        protected CNPJ() { }

        public CNPJ(string numero)
        {
            numero = numero.JustDigits(numero);
            
            AddNotifications(new Contract()
                .IsCnpj(numero, "CNPJ.Numero", "CNPJ Inválido.")
            );

            Numero = numero;

        }

    }
}