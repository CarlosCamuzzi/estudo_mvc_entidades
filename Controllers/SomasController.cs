using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using app_calculadora.Models;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace app_calculadora.Controllers
{
    public class SomasController : Controller
    {
        private readonly ApplicationDbContext _context;

  //      public static void Inicializar(ApplicationDbContext contexto, Seta seta)
		//{
  //          contexto.seta.Add(01);
		//}

        public SomasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Somas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Somas.ToListAsync());
        }

        // GET: Somas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soma = await _context.Somas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soma == null)
            {
                return NotFound();
            }

            return View(soma);
        }

        // GET: Somas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Somas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroUm,NumeroDois,Resultado")] Soma soma)
        {
            if (ModelState.IsValid)
            {
                soma.Resultado = soma.Somar();
               // soma.Setarvalor();  // não existia

                //habilitados
                //Seta novaSeta = new Seta(); //id da soma, resultado
             //   novaSeta.Setar(soma.Resultado);

                _context.Add(soma);
                await _context.SaveChangesAsync();

                _context.Add(soma.Setarvalor()); // passando nova seta
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soma);
        }

        // GET: Somas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soma = await _context.Somas.FindAsync(id);
            if (soma == null)
            {
                return NotFound();
            }
            return View(soma);
        }

        // POST: Somas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroUm,NumeroDois,Resultado")] Soma soma)
        {
            if (id != soma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SomaExists(soma.Id))
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
            return View(soma);
        }

        // GET: Somas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var soma = await _context.Somas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soma == null)
            {
                return NotFound();
            }

            return View(soma);
        }

        // POST: Somas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var soma = await _context.Somas.FindAsync(id);
            _context.Somas.Remove(soma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SomaExists(int id)
        {
            return _context.Somas.Any(e => e.Id == id);
        }
    }
}
