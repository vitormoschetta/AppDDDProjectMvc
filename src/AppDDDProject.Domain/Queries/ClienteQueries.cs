using System;
using System.Linq.Expressions;
using AppDDDProject.Domain.Entities;

namespace AppDDDProject.Domain.Queries
{
    public static class ClienteQueries
    {
        // Cra expressõe para facilitar a consulta

        public static Expression<Func<Cliente, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Cliente, bool>> InformaçõesDoCliente(string cpf)
        {
            return x => x.Cpf == cpf;
        }
    }
}