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
        private Usuario usuario;
        private string nomeGeral;
        private Guid usuarioLogadoId;

        public DomainModelsTests()
        {
            cpf = new CPF("67763044322");
            nomePessoa = new NomePessoa("Fulano de", "Tal");
            pessoa = new Pessoa(cpf.Numero, nomePessoa);
            usuarioId = Guid.NewGuid();
            usuario = new Usuario(pessoa, usuarioId);
            nomeGeral = "Leilão 1";

            usuarioLogadoId = Guid.NewGuid();
        }

        #region * LEILAO * 
        [TestMethod]
        public void Leilao_ValorInicial_Negativo_Invalid()
        {
            var leilao = new Leilao(nomeGeral, -1, false, usuario, DateTime.Today, DateTime.Today.AddDays(1));

            Assert.AreEqual(leilao.Valid, false);
            Assert.AreEqual(leilao.Invalid, true);
            Assert.AreEqual(1, leilao.Notifications.Count);

        }
        [TestMethod]
        public void Leilao_ValorInicial_Zerado_Invalid()
        {
            var leilao = new Leilao(nomeGeral, 0, false, usuario, DateTime.Today, DateTime.Today.AddDays(1));

            Assert.AreEqual(leilao.Valid, false);
            Assert.AreEqual(leilao.Invalid, true);
            Assert.AreEqual(1, leilao.Notifications.Count);
        }

        [TestMethod]
        public void Leilao_DataAbertura_MenorQue_DataAtual_Invalid()
        {
            var leilao = new Leilao(nomeGeral, 1, false, usuario, DateTime.Today.AddDays(-1), DateTime.Today.AddDays(1));

            Assert.AreEqual(leilao.Valid, false);
            Assert.AreEqual(leilao.Invalid, true);
            Assert.AreEqual(1, leilao.Notifications.Count);

        }

        [TestMethod]
        public void Leilao_DataFechamento_MenorQue_DataAbertura_Invalid()
        {
            var leilao = new Leilao(nomeGeral, 1, false, usuario, DateTime.Today, DateTime.Today.AddDays(-1));

            Assert.AreEqual(leilao.Valid, false);
            Assert.AreEqual(leilao.Invalid, true);
            Assert.AreEqual(1, leilao.Notifications.Count);

        }
        [TestMethod]
        public void Leilao_DataAbertura_E_DataFechamento_Iguais_Valid()
        {
            var leilao = new Leilao(nomeGeral, 1, false, usuario, DateTime.Today, DateTime.Today);

            Assert.AreEqual(leilao.Valid, true);
            Assert.AreEqual(leilao.Invalid, false);
            Assert.AreEqual(0, leilao.Notifications.Count);
        }

        [TestMethod]
        public void Leilao_Valid()
        {
            var leilao = new Leilao(nomeGeral, 1, false, usuario, DateTime.Today, DateTime.Today.AddDays(3));

            Assert.AreEqual(leilao.Valid, true);
            Assert.AreEqual(leilao.Invalid, false);
            Assert.AreEqual(0, leilao.Notifications.Count);
        }
        #endregion

        #region * LOGIN *
        [TestMethod]
        public void Login_Autenticar_UsuarioInativo_False()
        {
            pessoa.Inativar(usuarioLogadoId);
            usuario.Autenticar();

            Assert.AreEqual(usuario.Valid, false);
            Assert.AreEqual(usuario.Invalid, true);
            Assert.AreEqual(usuario.SessaoId, "");
        }

        [TestMethod]
        public void Login_Autenticar_UsuarioAtivo_True()
        {
            usuario.Ativar(usuarioLogadoId);
            usuario.Autenticar();

            Assert.AreEqual(usuario.Valid, true);
            Assert.AreEqual(usuario.Invalid, false);
            Assert.IsTrue(usuario.SessaoId.Length == 10);
        }

        #endregion
    }
}
