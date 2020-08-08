using System.Text.RegularExpressions;
using Flunt.Notifications;
using Flunt.Validations;
using IRM.WebLeilao.Common.Extensions;

namespace IRM.WebLeilao.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        public Nome(string primeiroNome, string sobreNome)
        {

            primeiroNome = primeiroNome.RemoveDoubleSpaces();
            sobreNome = sobreNome.RemoveDoubleSpaces();

            PrimeiroNome = primeiroNome.Trim().ToUpper();
            SobreNome = sobreNome.Trim().ToUpper();

            ValidarEntidade();
        }

        public string PrimeiroNome { get; private set; }
        public string SobreNome { get; private set; }

        private void ValidarEntidade()
        {
            AddNotifications(new Contract()
                    .HasMinLen(PrimeiroNome, 3, "PrimeiroNome", "Primeiro Nome precisa ter no mínimo 3 caracteres.")
                    .HasMaxLengthIfNotNullOrEmpty(PrimeiroNome, 40, "PrimeiroNome", "Primeiro Nome precisa ter no máximo 40 caracteres.")
                    .HasMinLen(SobreNome, 3, "SobreNome", "Sobrenome precisa ter no mínimo 3 caracteres.")
                    .HasMaxLengthIfNotNullOrEmpty(SobreNome, 40, "SobreNome", "Sobrenome precisa ter no máximo 40 caracteres.")
                );

            if (HaCaracteresInvalidos(PrimeiroNome))
            {
                AddNotification("PrimeiroNome", "Caracteres inválidos não podem ser utilizados no Nome.");
            };

            if (HaCaracteresInvalidos(SobreNome))
            {
                AddNotification("SobreNome", "Caracteres inválidos não podem ser utilizados no Sobrenome.");
            };

        }

        public override string ToString()
        {
            return string.Concat(PrimeiroNome, " ", SobreNome);
        }

        private bool HaCaracteresInvalidos(string input)
        {
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç'\s]";

            Regex rgx = new Regex(pattern);
            return rgx.IsMatch(input);
        }

    }
}