using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Controllers
{
    public class AdminController : Controller
    {
        private readonly KutuphaneDbContext _context;

        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger, KutuphaneDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            ViewData["UyeSayisi"] = _context.Users.Count();
            ViewData["KitapSayisi"] = _context.Kitaplar.Count();
            ViewData["OduncKitapSayisi"] = _context.OduncKitaplar.Count();
            ViewData["GecikenKitapSayisi"] = _context.OduncKitaplar.Where(x => x.GetirdigiTarih == null && x.GetirecegiTarih < DateTime.Now).Count();
            ViewData["SonKaydedilenKitaplar"] = _context.Kitaplar.Include(o => o.Yazar).Include(o => o.Kategori).OrderByDescending(x => x.KitapId).Take(5).ToList();
            ViewData["OduncVerilen10Kitap"] = _context.OduncKitaplar.Include(o => o.Kitap).Include(o => o.User).Where(x => x.GetirdigiTarih == null).Take(10).ToList();
            ViewData["SonKayitOlan10Uye"] = _context.Users.Take(10).OrderByDescending(x => x.KayitTarihi).ToList();

            return View();
        }

        public IActionResult Profile()
        {
            var appUser = _context.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault();
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(Guid id, [Bind("Adi,Soyadi,Cinsiyet,TCKimlik,DogumTarihi,Email,PhoneNumber")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return RedirectToAction("Profile");
            }

            return View(appUser);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
