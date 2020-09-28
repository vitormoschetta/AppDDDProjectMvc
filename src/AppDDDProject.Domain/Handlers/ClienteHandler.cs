using System;
using System.Collections.Generic;
using System.Linq;
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
            //Fast Fail Validations           
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro. ", null, command.Notifications);


            if (_repository.CpfExists(command.Cpf))
                AddNotification("CPF", "Este CPF já está em uso. ");

            // Gerar Value Objecst (caso esteja trabalhando com VOs)

            var cliente = new Cliente(command.Nome, command.DataNascimento, command.Cpf, command.Email);

            // Agrupar as Validações
            AddNotifications(command, cliente);

            // Checa se existem notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar o cadastro. ", null, Notifications);

            // Salvar cliente no banco:     
            _repository.Create(cliente);

            return new CommandResult(true, "Cadastro realizado com sucesso. ", cliente, Notifications);
        }

        public ICommandResult Update(ClienteCommand command)
        {
            //Fast Fail Validations          
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Não foi possível atualizar. ", null, command.Notifications);



            // Recupera o cliente (Rehidratação)
            var cliente = _repository.GetById(command.Id);

            // Atualiza
            cliente.AtualizaCliente(command.Nome, command.Email);

            // Agrupar as Validações
            AddNotifications(command, cliente);

            // Checa se existem notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível atualizar. ", null, Notifications);

            // Salva no banco
            _repository.Update(cliente);

            // Retornar informações : command result
            return new CommandResult(true, "Cadastro atualizado com sucesso. ", cliente, Notifications);
        }


        public ICommandResult Delete(Guid id)
        {
            // Recupera o cliente (Rehidratação)
            var cliente = _repository.GetById(id);
            if (cliente == null)
                return new CommandResult(false, "Cliente não existe. ", null, Notifications);

            // Salva no banco
            _repository.Delete(cliente.Id);

            // Retornar informações : command result
            return new CommandResult(true, "Informações Excluídas. ", cliente, Notifications);
        }


        public CommandResult GetAll()
        {
            var clientes = _repository.GetAll();
            if (clientes.Count() > 0)
                return new CommandResult(true, string.Empty, null, clientes);

            return new CommandResult(false, "Não existem clientes cadastrados", null, Notifications);
        }

        public CommandResult GetById(Guid id)
        {
            var cliente = _repository.GetById(id);
            if (cliente != null)
                return new CommandResult(true, string.Empty, cliente, Notifications);

            return new CommandResult(false, "Cliente não encontrado", null, Notifications);
        }


    }
}