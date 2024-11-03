using CadastroCashback.Data;
using CadastroCashback.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroCashback.Controllers
{
    public class CadastradosController : Controller
    {
        private readonly BancoContext _bancoContext;
        public CadastradosController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Criar()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarPost(Campanha campanha)
        {
            try
            {
                await _bancoContext.Campanhas.AddAsync(campanha);
                await _bancoContext.SaveChangesAsync();

            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            return View();
        }
    }
}
