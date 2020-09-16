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

            Validate();
        }

        // Um construtor que recebe Id 
        public Cliente(Guid id, string nome, DateTime dataNascimento, string cpf, string email)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Email = email;

            Validate();
        }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }


        public void AtualizaCliente(string nome, string email)
        {
            Nome = nome;
            Email = email;

            Validate();
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires() // Cada um desses métodos invocados adiciona uma Notification caso a propriedade seja inválida
                    .HasMinLen(Nome, 3, "Nome", "Nome tem que ter pelo menos 3 caracteres")
                    .HasLen(Cpf, 11, "CPF", "CPF deve conter 11 digitos")
                    .IsEmail(Email, "Email", "Digite um email válido")
            );
        }


    }
}