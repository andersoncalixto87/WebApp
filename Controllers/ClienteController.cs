using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IRepositoryCliente _repositoryCliente;
        public ClienteController(ILogger<ClienteController> logger, IRepositoryCliente repositoryCliente)
        {
            _logger = logger;
            _repositoryCliente = repositoryCliente;
        }
        
        public IActionResult Index(int? page)
        {
            var Clientes = _repositoryCliente.GetAll();
          
            var clienteVM = Clientes.Select(c => new ClienteViewModel
            {
                Nome = c.Nome,
                Email = c.Email,
                Bairro = c.Bairro,
                Cep = c.Cep,
                Cidade = c.Cidade,
                CPF = c.CPF,
                DataNasc = c.DataNasc,
                Endereco = c.Endereco,
                Estado = c.Estado,
                Telefone = c.Telefone,
                Id = c.Id,
                Sexo = c.Sexo
            });
            decimal count = clienteVM.Count();
            int pageSize = 10;
            decimal p =  count / pageSize;
            int pagina = p == 1 || p < 1 ? 0 : (int)Math.Ceiling(p);
            int pageNumber = (page ?? 1);
            TempData["ClientePage"] = pagina;
            return View(clienteVM.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }
        [HttpPost]
        public IActionResult Create(ClienteViewModel clienteViewModel)
        {            
            if(clienteViewModel is null)
            {
                return NotFound();
            }

            var cliente = new Cliente(){
            Nome = clienteViewModel.Nome,
            Email = clienteViewModel.Email,
            Bairro = clienteViewModel.Bairro,
            Cep = clienteViewModel.Cep,
            Cidade = clienteViewModel.Cidade,
            CPF = clienteViewModel.CPF,
            DataNasc = clienteViewModel.DataNasc,
            Endereco = clienteViewModel.Endereco,
            Estado = clienteViewModel.Estado,
            Telefone = clienteViewModel.Telefone,
            Sexo = clienteViewModel.Sexo
            };
            
            _repositoryCliente.Add(cliente);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var cliente = _repositoryCliente.GetById(Id);
            var clienteVM = new ClienteViewModel(){
            Nome = cliente.Nome,
            Email = cliente.Email,
            Bairro = cliente.Bairro,
            Cep = cliente.Cep,
            Cidade = cliente.Cidade,
            CPF = cliente.CPF,
            DataNasc = cliente.DataNasc,
            Endereco = cliente.Endereco,
            Estado = cliente.Estado,
            Telefone = cliente.Telefone,
            Id = cliente.Id,
            Sexo = cliente.Sexo
            };
            return View(clienteVM);
        }
        [HttpPost]
        public IActionResult Edit(ClienteViewModel clienteViewModel)
        {
            var cliente = new Cliente(){
            Nome = clienteViewModel.Nome,
            Email = clienteViewModel.Email,
            Bairro = clienteViewModel.Bairro,
            Cep = clienteViewModel.Cep,
            Cidade = clienteViewModel.Cidade,
            CPF = clienteViewModel.CPF,
            DataNasc = clienteViewModel.DataNasc,
            Endereco = clienteViewModel.Endereco,
            Estado = clienteViewModel.Estado,
            Telefone = clienteViewModel.Telefone,
            Id = clienteViewModel.Id,
            Sexo = clienteViewModel.Sexo
            };
            _repositoryCliente.Update(cliente);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid Id)
        {
            var cliente = _repositoryCliente.GetById(Id);
            if(cliente is not null)
                _repositoryCliente.Remove(cliente);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}