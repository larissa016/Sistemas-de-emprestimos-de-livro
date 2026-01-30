using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistemas_de_emprestimos_de_livro.Data;
using Sistemas_de_emprestimos_de_livro.Models;

namespace Sistemas_de_emprestimos_de_livro.Controllers
{
    public class RenovacaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RenovacaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Renovacaos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Renovacao.Include(r => r.Emprestimo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Renovacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renovacao = await _context.Renovacao
                .Include(r => r.Emprestimo)
                .FirstOrDefaultAsync(m => m.RenovacaoId == id);
            if (renovacao == null)
            {
                return NotFound();
            }

            return View(renovacao);
        }

        // GET: Renovacaos/Create
        public IActionResult Create()
        {
            ViewData["EmprestimoId"] = new SelectList(_context.Emprestimo, "EmprestimoId", "EmprestimoId");
            return View();
        }

        // POST: Renovacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RenovacaoId,DataRenovacao,NovaDataDevolucao,EmprestimoId")] Renovacao renovacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renovacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmprestimoId"] = new SelectList(_context.Emprestimo, "EmprestimoId", "EmprestimoId", renovacao.EmprestimoId);
            return View(renovacao);
        }

        // GET: Renovacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renovacao = await _context.Renovacao.FindAsync(id);
            if (renovacao == null)
            {
                return NotFound();
            }
            ViewData["EmprestimoId"] = new SelectList(_context.Emprestimo, "EmprestimoId", "EmprestimoId", renovacao.EmprestimoId);
            return View(renovacao);
        }

        // POST: Renovacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RenovacaoId,DataRenovacao,NovaDataDevolucao,EmprestimoId")] Renovacao renovacao)
        {
            if (id != renovacao.RenovacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renovacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RenovacaoExists(renovacao.RenovacaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmprestimoId"] = new SelectList(_context.Emprestimo, "EmprestimoId", "EmprestimoId", renovacao.EmprestimoId);
            return View(renovacao);
        }

        // GET: Renovacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renovacao = await _context.Renovacao
                .Include(r => r.Emprestimo)
                .FirstOrDefaultAsync(m => m.RenovacaoId == id);
            if (renovacao == null)
            {
                return NotFound();
            }

            return View(renovacao);
        }

        // POST: Renovacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var renovacao = await _context.Renovacao.FindAsync(id);
            if (renovacao != null)
            {
                _context.Renovacao.Remove(renovacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RenovacaoExists(int id)
        {
            return _context.Renovacao.Any(e => e.RenovacaoId == id);
        }
    }
}
