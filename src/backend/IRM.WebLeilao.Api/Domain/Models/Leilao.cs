using System;
using Flunt.Validations;
using IRM.WebLeilao.Api.Domain.ValueObjects;

namespace IRM.WebLeilao.Api.Domain.Models
{
    public class Leilao : EntityBase
    {
        public NomeGeral NomeLeilao { get; private set; }
        public decimal ValorInicial { get; private set; }
        public bool ItemUsado { get; private set; }
        public Usuario UsuarioResponsavel { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public DateTime DataFinalizacao { get; private set; }

        protected Leilao() { }

        public Leilao(string nomeLeilao, decimal valorInicial, bool itemUsado, Usuario usuarioResponsavel, DateTime dataAbertura, DateTime dataFinalizacao)
        {
            NomeLeilao = new NomeGeral(nomeLeilao);
            ValorInicial = valorInicial;
            ItemUsado = itemUsado;
            UsuarioResponsavel = usuarioResponsavel;
            DataAbertura = dataAbertura;
            DataFinalizacao = dataFinalizacao;

            ValidarEntidade();
        }

        public override void ValidarEntidade()
        {
            if (this.Id == Guid.Empty)
            {
                AddNotification("Id", "Id não pode ser Empty");
            }

            if (NomeLeilao.Invalid)
            {
                AddNotifications(NomeLeilao.Notifications);
            }

            if (UsuarioResponsavel.Invalid)
            {
                AddNotifications(UsuarioResponsavel.Notifications);
            }

            AddNotifications(new Contract()
                .IsGreaterThan(ValorInicial, 0, "Leilao.ValorInicial", "Precisa ser maior que 0.")
                .IsGreaterOrEqualsThan(DataAbertura, DateTime.Today, "Leilao.DataAbertura", "Precisa ser maior ou igual à Data de hoje.")
                .IsGreaterOrEqualsThan(DataFinalizacao, DataAbertura, "Leilao.DataFinalizacao", "Precisa ser maior ou igual à Data de Abertura.")
            );
        }
    }
}