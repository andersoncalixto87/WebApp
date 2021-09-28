using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList;
using WebApp.Entities;
using WebApp.Interfaces;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IRepositoryProduto _repositoryproduto;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProdutoController(ILogger<ProdutoController> logger,IRepositoryProduto repositoryproduto,IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _repositoryproduto = repositoryproduto;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int? page)
        {

           var produtos = _repositoryproduto.GetAll();
            
            var produtoVM = produtos.Select(c => new ProdutoViewModel
            {
                Descricao = c.Descricao,
                Valor = c.Valor,
                Id = c.Id,
                NomeFoto = c.Foto
            });
            decimal count = produtoVM.Count();
            int pageSize = 10;
            decimal p =  count / pageSize;
            int pagina = p == 1 || p < 1 ? 0 : (int)Math.Ceiling(p);
            int pageNumber = (page ?? 1);
            TempData["ProdutoPage"] = pagina;
            return View(produtoVM.ToPagedList(pageNumber, pageSize));
            
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if(produtoViewModel is null)
            {
                return NotFound();
            }
            string nomeUnicoArquivo = UploadedFile(produtoViewModel);
            var produto = new Produto()
            {
                Descricao = produtoViewModel.Descricao,
                Valor = produtoViewModel.Valor,
                Foto = nomeUnicoArquivo
            };
            _repositoryproduto.Add(produto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var produto = _repositoryproduto.GetById(Id);
            var produtoVM = new ProdutoViewModel()
            {            
                Descricao = produto.Descricao,
                Valor = produto.Valor
            };
            return View(produtoVM);
        }
        [HttpPost]
        public IActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            var produto = new Produto()
            {
                Descricao = produtoViewModel.Descricao,
                Valor = produtoViewModel.Valor,
                Id = produtoViewModel.Id
            };
            _repositoryproduto.Update(produto);
            return RedirectToAction("Index");
        }
        
       
        public IActionResult Delete(Guid Id)
        {
            var produto = _repositoryproduto.GetById(Id);
            if(produto is not null)
                _repositoryproduto.Remove(produto);
            return RedirectToAction("Index");
        }
        private string UploadedFile(ProdutoViewModel model)
        {
            string nomeUnicoArquivo = null;
            if (model.Foto != null)
            {
                string pastaFotos = Path.Combine(_webHostEnvironment.WebRootPath, "Imagens/Produtos");
                nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + model.Foto.FileName;
                string caminhoArquivo = Path.Combine(pastaFotos, nomeUnicoArquivo);
                using (var fileStream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    model.Foto.CopyTo(fileStream);
                }
            }
            return nomeUnicoArquivo;
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}