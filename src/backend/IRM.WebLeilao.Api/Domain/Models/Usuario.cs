using System;

namespace IRM.WebLeilao.Api.Domain.Models
{
    public class Usuario : EntityBase
    {
        public Pessoa Pessoa { get; private set; }
        public Guid UserId { get; private set; }
        public string SessaoId { get; private set; }

        protected Usuario() { }

        public Usuario(Pessoa pessoa, Guid userId)
        {
            Pessoa = pessoa;
            UserId = userId;

            ValidarEntidade();
        }

        public override void ValidarEntidade()
        {
            if (this.Id == Guid.Empty)
            {
                AddNotification("Id", "Id não pode ser Empty");
            }
            
            if (Pessoa.Invalid)
            {
                AddNotifications(Pessoa.Notifications);
            }

        }

        public bool Autenticar()
        {
            if (!this.Ativo)
            {
                AddNotification("Usuario.Autenticar", "Não é possível autenticar - Usuário Inativo.");
                SessaoId = "";
                return false;
            }
            else
            {
                SessaoId = Guid.NewGuid().ToString().Replace("-", "").Substring(1, 10).ToUpper();
                return true;
            }

        }

    }
}