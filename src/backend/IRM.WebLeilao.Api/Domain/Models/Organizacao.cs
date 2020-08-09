using IRM.WebLeilao.Api.Domain.ValueObjects;

namespace IRM.WebLeilao.Api.Domain.Models
{
    public class Organizacao : EntityBase
    {
        public CNPJ CNPJ { get; private set; }
        public RazaoSocial RazaoSocial { get; private set; }
        public NomeFantasia NomeFantasia { get; private set; }

        protected Organizacao() { }

        public Organizacao(CNPJ cNPJ, RazaoSocial razaoSocial, NomeFantasia nomeFantasia)
        {
            CNPJ = cNPJ;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;

            ValidarEntidade();
        }

        public override void ValidarEntidade()
        {
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