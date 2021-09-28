using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;
using WebApp.Interfaces;
using WebApp.Entities;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryCliente _repositoryCliente;
        private readonly IRepositoryProduto _repositoryProduto;
        private readonly IRepositoryUsuario _repositoryUsuario;
        public HomeController(ILogger<HomeController> logger, IRepositoryCliente repositoryCliente,IRepositoryProduto repositoryProduto)
        {
            _logger = logger;
            _repositoryCliente = repositoryCliente;
            _repositoryProduto = repositoryProduto;
        }

        public IActionResult Index()
        {
            if(HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard","Home");
            }
            return View();
            
        }
        public IActionResult Dashboard()
        {
            var qtdClientes = _repositoryCliente.GetAll().Count();
            var qtdProdutos = _repositoryProduto.GetAll().Count();
            var qtdVendas = 35;
            
            var dashboardVM = new DashboardViewModel(){
                QtdClientes = qtdClientes,
                QtdProdutos = qtdProdutos,
                QtdVendas = qtdVendas
            };
            return View(dashboardVM);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
