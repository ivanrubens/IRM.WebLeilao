using System;

namespace IRM.WebLeilao.Api.Application.ViewModel
{
    public class OrganizacaoViewModel
    {
        public Guid Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
    }
}