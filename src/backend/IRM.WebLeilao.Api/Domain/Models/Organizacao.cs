using System;
using IRM.WebLeilao.Api.Domain.ValueObjects;

namespace IRM.WebLeilao.Api.Domain.Models
{
    public class Organizacao : EntityBase
    {
        public CNPJ CNPJ { get; private set; }
        public RazaoSocial RazaoSocial { get; private set; }
        public NomeFantasia NomeFantasia { get; private set; }

        protected Organizacao() { }

        public Organizacao( string cNPJ, string razaoSocial, string nomeFantasia)
        {
            CNPJ = new CNPJ(cNPJ);
            RazaoSocial = new RazaoSocial(razaoSocial);
            NomeFantasia = new NomeFantasia(nomeFantasia);

            ValidarEntidade();
        }

        public override void ValidarEntidade()
        {
            if (this.Id == Guid.Empty)
            {
                AddNotification("Id", "Id não pode ser Empty");
            }

            if (CNPJ.Invalid)
            {
                AddNotifications(CNPJ.Notifications);
            }

            if (RazaoSocial.Invalid)
            {
                AddNotifications(RazaoSocial.Notifications);
            }

            if (NomeFantasia.Invalid)
            {
                AddNotifications(NomeFantasia.Notifications);
            }
        }
    }
}