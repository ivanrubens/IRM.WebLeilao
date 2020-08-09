using Flunt.Notifications;
using Flunt.Validations;
using IRM.WebLeilao.Api.Common.Extensions;
using IRM.WebLeilao.Api.Common.Helpers;

namespace IRM.WebLeilao.Api.Domain.ValueObjects
{
    public class NomePessoa : Notifiable
    {
        public NomePessoa(string primeiroNome, string sobreNome)
        {
            PrimeiroNome = primeiroNome.RemoveDoubleSpaces().Trim().ToUpper();
            SobreNome = sobreNome.RemoveDoubleSpaces().Trim().ToUpper();

            ValidarEntidade();
        }

        public string PrimeiroNome { get; private set; }
        public string SobreNome { get; private set; }

        private void ValidarEntidade()
        {
            AddNotifications(new Contract()
                    .HasMinLen(PrimeiroNome, 3, "NomePessoa.PrimeiroNome", "Primeiro Nome precisa ter no mínimo 3 caracteres.")
                    .HasMaxLengthIfNotNullOrEmpty(PrimeiroNome, 40, "NomePessoa.PrimeiroNome", "Primeiro Nome precisa ter no máximo 40 caracteres.")
                    .HasMinLen(SobreNome, 3, "NomePessoa.SobreNome", "Sobrenome precisa ter no mínimo 3 caracteres.")
                    .HasMaxLengthIfNotNullOrEmpty(SobreNome, 40, "NomePessoa.SobreNome", "Sobrenome precisa ter no máximo 40 caracteres.")
                );

            if (StringHelper.HaCaracteresInvalidos(PrimeiroNome))
            {
                AddNotification("PrimeiroNome", "Caracteres inválidos não podem ser utilizados no Nome.");
            };

            if (StringHelper.HaCaracteresInvalidos(SobreNome))
            {
                AddNotification("SobreNome", "Caracteres inválidos não podem ser utilizados no Sobrenome.");
            };

        }

        public override string ToString()
        {
            return string.Concat(PrimeiroNome, " ", SobreNome);
        }

    }
}