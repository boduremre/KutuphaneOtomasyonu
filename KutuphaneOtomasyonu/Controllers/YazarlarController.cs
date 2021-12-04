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
    public class YazarlarController : Controller
    {
        private readonly KutuphaneDbContext _context;

        public YazarlarController(KutuphaneDbContext context)
        {
            _context = context;
        }

        // GET: Yazarlar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yazarlar.ToListAsync());
        }

        // GET: Yazarlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yazar = await _context.Yazarlar
                .FirstOrDefaultAsync(m => m.YazarId == id);
            if (yazar == null)
            {
                return NotFound();
            }

            return View(yazar);
        }

        // GET: Yazarlar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yazarlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YazarId,Ad,Soyad,Biyografi,ResimUrl")] Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yazar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yazar);
        }

        // GET: Yazarlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yazar = await _context.Yazarlar.FindAsync(id);
            if (yazar == null)
            {
                return NotFound();
            }
            return View(yazar);
        }

        // POST: Yazarlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YazarId,Ad,Soyad,Biyografi,ResimUrl")] Yazar yazar)
        {
            if (id != yazar.YazarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yazar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YazarExists(yazar.YazarId))
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
            return View(yazar);
        }

        // GET: Yazarlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yazar = await _context.Yazarlar
                .FirstOrDefaultAsync(m => m.YazarId == id);
            if (yazar == null)
            {
                return NotFound();
            }

            return View(yazar);
        }

        // POST: Yazarlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yazar = await _context.Yazarlar.FindAsync(id);
            _context.Yazarlar.Remove(yazar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YazarExists(int id)
        {
            return _context.Yazarlar.Any(e => e.YazarId == id);
        }
    }
}
