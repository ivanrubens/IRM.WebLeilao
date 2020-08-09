using Flunt.Notifications;
using Flunt.Validations;
using IRM.WebLeilao.Api.Infra.CrossCutting.Extensions;

namespace IRM.WebLeilao.Api.Domain.ValueObjects
{
    public class NomeGeral : Notifiable
    {
        public NomeGeral(string nome)
        {
            Nome = nome.RemoveDoubleSpaces();

            ValidarEntidade();
        }

        public string Nome { get; private set; }

        private void ValidarEntidade()
        {
            AddNotifications(new Contract()
                    .HasMinLen(Nome, 3, "NomeGeral.Nome", "Nome precisa ter no mínimo 3 caracteres.")
                    .HasMaxLengthIfNotNullOrEmpty(Nome, 70, "NomeGeral.Nome", "Nome precisa ter no máximo 70 caracteres.")
                );

        }

        public override string ToString()
        {
            return Nome;
        }

    }
}