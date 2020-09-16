using System;
using AppDDDProject.Shared.Entities;
using Flunt.Validations;

namespace AppDDDProject.Domain.Entities
{
    public class Cliente : Entity
    {
        public Cliente(string nome, DateTime dataNascimento, string cpf, string email)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Email = email;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome tem que ter pelo menos 3 caracteres")
                .HasLen(Cpf, 11, "CPF", "CPF deve conter 11 digitos")
                .IsEmail(Email, "Email", "Digite um email válido")
            );
        }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }


        public void AtualizaNomeEDataNascimento(string nome, DateTime dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
        }

    }
}