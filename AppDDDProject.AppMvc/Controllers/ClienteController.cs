using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppDDDProject.AppMvc.Models;
using AppDDDProject.Domain.Commands;
using AppDDDProject.Domain.Handlers;
using AppDDDProject.Domain.Repositories;
using AppDDDProject.Infra.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AppDDDProject.AppMvc.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteController(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var clientesDomain = _repository.GetAll();
            var clientes = _mapper.Map<IEnumerable<Cliente>>(clientesDomain);
            return View(clientes);
        }


        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create([FromBody] ClienteCommand command,
                                    [FromServices] ClienteHandler handler)
        {
            if (!ModelState.IsValid) return View(command);

            // AutoMapper para converter de Cliente para CreateClienteCommand

            var resultado = (CommandResult)handler.Create(command);
            if (resultado.Success == false)
            {
                ModelState.AddModelError(string.Empty, resultado.Message);
                return View(command); // retorna commandResult, diferente do tipo CreateclienteCommand/Cliente
            }
            return RedirectToAction("Index");
        }



        public IActionResult Edit(Guid id,
                                    [FromServices] ClienteRepository _repository)
        {
            var cliente = _repository.GetById(id);
            return View(cliente);
        }


        [HttpPost]
        public IActionResult Edit([FromBody] ClienteCommand command,
                                    [FromServices] ClienteHandler handler)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Modelo inválido.");
                return View(command);
            }

            var resultado = (CommandResult)handler.Update(command);
            if (resultado.Success == false)
            {
                ModelState.AddModelError(string.Empty, resultado.Message);
                return View(resultado); // retorna commandResult, diferente do tipo CreateclienteCommand/Cliente
            }

            return RedirectToAction("Index");
        }




        public IActionResult Delete(Guid id,
                                    [FromServices] ClienteRepository _repository)
        {
            var cliente = _repository.GetById(id);
            return View(cliente);
        }


        [HttpPost]
        public IActionResult DeleteConfirm(Guid id,
                                            [FromServices] ClienteHandler handler)
        {
            var resultado = (CommandResult)handler.Delete(id);

            if (resultado.Success != true)
            {
                ModelState.AddModelError(string.Empty, resultado.Message);
                return View();
            }

            return RedirectToAction("Index");
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