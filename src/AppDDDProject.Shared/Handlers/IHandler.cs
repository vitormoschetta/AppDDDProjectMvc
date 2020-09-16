using System;
using AppDDDProject.Shared.Commands;

namespace AppDDDProject.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Create(T command);
        ICommandResult Update(T command);
        ICommandResult Delete(Guid id);
    }
}