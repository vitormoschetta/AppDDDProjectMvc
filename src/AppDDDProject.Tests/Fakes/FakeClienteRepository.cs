using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppDDDProject.Domain.Commands;
using AppDDDProject.Domain.Entities;
using AppDDDProject.Domain.Repositories;

namespace AppDDDProject.Tests.Fakes
{
    public class FakeClienteRepository : IClienteRepository
    {


        public bool CpfExists(string cpf)
        {
            if (cpf == "00000000000")
                return true;

            return false;
        }

        public bool Exist(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cliente>> Procurar(string parametro)
        {
            throw new NotImplementedException();
        }

        public void CreateCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Create(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}