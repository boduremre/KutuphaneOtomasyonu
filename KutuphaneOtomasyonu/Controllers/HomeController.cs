using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
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
            ViewBag.Kitaplar = _context.Kitaplar.Include(x => x.Yazar).Include(x => x.Kategori).ToList();
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
