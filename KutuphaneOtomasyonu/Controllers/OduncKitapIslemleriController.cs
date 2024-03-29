﻿using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Controllers
{
    [Authorize]
    public class OduncKitapIslemleriController : Controller
    {
        private readonly KutuphaneDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OduncKitapIslemleriController(KutuphaneDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: OduncKitapIslemleri
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var kutuphaneDbContext = _context.OduncKitaplar.Include(o => o.Kitap).Include(o => o.User).Include(o => o.Kitap.Yazar).Include(o => o.Kitap.Yayinevi).Where(x => x.GetirdigiTarih == null);
            return View(await kutuphaneDbContext.ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var kutuphaneDbContext = _context.OduncKitaplar.Include(o => o.Kitap).Include(o => o.User).Include(o => o.Kitap.Yazar).Include(o => o.Kitap.Yayinevi).Where(x => x.GetirdigiTarih != null);
            return View(await kutuphaneDbContext.ToListAsync());
        }

        public async Task<IActionResult> IndexUser()
        {
            string userID = _userManager.GetUserId(User);

            var kutuphaneDbContext = _context.OduncKitaplar.Include(o => o.Kitap).Include(o => o.User).Include(o => o.Kitap.Yazar).Include(o => o.Kitap.Yayinevi).Where(x => x.UserId.ToString() == userID);
            return View(await kutuphaneDbContext.ToListAsync());
        }

        // GET: OduncKitapIslemleri/Details/5

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            // adedi 0'dan büyük olanlar
            var kitaplar = _context.Kitaplar.Select(p => new { p.KitapId, Ad = p.Ad, Adet = p.Adet, OduncAdet = p.OduncAdet }).Where(y => y.Adet > 0 && y.Adet > y.OduncAdet);
            ViewData["KitapId"] = new SelectList(kitaplar, "KitapId", "Ad");

            // kullanıcı/uye bilgileri getiriliyor
            var q = _context.Users.Select(p => new { p.Id, AdSoyad = p.Adi + " " + p.Soyadi + " (" + p.Email + ")" });
            ViewData["UserId"] = new SelectList(q, "Id", "AdSoyad");
            return View();
        }

        // POST: OduncKitapIslemleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,KitapId,UserId,AlisTarihi,GetirecegiTarih,GetirdigiTarih")] OduncKitap oduncKitap)
        {
            if (ModelState.IsValid)
            {
                //eğer ödünç verilen kitap sayısı toplam adette eşit veya fazla ise hata ver
                //çünkü bu kitaptan başka kopya yok.
                var kitap = _context.Kitaplar.FindAsync(oduncKitap.KitapId).Result;
                if (kitap.Adet == kitap.OduncAdet || kitap.Adet <= kitap.OduncAdet)
                {
                    return NotFound();
                }

                // odunc verilen kitap sayisini arttır.
                kitap.OduncAdet++;
                _context.Add(oduncKitap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // adedi 0'dan büyük olanlar
            var kitaplar = _context.Kitaplar.Select(p => new { p.KitapId, Ad = p.Ad, Adet = p.Adet }).Where(y => y.Adet > 0);
            ViewData["KitapId"] = new SelectList(kitaplar, "KitapId", "Ad");

            var q = _context.Users.Select(p => new { p.Id, AdSoyad = p.Adi + " " + p.Soyadi + " (" + p.Email + ")" });
            ViewData["UserId"] = new SelectList(q, "Id", "AdSoyad");

            return View(oduncKitap);
        }

        // GET: OduncKitapIslemleri/Edit/5
        [Authorize(Roles = "Admin")]
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

            var q = _context.Users.Select(p => new { p.Id, AdSoyad = p.Adi + " " + p.Soyadi + " (" + p.Email + ")" }).Where(x => x.Id == oduncKitap.UserId);
            ViewData["UserId"] = new SelectList(q, "Id", "AdSoyad");

            return View(oduncKitap);
        }

        // POST: OduncKitapIslemleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KitapId,UserId,AlisTarihi,GetirecegiTarih,GetirdigiTarih")] OduncKitap oduncKitap)
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

            var q = _context.Users.Select(p => new { p.Id, AdSoyad = p.Adi + " " + p.Soyadi + " (" + p.Email + ")" }).Where(x => x.Id == oduncKitap.UserId);
            ViewData["UserId"] = new SelectList(q, "Id", "AdSoyad");

            return View(oduncKitap);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult GetirdiOlarakIsaretleJSON(int GetirilenKitapId)
        {
            var oduncKitap = _context.OduncKitaplar.Find(GetirilenKitapId);
            oduncKitap.GetirdigiTarih = System.DateTime.Now;
            int status = _context.SaveChanges();
            if (status > 0)
            {
                if (_context.Kitaplar.Find(oduncKitap.KitapId).OduncAdet == 0)
                    _context.Kitaplar.Find(oduncKitap.KitapId).OduncAdet = 0;
                else
                    _context.Kitaplar.Find(oduncKitap.KitapId).OduncAdet--;

                _context.SaveChanges();
                return Json("true");
            }
            else
            {
                return Json("false");
            }
        }

        private bool OduncKitapExists(int id)
        {
            return _context.OduncKitaplar.Any(e => e.Id == id);
        }
    }
}
