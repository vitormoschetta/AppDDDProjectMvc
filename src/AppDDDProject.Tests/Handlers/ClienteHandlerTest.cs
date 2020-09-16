using System;
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
        public void ClienteHandlerValido()
        {
            var handler = new ClienteHandler(new FakeClienteRepository());
            var command = new ClienteCommand()
            {
                Nome = "Vitor",
                Cpf = "99999999999",
                Email = "vitor.suporte@gmail.com",
                DataNascimento = DateTime.Now,
            };
            handler.Create(command);
            Assert.IsTrue(handler.Valid);
        }


        // Aqui não dá pra testar as propriedades invalidas, pos o Handler sempre seria Valid true. 
        // Isso por causa do Fast Fail Validate => O Command aplica a validação antes de prosseguir nos 
        // demais processos do Handler.

        [TestMethod]
        public void Se_cpf_ja_existe()
        {
            var handler = new ClienteHandler(new FakeClienteRepository());
            var command = new ClienteCommand()
            {
                Nome = "Vitor",
                Cpf = "00000000000",
                Email = "vitor.suporte@gmail.com",
                DataNascimento = DateTime.Now,
            };
            handler.Create(command);
            Assert.IsTrue(handler.Invalid);
        }

    }
}