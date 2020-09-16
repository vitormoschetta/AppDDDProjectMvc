using System;
using System.Collections.Generic;
using AppDDDProject.Shared.Commands;
using Flunt.Notifications;

namespace AppDDDProject.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        // Uma classe de retorno, semalhante ao ResultViewModel
        // Veja que temos dois construtores.
        // Isso quer dizer que podemos instanciar essa classe passando ou não parametros
        public CommandResult()
        { }

        public CommandResult(bool success, string message, IReadOnlyCollection<Notification> data, object Object)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public IReadOnlyCollection<Notification> Data { get; set; } // Retornar uma lista com notificações
        public object Object { get; set; } // Retorna o objeto cadastrado, atualizado ou excluído.
    }
}