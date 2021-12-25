using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Controllers
{
    public class KitaplarController : Controller
    {
        private readonly KutuphaneDbContext _context;

        public KitaplarController(KutuphaneDbContext context)
        {
            _context = context;
        }

        // GET: Kitaplar
        public async Task<IActionResult> Index()
        {
            var kutuphaneDbContext = _context.Kitaplar.Include(k => k.Kategori).Include(k => k.Yayinevi).Include(k => k.Yazar);
            return View(await kutuphaneDbContext.ToListAsync());
        }

        // GET: Kitaplar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar
                .Include(k => k.Kategori)
                .Include(k => k.Yayinevi)
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.KitapId == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // GET: Kitaplar/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "KategoriAdi");
            ViewData["YayineviId"] = new SelectList(_context.Yayinevleri, "YayineviId", "Adi");

            var q = _context.Yazarlar.Select(p => new { p.YazarId, AdSoyad = p.Ad + " " + p.Soyad });
            ViewData["YazarId"] = new SelectList(q, "YazarId", "AdSoyad");
            return View();
        }

        // POST: Kitaplar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("KitapId,Ad,OzgunAd,SayfaSayisi,Adet,BaskiYili,Dil,Barkod,ISBN,Ceviren,TeminBicimi,EdinmeBedeli,YazarId,KategoriId,YayineviId,KapakResmi,DemirbasNo,YerBilgisi")] Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "KategoriAdi", kitap.KategoriId);
            ViewData["YayineviId"] = new SelectList(_context.Yayinevleri, "YayineviId", "Adi", kitap.YayineviId);

            var q = _context.Yazarlar.Select(p => new { p.YazarId, AdSoyad = p.Ad + " " + p.Soyad });
            ViewData["YazarId"] = new SelectList(q, "YazarId", "AdSoyad");

            return View(kitap);
        }

        // GET: Kitaplar/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "KategoriAdi", kitap.KategoriId);
            ViewData["YayineviId"] = new SelectList(_context.Yayinevleri, "YayineviId", "Adi", kitap.YayineviId);

            var q = _context.Yazarlar.Select(p => new { p.YazarId, AdSoyad = p.Ad + " " + p.Soyad });
            ViewData["YazarId"] = new SelectList(q, "YazarId", "AdSoyad");
            return View(kitap);
        }

        // POST: Kitaplar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("KitapId,Ad,OzgunAd,SayfaSayisi,Adet,BaskiYili,Dil,Barkod,ISBN,Ceviren,TeminBicimi,EdinmeBedeli,YazarId,KategoriId,YayineviId,KapakResmi,DemirbasNo,YerBilgisi")] Kitap kitap)
        {
            if (id != kitap.KitapId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitapExists(kitap.KitapId))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "KategoriId", "KategoriAdi", kitap.KategoriId);
            ViewData["YayineviId"] = new SelectList(_context.Yayinevleri, "YayineviId", "Adi", kitap.YayineviId);
            ViewData["YazarId"] = new SelectList(_context.Yazarlar, "YazarId", "Ad", kitap.YazarId);
            return View(kitap);
        }

        // GET: Kitaplar/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar
                .Include(k => k.Kategori)
                .Include(k => k.Yayinevi)
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.KitapId == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // POST: Kitaplar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            _context.Kitaplar.Remove(kitap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public JsonResult KitapGetir()
        {
               var result = _context.Kitaplar.ToList();
               return Json(result);
        }

        private bool KitapExists(int id)
        {
            return _context.Kitaplar.Any(e => e.KitapId == id);
        }
    }
}
