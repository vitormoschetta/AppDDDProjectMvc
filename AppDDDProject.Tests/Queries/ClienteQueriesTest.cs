using System;
using System.Collections.Generic;
using System.Linq;
using AppDDDProject.Domain.Entities;
using AppDDDProject.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppDDDProject.Tests.Queries
{
    [TestClass]
    public class ClienteQueriesTest
    {
        private readonly IList<Cliente> _clientes;

        public ClienteQueriesTest()
        {
            for (int i = 0; i <= 1; i++)
            {
                _clientes.Add(new Cliente("Vitor", DateTime.Now, "11111111111" + i, i.ToString() + "@gmail.com"));
            }
        }

        [TestMethod]
        public void CpfJaExiste()
        {
            var exp = ClienteQueries.InformaçõesDoCliente("00000000011");
            var cliente = _clientes.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(true, cliente);
        }
    }
}