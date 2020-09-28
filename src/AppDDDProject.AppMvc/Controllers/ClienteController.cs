using System;
using System.Collections.Generic;
using AppDDDProject.AppMvc.Models;
using AppDDDProject.Domain.Commands;
using AppDDDProject.Domain.Handlers;
using AppDDDProject.Domain.Repositories;
using AppDDDProject.Infra.Repositories;
using AutoMapper;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace AppDDDProject.AppMvc.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ClienteHandler _handler;
        public ClienteController(IMapper mapper, ClienteHandler handler)
        {
            _mapper = mapper;
            _handler = handler;
        }

        public IActionResult Index()
        {
            var commandResult = _handler.GetAll();
            var clientes = _mapper.Map<IEnumerable<Cliente>>(commandResult.Objects);
            return View(clientes);
        }


        public IActionResult Create()
        {
            return View(new Cliente() { DataNascimento = DateTime.Now });
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid) return View(cliente);

            var clienteCommand = _mapper.Map<ClienteCommand>(cliente);

            var commandResult = (CommandResult)_handler.Create(clienteCommand);

            if (commandResult.Success == false)
            {
                ModelState.AddModelError(string.Empty, MontaMensagemNotifications(commandResult));
                return View(cliente);
            }

            cliente = _mapper.Map<Cliente>(commandResult.Object);

            ModelState.AddModelError(string.Empty, commandResult.Message);
            return View("Details", cliente);
        }



        public IActionResult Edit(Guid id)
        {
            var commandResult = _handler.GetById(id);
            var cliente = _mapper.Map<Cliente>(commandResult.Object);
            return View(cliente);
        }


        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (!ModelState.IsValid) return View(cliente);

            var clienteCommand = _mapper.Map<ClienteCommand>(cliente);

            var commandResult = (CommandResult)_handler.Update(clienteCommand);

            if (commandResult.Success == false)
            {
                ModelState.AddModelError(string.Empty, MontaMensagemNotifications(commandResult));
                return View(cliente);
            }

            cliente = _mapper.Map<Cliente>(commandResult.Object);

            ModelState.AddModelError(string.Empty, commandResult.Message);
            return View("Details", cliente);
        }




        public IActionResult Delete(Guid id)
        {
            var commandResult = _handler.GetById(id);
            var cliente = _mapper.Map<Cliente>(commandResult.Object);
            return View(cliente);
        }


        [HttpPost]
        public IActionResult DeleteConfirm(Cliente cliente)
        {
            var commandResult = (CommandResult)_handler.Delete(cliente.Id);

            if (commandResult.Success == false)
            {
                ModelState.AddModelError(string.Empty, MontaMensagemNotifications(commandResult));
                return View(cliente);
            }

            return RedirectToAction("Index");
        }


        public string MontaMensagemNotifications(CommandResult commandResult)
        {
            var notifications = (IEnumerable<Notification>)commandResult.Objects;
            var message = commandResult.Message;
            foreach (var item in notifications)
            {
                message += $"{item.Message}. ";
            }
            return message;
        }


        // public async Task<IActionResult> Paginacao(int? pageNumber)
        // {
        //     if (pageNumber == null) pageNumber = 1;
        //     var listaModelo = await _repository.BuscarTodos(pageNumber);
        //     return PartialView("_TabelaIndex", listaModelo);
        // }



        // public async Task<IActionResult> Search(int? pageNumber, string parametro)
        // {
        //     var listaModelo = await _repository.Procurar(pageNumber, parametro);
        //     return PartialView("_TabelaIndex", listaModelo);
        // }
    }
}