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
        public async Task<IActionResult> Index()
        {
            var model = await _bancoContext.Campanhas.ToListAsync();
            return View(model);
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

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeletarCampanha(int id)
        {
            var campanha = await _bancoContext.Campanhas.FirstOrDefaultAsync(c => c.Id == id);
            if (campanha == null)
            {
                return RedirectToAction(nameof(Index));
            }


            try
            {
                _bancoContext.Campanhas.Remove(campanha);
                await _bancoContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Deletar(int id)
        {
            var campanha = await _bancoContext.Campanhas.FirstOrDefaultAsync(c => c.Id == id);
            if (campanha == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(campanha);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var campanha = await _bancoContext.Campanhas.FirstOrDefaultAsync(c => c.Id == id);
            if (campanha == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(campanha);
        }

        [HttpPost]
        public async Task<IActionResult> EditarCampanha(Campanha campanha)
        {
            var campanhaExistente = await _bancoContext.Campanhas.FirstOrDefaultAsync(c => c.Id == campanha.Id);
            if (campanhaExistente == null)
            {
                return RedirectToAction(nameof(Index));
            }

            campanhaExistente.Nome = campanha.Nome;
            campanhaExistente.TipoPremiacao = campanha.TipoPremiacao;
            campanhaExistente.TipoCredito = campanha.TipoCredito;
            campanhaExistente.ValorCashback = campanha.ValorCashback;
            campanhaExistente.PercentualCashback = campanha.PercentualCashback;
            campanhaExistente.PontosPorReal = campanha.PontosPorReal;
            campanhaExistente.FatorCategorizacao = campanha.FatorCategorizacao;
            campanhaExistente.DataInicio = campanha.DataInicio;
            campanhaExistente.DataFim = campanha.DataFim;
            campanhaExistente.LimiteQuantitativo = campanha.LimiteQuantitativo;
            campanhaExistente.Mecanica = campanha.Mecanica;
            campanhaExistente.TipoExcecao = campanha.TipoExcecao;


            try
            {
                _bancoContext.Campanhas.Update(campanhaExistente);
                await _bancoContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
