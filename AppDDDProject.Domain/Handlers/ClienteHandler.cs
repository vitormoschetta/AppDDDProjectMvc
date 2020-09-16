using System;
using AppDDDProject.Domain.Commands;
using AppDDDProject.Domain.Entities;
using AppDDDProject.Domain.Repositories;
using AppDDDProject.Domain.Services;
using AppDDDProject.Shared.Commands;
using AppDDDProject.Shared.Handlers;
using Flunt.Notifications;

namespace AppDDDProject.Domain.Handlers
{
    public class ClienteHandler : Notifiable, IHandler<ClienteCommand>
    {
        private readonly IClienteRepository _repository;
        public ClienteHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Create(ClienteCommand command)
        {
            // Faz validações de Modelo - Fast Fail Validations:            
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro", command.Notifications);

            if (_repository.CpfExists(command.Cpf))
                command.AddNotification("CPF", "Este CPF já está em uso.");

            // Gerar Value Objecst (caso esteja trabalahndo com VOs)

            // Gerar Entidade Cliente   
            var cliente = new Cliente(command.Nome, command.DataNascimento, command.Cpf, command.Email);

            // Agrupar as Validações
            AddNotifications(command, cliente);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro", command.Notifications);

            // Salvar cliente no banco:     
            _repository.Create(cliente);

            // Enviar Email
            // _emailService.Enviar(cliente.Nome, cliente.Email, "Bem vindo", "Seu cadastro foi efetuado.");

            // Retornar informações : command result
            return new CommandResult(true, "Cadastro realizado com sucesso.", command.Notifications);
        }

        public ICommandResult Update(ClienteCommand command)
        {
            // Faz validações de Modelo - Fast Fail Validations:            
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Não foi possível atualizar", command.Notifications);

            // Recupera o cliente (Rehidratação)
            var cliente = _repository.GetById(command.Id);

            // Gerar Value Objecst (caso esteja trabalahndo com VOs)

            // Atualiza
            cliente.AtualizaNomeEDataNascimento(command.Nome, command.DataNascimento);

            // Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível atualizar", command.Notifications);

            // Salva no banco
            _repository.Update(cliente);

            // Retornar informações : command result
            return new CommandResult(true, "Cadastro atualizado com sucesso.", cliente);
        }


        public ICommandResult Delete(Guid id)
        {
            // Recupera o cliente (Rehidratação)
            var cliente = _repository.GetById(id);
            if (cliente == null)
                return new CommandResult(false, "Cliente não existe", null);

            // Salva no banco
            _repository.Delete(cliente.Id);

            // Retornar informações : command result
            return new CommandResult(true, "Excluído com sucesso.", cliente);
        }
    }
}