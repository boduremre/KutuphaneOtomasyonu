using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace KutuphaneOtomasyonu.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UyelerController : Controller
    {
        private readonly KutuphaneDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UyelerController(KutuphaneDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Uyeler
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Uyeler/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // GET: Uyeler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uyeler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adi,Soyadi,Cinsiyet,TCKimlik,DogumTarihi,Email,PhoneNumber")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                //appUser.Id = Guid.NewGuid();
                //_context.Add(appUser);
                //await _context.SaveChangesAsync();

                // burada asp.net core identity'nin kullanıcı ekleme metodunu kullanıyoruz çünkü üye ekleme işi sıradan bir create işlemi değil
                // üyenin varsayılan şifresi Kutuphane_123456
                // üye kendide kayıt olabilir ancak sistem yöneticisi kullanıcı eklemek isterse diye eklendi.
                appUser.EmailConfirmed = true;
                appUser.PhoneNumberConfirmed = true;
                appUser.UserName = appUser.Email;
                appUser.NormalizedEmail = appUser.Email;
                appUser.TwoFactorEnabled = false;
                appUser.LockoutEnabled = false;
                appUser.AccessFailedCount = 0;
                appUser.NormalizedUserName = appUser.Email;
                var result = await _userManager.CreateAsync(appUser, "123");
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(appUser);
                }
            }
            return View(appUser);
        }

        // GET: Uyeler/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.Users.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        // POST: Uyeler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Adi,Soyadi,Cinsiyet,TCKimlik,DogumTarihi,Id,UserName,Email,PhoneNumber")] AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppUserExists(appUser.Id))
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
            return View(appUser);
        }

        // GET: Uyeler/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // POST: Uyeler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var appUser = await _context.Users.FindAsync(id);
            _context.Users.Remove(appUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppUserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
