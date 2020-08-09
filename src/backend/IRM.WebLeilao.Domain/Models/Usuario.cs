using System;

namespace IRM.WebLeilao.Domain.Models
{
    public class Usuario : EntityBase
    {
        public Pessoa Pessoa { get; private set; }
        public Guid UserId { get; set; }

        protected Usuario() { }

        public Usuario(Pessoa pessoa, Guid userId)
        {
            Pessoa = pessoa;
            UserId = userId;

            ValidarEntidade();
        }

        public override void ValidarEntidade()
        {
            if (Pessoa.Invalid)
            {
                AddNotifications(Pessoa.Notifications);
            }

        }
    }
}