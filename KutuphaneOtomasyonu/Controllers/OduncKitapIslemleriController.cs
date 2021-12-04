using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OduncKitapIslemleriController : Controller
    {
        private readonly KutuphaneDbContext _context;

        public OduncKitapIslemleriController(KutuphaneDbContext context)
        {
            _context = context;
        }

        // GET: OduncKitapIslemleri
        public async Task<IActionResult> Index()
        {
            var kutuphaneDbContext = _context.OduncKitaplar.Include(o => o.Kitap).Include(o => o.User).Include(o => o.Kitap.Yazar).Include(o => o.Kitap.Yayinevi);
            return View(await kutuphaneDbContext.ToListAsync());
        }

        // GET: OduncKitapIslemleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oduncKitap = await _context.OduncKitaplar
                .Include(o => o.Kitap)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oduncKitap == null)
            {
                return NotFound();
            }

            return View(oduncKitap);
        }

        // GET: OduncKitapIslemleri/Create
        public IActionResult Create()
        {
            ViewData["KitapId"] = new SelectList(_context.Kitaplar, "KitapId", "Ad");
            //ViewData["UyeId"] = new SelectList(_context.Uyeler, "UyeId", "Uye");

            // uye bilgileri getiriliyor
            var q = _context.Users.Select(p => new { p.Id, AdSoyad = p.Adi + " " + p.Soyadi + " (" + p.Email + ")" });
            ViewData["UserId"] = new SelectList(q, "Id", "AdSoyad");
            return View();
        }

        // POST: OduncKitapIslemleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KitapId,UserId,AlisTarihi,GetirecegiTarih,GetirdigiTarih")] OduncKitap oduncKitap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oduncKitap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["KitapId"] = new SelectList(_context.Kitaplar, "KitapId", "Ad", oduncKitap.KitapId);

            var q = _context.Users.Select(p => new { p.Id, AdSoyad = p.Adi + " " + p.Soyadi + " (" + p.Email + ")" });
            ViewData["UserId"] = new SelectList(q, "Id", "AdSoyad");

            return View(oduncKitap);
        }

        // GET: OduncKitapIslemleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oduncKitap = await _context.OduncKitaplar.FindAsync(id);
            if (oduncKitap == null)
            {
                return NotFound();
            }
            ViewData["KitapId"] = new SelectList(_context.Kitaplar, "KitapId", "Ad", oduncKitap.KitapId);
            ViewData["UyeId"] = new SelectList(_context.Users, "UyeId", "Eposta", oduncKitap.UserId);
            return View(oduncKitap);
        }

        // POST: OduncKitapIslemleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KitapId,UyeId,AlisTarihi,GetirecegiTarih,GetirdigiTarih")] OduncKitap oduncKitap)
        {
            if (id != oduncKitap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oduncKitap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OduncKitapExists(oduncKitap.Id))
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
            ViewData["KitapId"] = new SelectList(_context.Kitaplar, "KitapId", "Ad", oduncKitap.KitapId);
            ViewData["UyeId"] = new SelectList(_context.Users, "Id", "Email", oduncKitap.UserId);
            return View(oduncKitap);
        }

        // GET: OduncKitapIslemleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oduncKitap = await _context.OduncKitaplar
                .Include(o => o.Kitap)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oduncKitap == null)
            {
                return NotFound();
            }

            return View(oduncKitap);
        }

        // POST: OduncKitapIslemleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oduncKitap = await _context.OduncKitaplar.FindAsync(id);
            _context.OduncKitaplar.Remove(oduncKitap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OduncKitapExists(int id)
        {
            return _context.OduncKitaplar.Any(e => e.Id == id);
        }
    }
}
