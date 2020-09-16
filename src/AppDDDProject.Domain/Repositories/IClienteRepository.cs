using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppDDDProject.Domain.Commands;
using AppDDDProject.Domain.Entities;

namespace AppDDDProject.Domain.Repositories
{
    // Abstração do repositório
    public interface IClienteRepository
    {
        void Create(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Guid id);
        Cliente GetById(Guid id);
        IEnumerable<Cliente> GetAll();
        bool CpfExists(string cpf);

    }
}