using System;
using IRM.WebLeilao.Api.Domain.ValueObjects;

namespace IRM.WebLeilao.Api.Domain.Models
{
    public class Pessoa : EntityBase
    {
        public CPF CPF { get; private set; }
        public NomePessoa Nome { get; private set; }

        protected Pessoa() { }

        public Pessoa(CPF cPF, NomePessoa nome)
        {
            CPF = cPF;
            Nome = nome;

            ValidarEntidade();
        }

        public override void ValidarEntidade()
        {
            if (this.Id == Guid.Empty)
            {
                AddNotification("Id", "Id não pode ser Empty");
            }

            if (CPF.Invalid)
            {
                AddNotifications(CPF.Notifications);
            }

            if (Nome.Invalid)
            {
                AddNotifications(Nome.Notifications);
            }

        }
    }

}