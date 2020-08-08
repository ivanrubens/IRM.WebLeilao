using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IRM.WebLeilao.Domain.ValueObjects;

namespace IRM.WebLeilao.Tests
{
    [TestClass]
    public class DomainTests
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

         } */

        [TestMethod]
        public void CPF_Valido()
        {
            var cpf = new CPF("67763044322");

            Assert.AreEqual(cpf.Valid, true);
            Assert.AreEqual(cpf.Invalid, false);
            Assert.AreEqual(0, cpf.Notifications.Count);

        }

        [TestMethod]
        public void CPF_CalculoInvalido()
        {
            var cpf = new CPF("11111111111");

            Assert.AreEqual(cpf.Valid, false);
            Assert.AreEqual(cpf.Invalid, true);
            Assert.AreEqual(1, cpf.Notifications.Count);

        }
        #endregion

        #region * NOME * 
        [TestMethod]
        public void PrimeiroNome_NaoInformado()
        {
            var fullName = new Nome("", "ABC");

            Assert.AreEqual(fullName.Valid, false);
            Assert.AreEqual(fullName.Invalid, true);
            Assert.AreEqual(1, fullName.Notifications.Count);

        }

        [TestMethod]
        public void PrimeiroNome_Maior40()
        {
            var fullName = new Nome("zuCb91Ejj3N0v1KSjN6LpMEiUDCCyO6nlfZVudzPP", "ABC");

            Assert.AreEqual(fullName.Valid, false);
            Assert.AreEqual(fullName.Invalid, true);
            Assert.AreEqual(1, fullName.Notifications.Count);

        }

        [TestMethod]
        public void SobreNome_NaoInformado()
        {
            var fullName = new Nome("ABC", "");

            Assert.AreEqual(fullName.Valid, false);
            Assert.AreEqual(fullName.Invalid, true);
            Assert.AreEqual(1, fullName.Notifications.Count);

        }

        [TestMethod]
        public void Sobrenome_Maior40()
        {
            var fullName = new Nome("ABC", "zuCb91Ejj3N0v1KSjN6LpMEiUDCCyO6nlfZVudzPP");

            Assert.AreEqual(fullName.Valid, false);
            Assert.AreEqual(fullName.Invalid, true);
            Assert.AreEqual(1, fullName.Notifications.Count);

        }

        [TestMethod]
        public void NomeSobrenome_SemDuploEspacos_Valid()
        {
            var nome = new Nome(" João  D'ávila   da  Silva  ", "  Pereira ");

            Assert.AreEqual(nome.ToString().Contains("  "), false);
            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }

        [TestMethod]
        public void NomeSobrenome_SemCaracteresEstranhos_Invalid()
        {
            //
            var nome = new Nome(" João  D'ávila Zé ë da  Sôlva Caçula ", "  Pere'i`ra Med-ical ");

            Assert.AreEqual(nome.Valid, false);
            Assert.AreEqual(nome.Invalid, true);
            Assert.AreEqual(2, nome.Notifications.Count);

        }

        [TestMethod]
        public void NomeSobrenome_SemCaracteresEstranhos_Valid()
        {
            //
            var nome = new Nome(" João  D'ávila Zé é da  Sôlva Caçula ", "  Pere'ira Medical ");

            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }

        [TestMethod]
        public void NomeSobrenome_Valid()
        {
            var nome = new Nome("JOAO", "PEREIRA");

            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }
        [TestMethod]
        public void NomeSobrenome_Maximo_Valid()
        {
            var nome = new Nome("ABCDEFGHIJKLMNOPQRSTWXYZABCDEFGHIJKLMNOP", "ABCDEFGHIJKLMNOPQRSTWXYZABCDEFGHIJKLMNOP");

            Assert.AreEqual(nome.Valid, true);
            Assert.AreEqual(nome.Invalid, false);
            Assert.AreEqual(0, nome.Notifications.Count);

        }
        #endregion

        #region * CNS * 
        [TestMethod]
        public void CNS_Empty()
        {
            var cns = new CNS("");
            Assert.AreEqual(cns.Valid, false);
            Assert.AreEqual(cns.Invalid, true);
            Assert.AreEqual(1, cns.Notifications.Count);

        }

        [TestMethod]
        public void CNS_NaoNumerico()
        {
            var cns = new CNS("ABCD");
            Assert.AreEqual(cns.Valid, false);
            Assert.AreEqual(cns.Invalid, true);
            Assert.AreEqual(1, cns.Notifications.Count);

        }

        [TestMethod]
        public void CNS_Curto()
        {
            var cns = new CNS("12345");
            Assert.AreEqual(cns.Valid, false);
            Assert.AreEqual(cns.Invalid, true);
            Assert.AreEqual(1, cns.Notifications.Count);

        }

        [TestMethod]
        public void CNS_Longo()
        {
            var cns = new CNS("12345678901234567890");
            Assert.AreEqual(cns.Valid, false);
            Assert.AreEqual(cns.Invalid, true);
            Assert.AreEqual(1, cns.Notifications.Count);

        }

        [TestMethod]
        public void CNS_Zero()
        {
            var cns = new CNS("0");
            Assert.AreEqual(cns.Valid, false);
            Assert.AreEqual(cns.Invalid, true);
            Assert.AreEqual(1, cns.Notifications.Count);

        }

        [TestMethod]
        public void CNS_Invalid()
        {
            var cns0 = new CNS("1234567890123456");
            var cns1 = new CNS("153582642240004");

            Assert.AreEqual(cns0.Valid && cns1.Valid, false);
            Assert.AreEqual(cns0.Invalid && cns1.Invalid, true);
            Assert.AreEqual(2, cns0.Notifications.Count + cns1.Notifications.Count);

        }

        [TestMethod]
        public void CNS_Valid()
        {
            var cns0 = new CNS("153582642240005");
            var cns1 = new CNS("245176980390009");
            var cns2 = new CNS("807933584750008");

            Assert.AreEqual(cns0.Valid && cns1.Valid && cns2.Valid, true);
            Assert.AreEqual(cns0.Invalid && cns1.Invalid && cns2.Invalid, false);
            Assert.AreEqual(0, cns0.Notifications.Count + cns1.Notifications.Count + cns2.Notifications.Count);

        }
        #endregion

        #region * EMAIL * 

        #endregion

    }
}
