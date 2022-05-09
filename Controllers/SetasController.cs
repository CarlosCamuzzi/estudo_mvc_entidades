using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_calculadora.Models;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.VisualStudio.Web.CodeGeneration;

namespace app_calculadora.Controllers
{
    public class SetasController : Controller
    {       
        private readonly ApplicationDbContext _context;

        public SetasController(ApplicationDbContext context)
        {
            _context = context; 
          
        }

		// GET: Setas
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Seta.Include(s => s.Soma);
			return View(await applicationDbContext.ToListAsync());
		}

		// GET: Setas/Details/5
		public async Task<IActionResult> Details(int id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var seta = await _context.Seta
				.Include(s => s.Soma)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (seta == null)
			{
				return NotFound();
			}

			return View(seta);
		}

		// GET: Setas/Create
		public IActionResult Create()
        {
            ViewData["SomaId"] = new SelectList(_context.Somas, "Id", "Id");
            return View();
        }                

        //POST: Setas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        async Task<IActionResult> Create([Bind("Id,Valor,SomaId")] Seta seta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SomaId"] = new SelectList(_context.Somas, "Id", "Id", seta.SomaId);
            return View(seta);
        }        

        // GET: Setas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seta = await _context.Seta.FindAsync(id);
            if (seta == null)
            {
                return NotFound();
            }
            ViewData["SomaId"] = new SelectList(_context.Somas, "Id", "Id", seta.SomaId);
            return View(seta);
        }

        // POST: Setas/Edit/5      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,SomaId")] Seta seta)
        {
            if (id != seta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetaExists(seta.Id))
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
            ViewData["SomaId"] = new SelectList(_context.Somas, "Id", "Id", seta.SomaId);
            return View(seta);
        }

        // GET: Setas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seta = await _context.Seta
                .Include(s => s.Soma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seta == null)
            {
                return NotFound();
            }

            return View(seta);
        }

        // POST: Setas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seta = await _context.Seta.FindAsync(id);
            _context.Seta.Remove(seta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetaExists(int id)
        {
            return _context.Seta.Any(e => e.Id == id);
        }
    }
}
