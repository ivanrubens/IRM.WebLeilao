using Flunt.Br.Extensions;
using Flunt.Validations;

namespace IRM.WebLeilao.Domain.ValueObjects
{
    public class CPF : IdentificacaoPessoa
    {
        public string Numero { get; private set; }

        public CPF(string numero)
        {

            Numero = numero;

            AddNotifications(new Contract()
                .IsCpf(numero, "Numero", "CPF Inválido.")
            );

        }

    }
}