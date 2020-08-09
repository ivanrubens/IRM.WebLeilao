using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IRM.WebLeilao.Tests
{
    [TestClass]
    public class DomainModelsTests
    {
        private CPF cpf;
        private NomePessoa nomePessoa;
        private Pessoa pessoa;
        private Guid usuarioId;
        private Usuario usuarioResponsavel;
        private NomeGeral nomeGeral;

        public DomainModelsTests()
        {
            cpf = new CPF("67763044322");
            nomePessoa = new NomePessoa("Fulano de", "Tal");
            pessoa = new Pessoa(cpf, nomePessoa);
            usuarioId = Guid.NewGuid();
            usuarioResponsavel = new Usuario(pessoa, usuarioId);
            nomeGeral = new NomeGeral("Leilão 1");
        }

        #region * LEILAO * 
        [TestMethod]
        public void Leilao_ValorInicial_Negativo_Invalid()
        {
            var leilao = new Leilao(nomeGeral, -1, false, usuarioResponsavel, DateTime.Today, DateTime.Today.AddDays(1));

            Assert.AreEqual(leilao.Valid, false);
            Assert.AreEqual(leilao.Invalid, true);
            Assert.AreEqual(1, leilao.Notifications.Count);

        }
        [TestMethod]
        public void Leilao_ValorInicial_Zerado_Invalid()
        {
            var leilao = new Leilao(nomeGeral, 0, false, usuarioResponsavel, DateTime.Today, DateTime.Today.AddDays(1));

            Assert.AreEqual(leilao.Valid, false);
            Assert.AreEqual(leilao.Invalid, true);
            Assert.AreEqual(1, leilao.Notifications.Count);
        }

        [TestMethod]
        public void Leilao_DataAbertura_MenorQue_DataAtual_Invalid()
        {
            var leilao = new Leilao(nomeGeral, 1, false, usuarioResponsavel, DateTime.Today.AddDays(-1), DateTime.Today.AddDays(1));

            Assert.AreEqual(leilao.Valid, false);
            Assert.AreEqual(leilao.Invalid, true);
            Assert.AreEqual(1, leilao.Notifications.Count);

        }

        [TestMethod]
        public void Leilao_DataFechamento_MenorQue_DataAbertura_Invalid()
        {
            var leilao = new Leilao(nomeGeral, 1, false, usuarioResponsavel, DateTime.Today, DateTime.Today.AddDays(-1));

            Assert.AreEqual(leilao.Valid, false);
            Assert.AreEqual(leilao.Invalid, true);
            Assert.AreEqual(1, leilao.Notifications.Count);

        }
        [TestMethod]
        public void Leilao_DataAbertura_E_DataFechamento_Iguais_Valid()
        {
            var leilao = new Leilao(nomeGeral, 1, false, usuarioResponsavel, DateTime.Today, DateTime.Today);

            Assert.AreEqual(leilao.Valid, true);
            Assert.AreEqual(leilao.Invalid, false);
            Assert.AreEqual(0, leilao.Notifications.Count);
        }

        [TestMethod]
        public void Leilao_Valid()
        {

        }
        #endregion

    }
}
