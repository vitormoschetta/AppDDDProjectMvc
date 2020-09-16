using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppDDDProject.Domain.Commands;

namespace AppDDDProject.Tests.Commands
{
    [TestClass]
    public class ClienteCommandTests
    {
        [TestMethod]
        public void RetornarErroNomeVazio()
        {
            var command = new ClienteCommand();
            command.Nome = "";
            command.Cpf = "00000000000";

            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }
    }
}