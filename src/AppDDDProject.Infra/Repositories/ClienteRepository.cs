using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDDDProject.Domain.Commands;
using AppDDDProject.Domain.Entities;
using AppDDDProject.Domain.Repositories;
using AppDDDProject.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace AppDDDProject.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Cliente.ToList();
        }

        public Cliente GetById(Guid id)
        {
            return _context.Cliente.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var cliente = _context.Cliente.FirstOrDefault(x => x.Id == id);
            _context.Remove(cliente);
            _context.SaveChanges();
        }

        public bool CpfExists(string cpf)
        {
            var cliente = _context.Cliente.FirstOrDefault(x => x.Cpf == cpf);
            if (cliente != null) return true;
            return false;
        }
    }
}