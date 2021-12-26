using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly KutuphaneDbContext _context;
        private readonly IStringLocalizer<AdminController> _localizer;
        private readonly ILogger<AdminController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public AdminController(ILogger<AdminController> logger, KutuphaneDbContext context, IStringLocalizer<AdminController> localizer, UserManager<AppUser> userManager)
        {
            _context = context;
            _localizer = localizer;
            _logger = logger;
            _userManager = userManager;
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
            AppUser appUser = _context.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault();
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profile(Guid Id, [Bind("Adi,Soyadi,Cinsiyet,TCKimlik,DogumTarihi,Email,PhoneNumber")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _context.Users.First(x => x.Id == Id);
                    user.TCKimlik = appUser.TCKimlik;
                    user.Adi = appUser.Adi;
                    user.Soyadi = appUser.Soyadi;
                    user.Cinsiyet = appUser.Cinsiyet;
                    user.DogumTarihi = appUser.DogumTarihi;
                    user.Email = appUser.Email;
                    user.NormalizedEmail = appUser.Email;
                    user.UserName = appUser.Email;
                    user.NormalizedUserName = appUser.Email;
                    user.PhoneNumber = appUser.PhoneNumber;
                    user.PhoneNumberConfirmed = true;
                    user.EmailConfirmed = true;

                    //_context.Update(user);
                    if (_context.SaveChanges() > 0)
                    {
                        TempData["SuccessMessage"] = "Profil bilgileriniz başarıyla güncellendi!";
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message.ToString());
                }

                return View(appUser);
            }

            return View(appUser);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            ViewBag.UserId = _userManager.GetUserId(HttpContext.User);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                // ChangePasswordAsync changes the user password
                var result = await _userManager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);

                // The new password did not meet the complexity rules or
                // the current password is incorrect. Add these errors to
                // the ModelState and rerender ChangePassword view
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return View();
                }

                TempData["SuccessMessage"] = "Şifreniz başarıyla değiştirildi!";
                return View();
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
