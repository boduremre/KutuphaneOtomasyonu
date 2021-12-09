using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KutuphaneOtomasyonu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazarlarApiController : ControllerBase
    {

        private readonly KutuphaneDbContext _context;

        public YazarlarApiController(KutuphaneDbContext context)
        {
            _context = context;
        }


        // GET: api/<YazarlarApiController>
        [HttpGet]
        public List<Yazar> Get()
        {
            var y = _context.Yazarlar.ToList();
            return y;
        }

        // GET api/<YazarlarApiController>/5
        [HttpGet("{id}")]
        public Yazar Get(int id)
        {
            var y = _context.Yazarlar.FirstOrDefault(x => x.YazarId == id);
            return y;
        }

        // POST api/<YazarlarApiController>
        [HttpPost]
        public void Post([FromBody] Yazar y)
        {
            _context.Yazarlar.Add(y);
            _context.SaveChanges();
        }

        // PUT api/<YazarlarApiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Yazar y)
        {
            var yNew = _context.Yazarlar.FirstOrDefault(x => x.YazarId == id);

            if (yNew is null)
            {
                return NotFound();
            }
            else
            {
                yNew.Ad = y.Ad;
                yNew.Soyad = y.Soyad;
                yNew.Biyografi = y.Biyografi;
                yNew.ResimUrl = y.ResimUrl;

                _context.Update(yNew);
                _context.SaveChanges();
                return Ok();
            }

        }

        // DELETE api/<YazarlarApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var y = _context.Yazarlar.FirstOrDefault(x => x.YazarId == id);
            _context.Remove(y);
            _context.SaveChanges();
        }
    }
}
