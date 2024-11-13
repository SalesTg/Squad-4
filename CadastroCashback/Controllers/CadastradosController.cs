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
        public async Task<IActionResult> Index(string nomeCampanha, DateTime? dataInicio, DateTime? dataFim, string status)
        {
            var query = _bancoContext.Campanhas.AsQueryable();


            if (!string.IsNullOrEmpty(nomeCampanha))
            {
                query = query.Where(c => c.Nome.Contains(nomeCampanha));
            }


            if (dataInicio.HasValue && !dataFim.HasValue)
            {

                query = query.Where(c => c.DataInicio.Date == dataInicio.Value.Date);
            }

            else if (!dataInicio.HasValue && dataFim.HasValue)
            {

                query = query.Where(c => c.DataFim.Date == dataFim.Value.Date);
            }

            else if (dataInicio.HasValue && dataFim.HasValue)
            {
                query = query.Where(c => c.DataInicio.Date >= dataInicio.Value.Date && c.DataFim.Date <= dataFim.Value.Date);
            }


            if (!string.IsNullOrEmpty(status) && status != "Todos")
            {
                query = query.Where(c => c.Status == status);
            }


            var model = await query.ToListAsync();
            return View(model);
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Pesquisar(string nomeCampanha, DateTime? dataInicio, DateTime? dataFim, string status)
        {

            return RedirectToAction("Index", new { nomeCampanha, dataInicio, dataFim, status });
        }

        [HttpGet]
        public async Task<IActionResult> Pesquisar()
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

        public async Task<IActionResult> Visualizar(int id)
        {
            var campanha = await _bancoContext.Campanhas.FirstOrDefaultAsync(c => c.Id == id);
            if (campanha == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(campanha);
        }
    }
}
