using AppDDDProject.Domain.Commands;
using AppDDDProject.Domain.Handlers;
using AppDDDProject.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppDDDProject.Tests.Handlers
{
    [TestClass]
    public class ClienteHandlerTest
    {
        [TestMethod]
        public void CpfJaExiste()
        {
            var handler = new ClienteHandler(new FakeClienteRepository());
            var command = new ClienteCommand();
            command.Nome = "Vitor";
            command.Cpf = "00000000000";
            command.Email = "vitormoschetta@gmail.com";

            handler.Create(command);
            Assert.AreEqual(false, handler.Valid);
        }


        [TestMethod]
        public void EmailInvalido()
        {
            var handler = new ClienteHandler(new FakeClienteRepository());
            var command = new ClienteCommand();
            command.Nome = "Vitor";
            command.Cpf = "99999999999";
            command.Email = "vitormoschetta@gmail.com";

            handler.Create(command);
            Assert.AreEqual(true, handler.Valid);
        }


        [TestMethod]
        public void ClienteHandlerValido()
        {
            var handler = new ClienteHandler(new FakeClienteRepository());
            var command = new ClienteCommand();
            command.Nome = "Vitor";
            command.Cpf = "99999999999";
            command.Email = "vitor.suporte@gmail.com";

            handler.Create(command);
            Assert.AreEqual(true, handler.Valid);
        }
    }
}