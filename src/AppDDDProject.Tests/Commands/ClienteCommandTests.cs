using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppDDDProject.Domain.Commands;

namespace AppDDDProject.Tests.Commands
{
    [TestClass]
    public class ClienteCommandTest
    {
        [TestMethod]
        public void ClienteCommand_Valido()
        {
            var command = new ClienteCommand()
            {
                Nome = "Vitor",
                Cpf = "00000000000",
                Email = "vitor@gmail.com",
            };

            command.Validate();
            Assert.AreEqual(true, command.Valid);
        }

        [TestMethod]
        public void Se_nome_possuir_menos_de_3_caracteres()
        {
            var command = new ClienteCommand()
            {
                Nome = "V",
                Cpf = "00000000000",
                Email = "vitor@gmail.com",
            };

            command.Validate();
            Assert.AreEqual(true, command.Invalid);
        }

        [TestMethod]
        public void Se_CPF_nao_possuir_11_caracteres()
        {
            var command = new ClienteCommand()
            {
                Nome = "Vitor",
                Cpf = "000000",
                Email = "vitor@gmail.com",
            };

            command.Validate();
            Assert.AreEqual(true, command.Invalid);
        }

        [TestMethod]
        public void Se_email_invalido()
        {
            var command = new ClienteCommand()
            {
                Nome = "V",
                Cpf = "00000000000",
                Email = "vitor",
            };

            command.Validate();
            Assert.AreEqual(true, command.Invalid);
        }

        [TestMethod]
        public void Se_email_vazio()
        {
            var command = new ClienteCommand()
            {
                Nome = "V",
                Cpf = "00000000000",
                Email = "",
            };

            command.Validate();
            Assert.AreEqual(true, command.Invalid);
        }
    }
}