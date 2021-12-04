using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Controllers
{
    [Authorize(Roles = "Admin")]
    public class YayinevleriController : Controller
    {
        private readonly KutuphaneDbContext _context;

        public YayinevleriController(KutuphaneDbContext context)
        {
            _context = context;
        }

        // GET: Yayinevleri
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yayinevleri.ToListAsync());
        }

        // GET: Yayinevleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yayinevi = await _context.Yayinevleri
                .FirstOrDefaultAsync(m => m.YayineviId == id);
            if (yayinevi == null)
            {
                return NotFound();
            }

            return View(yayinevi);
        }

        // GET: Yayinevleri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yayinevleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YayineviId,Adi")] Yayinevi yayinevi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yayinevi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yayinevi);
        }

        // GET: Yayinevleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yayinevi = await _context.Yayinevleri.FindAsync(id);
            if (yayinevi == null)
            {
                return NotFound();
            }
            return View(yayinevi);
        }

        // POST: Yayinevleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YayineviId,Adi")] Yayinevi yayinevi)
        {
            if (id != yayinevi.YayineviId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yayinevi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YayineviExists(yayinevi.YayineviId))
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
            return View(yayinevi);
        }

        // GET: Yayinevleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yayinevi = await _context.Yayinevleri
                .FirstOrDefaultAsync(m => m.YayineviId == id);
            if (yayinevi == null)
            {
                return NotFound();
            }

            return View(yayinevi);
        }

        // POST: Yayinevleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yayinevi = await _context.Yayinevleri.FindAsync(id);
            _context.Yayinevleri.Remove(yayinevi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YayineviExists(int id)
        {
            return _context.Yayinevleri.Any(e => e.YayineviId == id);
        }
    }
}
