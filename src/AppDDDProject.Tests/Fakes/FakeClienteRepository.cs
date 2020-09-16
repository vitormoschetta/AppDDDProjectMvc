using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppDDDProject.Domain.Entities;
using AppDDDProject.Domain.Repositories;

namespace AppDDDProject.Tests.Fakes
{
    public class FakeClienteRepository : IClienteRepository
    {
        private readonly List<Cliente> listaClientes;
        public FakeClienteRepository()
        {
            listaClientes = new List<Cliente>() {
                new Cliente(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0537"), "Vitor", DateTime.Now, "00000000000", "vitormoschetta@gmail.com"),
                new Cliente(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538"), "teste", DateTime.Now, "00000000001", "teste@gmail.com"),
                new Cliente(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0539"), "teste", DateTime.Now, "00000000001", "teste@gmail.com"),
            };
        }

        public bool CpfExists(string cpf)
        {
            foreach (var item in listaClientes)
            {
                if (cpf == item.Cpf)
                    return true;
            }

            return false;
        }

        public void Create(Cliente cliente)
        {
            listaClientes.Add(cliente);
        }


        public void Delete(Guid id)
        {
            foreach (var item in listaClientes)
            {
                if (id == item.Id)
                    listaClientes.Remove(item);
            }
        }

        public bool Exist(Guid id)
        {
            foreach (var item in listaClientes)
            {
                if (id == item.Id)
                    return true;
            }

            return false;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return listaClientes;
        }

        public Cliente GetById(Guid id)
        {
            foreach (var item in listaClientes)
            {
                if (id == item.Id)
                    return item;
            }

            return null;
        }

        public void Update(Cliente cliente)
        {
            foreach (var item in listaClientes)
            {
                if (cliente.Id == item.Id)
                {
                    listaClientes.Remove(item);
                    listaClientes.Add(cliente);
                }

            }
        }

    }
}