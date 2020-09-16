using System;

namespace AppDDDProject.AppMvc.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
    }
}