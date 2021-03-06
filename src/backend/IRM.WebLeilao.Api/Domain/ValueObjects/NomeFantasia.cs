using Flunt.Notifications;
using Flunt.Validations;
using IRM.WebLeilao.Api.Infra.CrossCutting.Extensions;
using IRM.WebLeilao.Api.Infra.CrossCutting.Helpers;

namespace IRM.WebLeilao.Api.Domain.ValueObjects
{
    public class NomeFantasia : Notifiable
    {
        public NomeFantasia(string nome)
        {
            Nome = nome.RemoveDoubleSpaces().Trim().ToUpper();

            ValidarEntidade();
        }

        public string Nome { get; private set; }

        private void ValidarEntidade()
        {
            AddNotifications(new Contract()
                    .HasMinLen(Nome, 3, "NomeFantasia.Nome", "Nome precisa ter no mínimo 3 caracteres.")
                    .HasMaxLengthIfNotNullOrEmpty(Nome, 40, "NomeFantasia.Nome", "Nome precisa ter no máximo 40 caracteres.")
                );

            if (StringHelper.HaCaracteresInvalidos(Nome))
            {
                AddNotification("NomeFantasia.Nome", "Caracteres inválidos não podem ser utilizados no Nome.");
            };

        }

        public override string ToString()
        {
            return Nome;
        }

    }
}