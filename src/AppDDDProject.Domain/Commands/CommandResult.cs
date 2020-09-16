using AppDDDProject.Shared.Commands;

namespace AppDDDProject.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        // Uma classe de retorno, semalhante ao ResultViewModel
        // Veja que temos dois construtores.
        // Isso quer dizer que podemos instanciar essa classe passando ou não parametros
        public CommandResult()
        { }

        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}