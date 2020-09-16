using System;
using AppDDDProject.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppDDDProject.Tests.Entities
{
    [TestClass]
    public class ClienteTests
    {
        [TestMethod]
        public void ClienteCommand_Valido()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "00000000000", "vitormoschetta@gmail.com");
            Assert.IsTrue(cliente.Valid);
        }

        [TestMethod]
        public void Se_nome_possuir_menos_de_3_caracteres()
        {
            var cliente = new Cliente("Vi", DateTime.Now, "00000000000", "vitormoschetta@gmail.com");
            Assert.IsTrue(cliente.Invalid);
        }

        [TestMethod]
        public void Se_CPF_nao_possuir_11_caracteres()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "00000", "vitormoschetta@gmail.com");
            Assert.IsTrue(cliente.Invalid);
        }

        [TestMethod]
        public void Se_email_invalido()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "00000000000", "vitormoschet");
            Assert.IsTrue(cliente.Invalid);
        }

        [TestMethod]
        public void Se_email_vazio()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "00000000000", "");
            Assert.IsTrue(cliente.Invalid);
        }

        [TestMethod]
        public void Se_AtualizaNomeEDataNascimento_nome_vazio()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "00000000000", "vitormoschetta@gmail.com");

            cliente.AtualizaCliente("", "vitormoschetta@gmail.com");

            Assert.IsTrue(cliente.Invalid);
        }

        [TestMethod]
        public void Se_AtualizaNomeEDataNascimento_email_invalido()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "00000000000", "vitormoschetta@gmail.com");

            cliente.AtualizaCliente("Vitor", "");

            Assert.IsTrue(cliente.Invalid);
        }

    }
}
