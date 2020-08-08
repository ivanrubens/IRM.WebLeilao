using System;
using Flunt.Notifications;

namespace IRM.WebLeilao.Domain.Models
{
    public abstract class EntityBase : Notifiable
    {
        public Guid Id { get; private set; }
        public DateTime InclusaoTimestamp { get; private set; }
        public Guid InclusaoUsuarioId { get; private set; }
        public DateTime AlteracaoTimestamp { get; private set; }
        public Guid AlteracaoUsuarioId { get; private set; }
        public DateTime ExclusaoTimestamp { get; private set; }
        public Guid ExclusaoUsuarioId { get; private set; }
        public bool Ativo { get; private set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public abstract void ValidarEntidade();
    }
}