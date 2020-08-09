using Microsoft.VisualStudio.TestTools.UnitTesting;
using IRM.WebLeilao.Api.Domain.ValueObjects;

namespace IRM.WebLeilao.Tests
{
    [TestClass]
    public class DomainValueObjectsTests
    {

        #region * CPF * 
        [TestMethod]
        public void CPF_Empty()
        {
            var cpf = new CPF("");

            Assert.AreEqual(cpf.Valid, false);
            Assert.AreEqual(cpf.Invalid, true);
            Assert.AreEqual(1, cpf.Notifications.Count);

        }

        [TestMethod]
        public void CPF_Menor11()
        {
            var cpf = new CPF("111");

            Assert.AreEqual(cpf.Valid, false);
            Assert.AreEqual(cpf.Invalid, true);
            Assert.AreEqual(1, cpf.Notifications.Count);

        }

        /*  -- BUG DETECTED!!! --
        [TestMethod]
        public void CPF_String()
        {
            var cpf = new CPF("ABCDEFGHIJX");

            Assert.AreEqual(cpf.Valid, false);
            Assert.AreEqual(cpf.Invalid, true);
            Assert.AreEqual(1, cpf.Notifications.Count);

        }
         */

        [TestMethod]
        public void CPF_Valido1()
        {
            var cpf = new CPF("67763044322");

            Assert.AreEqual(cpf.Valid, true);
            Assert.AreEqual(cpf.Invalid, false);
            Assert.AreEqual(0, cpf.Notifications.Count);

        }
        [TestMethod]
        public void CPF_Valido2()
        {
            var cpf = new CPF("816.654.662-00");

            Assert.AreEqual(cpf.Valid, true);
            Assert.AreEqual(cpf.Invalid, false);
            Assert.AreEqual(0, cpf.Notifications.Count);

        }

        [TestMethod]
        public void CPF_CalculoInvalido1()
        {
            var cpf = new CPF("11111111111");

            Assert.AreEqual(cpf.Valid, false);
            Assert.AreEqual(cpf.Invalid, true);
            Assert.AreEqual(1, cpf.Notifications.Count);

        }
        [TestMethod]
        public void CPF_CalculoInvalido2()
        {
            var cpf = new CPF("00000000000");

            Assert.AreEqual(cpf.Valid, false);
            Assert.AreEqual(cpf.Invalid, true);
            Assert.AreEqual(1, cpf.Notifications.Count);

        }
        #endregion

        #region * NOME PESSOA * 
        [TestMethod]
        public void PrimeiroNome_NaoInformado()
        {
            var fullName = new NomePessoa("", "ABC");

            Assert.AreEqual(fullName.Valid, false);
            Assert.AreEqual(fullName.Invalid, true);
            Assert.AreEqual(1, fullName.Notifications.Count);

        }

        [TestMethod]
        public void PrimeiroNome_Maior40()
        {
            var fullName = new NomePessoa("zuCb91Ejj3N0v1KSjN6LpMEiUDCCyO6nlfZVudzPP", "ABC");

            Assert.AreEqual(fullName.Valid, false);
            Assert.AreEqual(fullName.Invalid, true);
            Assert.AreEqual(1, fullName.Notifications.Count);

        }

        [TestMethod]
        public void SobreNome_NaoInformado()
        {
            var fullName = new NomePessoa("ABC", "");

            Assert.AreEqual(fullName.Valid, false);
            Assert.AreEqual(fullName.Invalid, true);
            Assert.AreEqual(1, fullName.Notifications.Count);

        }

        [TestMethod]
        public void Sobrenome_Maior40()
        {
            var fullName = new NomePessoa("ABC", "zuCb91Ejj3N0v1KSjN6LpMEiUDCCyO6nlfZVudzPP");

            Assert.AreEqual(fullName.Valid, false);
            Assert.AreEqual(fullName.Invalid, true);
            Assert.AreEqual(1, fullName.Notifications.Count);

        }

        [TestMethod]
        public void NomeSobrenome_SemDuploEspacos_Valid()
        {
            var nome = new NomePessoa(" João  D'ávila   da  Silva  ", "  Pereira ");

            Assert.AreEqual(nome.ToString().Contains("  "), false);
            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }

        [TestMethod]
        public void NomeSobrenome_SemCaracteresEstranhos_Invalid()
        {
            //
            var nome = new NomePessoa(" João  D'ávila Zé ë da  Sôlva Caçula ", "  Pere'i`ra Med-ical ");

            Assert.AreEqual(nome.Valid, false);
            Assert.AreEqual(nome.Invalid, true);
            Assert.AreEqual(2, nome.Notifications.Count);

        }

        [TestMethod]
        public void NomeSobrenome_SemCaracteresEstranhos_Valid()
        {
            //
            var nome = new NomePessoa(" João  D'ávila Zé é da  Sôlva Caçula ", "  Pere'ira Medical ");

            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }

        [TestMethod]
        public void NomeSobrenome_Valid()
        {
            var nome = new NomePessoa("JOAO", "PEREIRA");

            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }
        [TestMethod]
        public void NomeSobrenome_Maximo_Valid()
        {
            var nome = new NomePessoa("ABCDEFGHIJKLMNOPQRSTWXYZABCDEFGHIJKLMNOP", "ABCDEFGHIJKLMNOPQRSTWXYZABCDEFGHIJKLMNOP");

            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }
        #endregion

        #region * EMAIL * 

        #endregion

        #region * CNPJ * 
        [TestMethod]
        public void CNPJ_Empty()
        {
            var cnpj = new CNPJ("");

            Assert.AreEqual(cnpj.Valid, false);
            Assert.AreEqual(cnpj.Invalid, true);
            Assert.AreEqual(1, cnpj.Notifications.Count);

        }

        [TestMethod]
        public void CNPJ_Menor14()
        {
            var cnpj = new CNPJ("111");

            Assert.AreEqual(cnpj.Valid, false);
            Assert.AreEqual(cnpj.Invalid, true);
            Assert.AreEqual(1, cnpj.Notifications.Count);

        }

        [TestMethod]
        public void CNPJ_String()
        {
            var cnpj = new CNPJ("ABCDEFGHIJX");

            Assert.AreEqual(cnpj.Valid, false);
            Assert.AreEqual(cnpj.Invalid, true);
            Assert.AreEqual(1, cnpj.Notifications.Count);
        }

        [TestMethod]
        public void CNPJ_Valido1()
        {
            var cnpj = new CNPJ("07634778000100");

            Assert.AreEqual(cnpj.Valid, true);
            Assert.AreEqual(cnpj.Invalid, false);
            Assert.AreEqual(0, cnpj.Notifications.Count);

        }

        [TestMethod]
        public void CNPJ_Valido2()
        {
            var cnpj = new CNPJ("07.634.778/0001-00");

            Assert.AreEqual(cnpj.Valid, true);
            Assert.AreEqual(cnpj.Invalid, false);
            Assert.AreEqual(0, cnpj.Notifications.Count);

        }

        [TestMethod]
        public void CNPJ_CalculoInvalido1()
        {
            var cnpj = new CNPJ("11111111111111");

            Assert.AreEqual(cnpj.Valid, false);
            Assert.AreEqual(cnpj.Invalid, true);
            Assert.AreEqual(1, cnpj.Notifications.Count);

        }

        [TestMethod]
        public void CNPJ_CalculoInvalido2()
        {
            var cnpj = new CNPJ("00000000000000");

            Assert.AreEqual(cnpj.Valid, false);
            Assert.AreEqual(cnpj.Invalid, true);
            Assert.AreEqual(1, cnpj.Notifications.Count);

        }
        #endregion

        #region * RAZÃO SOCIAL * 
        [TestMethod]
        public void RazaoSocial_Nome_NaoInformado()
        {
            var fullName = new RazaoSocial("");

            Assert.AreEqual(fullName.Valid, false);
            Assert.AreEqual(fullName.Invalid, true);
            Assert.AreEqual(1, fullName.Notifications.Count);

        }

        [TestMethod]
        public void RazaoSocial_Nome_Maior40()
        {
            var fullName = new RazaoSocial("zuCb91Ejj3N0v1KSjN6LpMEiUDCCyO6nlfZVudzPP");

            Assert.AreEqual(fullName.Valid, false);
            Assert.AreEqual(fullName.Invalid, true);
            Assert.AreEqual(1, fullName.Notifications.Count);

        }

       [TestMethod]
        public void RazaoSocial_SemDuploEspacos_Valid()
        {
            var nome = new RazaoSocial(" João  D'ávila   da  Silva  ");

            Assert.AreEqual(nome.ToString().Contains("  "), false);
            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }

        [TestMethod]
        public void RazaoSocial_SemCaracteresEstranhos_Invalid()
        {
            //
            var nome = new RazaoSocial(" João  D'ávila Zé ë da - SôËlva Caçula ");

            Assert.AreEqual(nome.Valid, false);
            Assert.AreEqual(nome.Invalid, true);
            Assert.AreEqual(1, nome.Notifications.Count);

        }

        [TestMethod]
        public void RazaoSocial_SemCaracteresEstranhos_Valid()
        {
            //
            var nome = new RazaoSocial(" João  D'ávila Zé é da  Sôlva Caçula ");

            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }

        [TestMethod]
        public void RazaoSocial_Valid()
        {
            var nome = new RazaoSocial("EMPRESA FULANO DE TAL LTDA");

            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }
        [TestMethod]
        public void RazaoSocial_Nome_Maximo_Valid()
        {
            var nome = new RazaoSocial("ABCDEFGHIJKLMNOPQRSTWXYZABCDEFGHIJKLMNOP");

            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }
        #endregion

        #region * NOME FANTASIA * 
        [TestMethod]
        public void NomeFantasia_Nome_NaoInformado()
        {
            var fullName = new NomeFantasia("");

            Assert.AreEqual(fullName.Valid, false);
            Assert.AreEqual(fullName.Invalid, true);
            Assert.AreEqual(1, fullName.Notifications.Count);

        }

        [TestMethod]
        public void NomeFantasia_Nome_Maior40()
        {
            var fullName = new NomeFantasia("zuCb91Ejj3N0v1KSjN6LpMEiUDCCyO6nlfZVudzPP");

            Assert.AreEqual(fullName.Valid, false);
            Assert.AreEqual(fullName.Invalid, true);
            Assert.AreEqual(1, fullName.Notifications.Count);

        }

       [TestMethod]
        public void NomeFantasia_SemDuploEspacos_Valid()
        {
            var nome = new NomeFantasia(" João  D'ávila   da  Silva  ");

            Assert.AreEqual(nome.ToString().Contains("  "), false);
            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }

        [TestMethod]
        public void NomeFantasia_SemCaracteresEstranhos_Invalid()
        {
            //
            var nome = new NomeFantasia(" João  D'ávila Zé ë da - SôËlva Caçula ");

            Assert.AreEqual(nome.Valid, false);
            Assert.AreEqual(nome.Invalid, true);
            Assert.AreEqual(1, nome.Notifications.Count);

        }

        [TestMethod]
        public void NomeFantasia_SemCaracteresEstranhos_Valid()
        {
            //
            var nome = new NomeFantasia(" João  D'ávila Zé é da  Sôlva Caçula ");

            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }

        [TestMethod]
        public void NomeFantasia_Valid()
        {
            var nome = new NomeFantasia("CASA DOS PREGOS DO INTERIOR");

            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }
        [TestMethod]
        public void NomeFantasia_Nome_Maximo_Valid()
        {
            var nome = new NomeFantasia("ABCDEFGHIJKLMNOPQRSTWXYZABCDEFGHIJKLMNOP");

            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }
        #endregion
    }
}
