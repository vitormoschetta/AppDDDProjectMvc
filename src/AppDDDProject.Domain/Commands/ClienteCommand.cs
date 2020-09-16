using System;
using AppDDDProject.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace AppDDDProject.Domain.Commands
{
    public class ClienteCommand : Notifiable, ICommand
    {
        public ClienteCommand() { }
        public ClienteCommand(ClienteCommand command)
        {
            Nome = command.Nome;
            DataNascimento = command.DataNascimento;
            Cpf = command.Cpf;
            Email = command.Email;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }


        // Fast Fail Validate 
        // Podemos usar este método para validar a entidade e retornar logo qualquer erro antes de prosseguir com as demais validações
        // Acaba sendo reduntante as validações do Construtor da Entidade
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