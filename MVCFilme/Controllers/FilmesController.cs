using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCFilme.Models;

namespace MVCFilme.Controllers
{
    public class FilmesController : Controller
    {
        private readonly MVCFilmeContext _context;

        public FilmesController(MVCFilmeContext context)
        {
            _context = context;    
        }

        // GET: Filmes
        public async Task<IActionResult> Index(string filmeGenero, string criterioBusca)
        {
            IQueryable<string> consultaGenero = from m in _context.Filme orderby m.Genero select m.Genero;

            var filmes = from m in _context.Filme select m;

            if (!String.IsNullOrEmpty(criterioBusca))
            {
                filmes = filmes.Where(f => f.Titulo.Contains(criterioBusca));
            }

            if (!String.IsNullOrEmpty(filmeGenero))
            {
                filmes = filmes.Where(x => x.Genero == filmeGenero);
            }

            var filmeGeneroVM = new FilmeGeneroViewModel();
            filmeGeneroVM.generos = new SelectList(await consultaGenero.Distinct().ToListAsync());
            filmeGeneroVM.filmes = await filmes.ToListAsync();

            return View(filmeGeneroVM);
        }

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme
                .SingleOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Lancamento,Genero,Preco,Classificacao")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filme);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.SingleOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Lancamento,Genero,Preco,Classificacao")] Filme filme)
        {
            if (id != filme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme
                .SingleOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filme = await _context.Filme.SingleOrDefaultAsync(m => m.Id == id);
            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FilmeExists(int id)
        {
            return _context.Filme.Any(e => e.Id == id);
        }
    }
}
