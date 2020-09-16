using System;
using AppDDDProject.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppDDDProject.Tests.Entities
{
    [TestClass]
    public class ClienteTests
    {
        [TestMethod]
        public void TestarCpfVazio()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "", "vitormoschetta@gmail.com");
            Assert.IsTrue(cliente.Invalid);
        }

        [TestMethod]
        public void TestarCpfQuantidadeCaracteresDiferente11()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "0000000000", "vitormoschetta@gmail.com");
            Assert.IsTrue(cliente.Invalid);
        }

        [TestMethod]
        public void TestarNomeQuantidadeCaracteresMenorTres()
        {
            var cliente = new Cliente("Vi", DateTime.Now, "0000000000", "vitormoschetta@gmail.com");
            Assert.IsTrue(cliente.Invalid);
        }

        [TestMethod]
        public void TestarEmailInvalido()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "00000000000", "vitormoschetta");
            Assert.IsTrue(cliente.Invalid);
        }

        [TestMethod]
        public void TestarEntidadeValida()
        {
            var cliente = new Cliente("Vitor", DateTime.Now, "96332824204", "vitormoschetta@gmail.com");
            Assert.IsTrue(cliente.Valid);
        }

    }
}
