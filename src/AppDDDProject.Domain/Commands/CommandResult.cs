using System;
using System.Collections.Generic;
using AppDDDProject.Domain.Entities;
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

        public CommandResult(bool success, string message, Object objeto, IEnumerable<Object> objects)
        {
            Success = success;
            Message = message;
            Object = objeto;
            Objects = objects;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public Object Object { get; set; } // Retorna o objeto cadastrado, atualizado ou excluído.
        public IEnumerable<Object> Objects { get; set; } // Retorna ou lista de objetos solicitados, ou Notifications
    }
}