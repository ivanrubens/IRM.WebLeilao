using System.Diagnostics.Contracts;
using IRM.WebLeilao.Domain.ValueObjects;

namespace IRM.WebLeilao.Domain.Models
{
    public class Pessoa : EntityBase
    {
        public CPF CPF { get; private set; }
        public Nome Nome { get; private set; }

        public override void ValidarEntidade()
        {
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