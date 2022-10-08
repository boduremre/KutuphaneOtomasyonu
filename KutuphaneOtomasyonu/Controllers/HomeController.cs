using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Controllers
{
    public class HomeController : Controller
    {
        private readonly KutuphaneDbContext _context;

        public HomeController(KutuphaneDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //ViewBag.Categories = _context.Kategoriler.OrderBy(x => x.KategoriAdi).ToList();
            ViewBag.Kitaplar = _context.Kitaplar.Include(x => x.Yazar).Include(x => x.Kategori).OrderByDescending(o => o.KayitTarihi).ToList();
            return View();
        }

        // GET: Kitaplar/Details/5
        public async Task<IActionResult> BookDetail(int? id)
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

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // GET: Kitaplar
        public async Task<IActionResult> Books()
        {
            var kutuphaneDbContext = _context.Kitaplar.Include(k => k.Kategori).Include(k => k.Yayinevi).Include(k => k.Yazar);
            return View(await kutuphaneDbContext.ToListAsync());
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
