using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KutuphaneOtomasyonu.Controllers
{
    [Route("api/kitaplar")]  //For using kitaplarapi via chrome.
    [ApiController]
    public class KitaplarApiController : ControllerBase
    {

        private readonly KutuphaneDbContext _context;

        public KitaplarApiController(KutuphaneDbContext context)
        {
            _context = context;
        }


        // GET: api/<KitaplarApiController>
        [HttpGet]
        public List<Kitap> Get()
        {
            // https://stackoverflow.com/questions/59199593/net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported
            var k = _context.Kitaplar.Include(k => k.Kategori).Include(x => x.Yayinevi).Include(y => y.Yazar).ToList();
            return k;
        }

        // GET api/<KitaplarApiController>/5
        [HttpGet("{id}")]
        public Kitap Get(int id)
        {
            var k = _context.Kitaplar.Include(k => k.Kategori).Include(x => x.Yayinevi).Include(y => y.Yazar).FirstOrDefault(x => x.KitapId == id);
            return k;
        }

        // POST api/<KitaplarApiController>
        [HttpPost]
        public void Post([FromBody] Kitap k)
        {
            _context.Kitaplar.Add(k);
            _context.SaveChanges();
        }

        // PUT api/<KitaplarApiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Kitap k)
        {
            var kNew = _context.Kitaplar.FirstOrDefault(x => x.KitapId == id);

            if (kNew is null)
            {
                return NotFound();
            }
            else
            {
                kNew.Ad = k.Ad;
                kNew.Barkod = k.Barkod;
                kNew.BaskiYili = k.BaskiYili;
                kNew.Ceviren = k.Ceviren;
                kNew.DemirbasNo = k.DemirbasNo;
                kNew.Dil = k.Dil;
                kNew.EdinmeBedeli = k.EdinmeBedeli;
                kNew.OzgunAd = k.OzgunAd;
                kNew.SayfaSayisi = k.SayfaSayisi;
                kNew.Yayinevi = k.Yayinevi;
                kNew.Yazar = k.Yazar;

                _context.Update(kNew);
                _context.SaveChanges();
                return Ok();
            }
        }

        // DELETE api/<KitaplarApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var k = _context.Kitaplar.FirstOrDefault(x => x.KitapId == id);
            _context.Remove(k);
            _context.SaveChanges();
        }
    }
}
