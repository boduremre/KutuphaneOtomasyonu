using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace KutuphaneOtomasyonu.Data
{

    public class KutuphaneDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public KutuphaneDbContext(DbContextOptions<KutuphaneDbContext> options)
            : base(options)
        {
        }

        public DbSet<Yazar> Yazarlar { set; get; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yayinevi> Yayinevleri { get; set; }
        public DbSet<OduncKitap> OduncKitaplar { get; set; }
    }
}
