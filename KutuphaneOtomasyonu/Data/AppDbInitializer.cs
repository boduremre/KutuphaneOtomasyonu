using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<KutuphaneDbContext>();

                context.Database.EnsureCreated();

                // Kategori
                if (!context.Kategoriler.Any())
                {
                    context.Kategoriler.AddRange(new List<Kategori>()
                    {
                        new Kategori()
                        {
                            KategoriAdi = "Edebiyat"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Roman"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Çocuk"
                        },
                        new Kategori()
                        {
                           KategoriAdi = "Bilim Kurgu"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Biyografi"
                        },  new Kategori()
                        {
                            KategoriAdi = "Ekonomi"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Bilim"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Felsefe"
                        },
                        new Kategori()
                        {
                           KategoriAdi = "Müzik"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Bilgisayar"
                        },new Kategori()
                        {
                            KategoriAdi = "Akademik"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Ders Kitapları"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Mühendislik"
                        },
                        new Kategori()
                        {
                           KategoriAdi = "Matematik"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Sözlük"
                        },  new Kategori()
                        {
                            KategoriAdi = "Din"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Hukuk"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Dünya Klasikleri"
                        },
                        new Kategori()
                        {
                           KategoriAdi = "Hobi"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Eğitim"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Genel"
                        },
                        new Kategori()
                        {
                            KategoriAdi = "Diğer"
                        },
                    });

                    context.SaveChanges();
                }

                // Yazar
                if (!context.Yazarlar.Any())
                {
                    context.Yazarlar.AddRange(new List<Yazar>()
                    {
                        new Yazar()
                        {
                            Ad = "Victor",
                            Soyad = "Hugo",
                            Biyografi = "1802 yılında Besançon'da doğan büyük Fransız düşünür ve yazarı, 1885 yılında Paris'te öldü.",
                            ResimUrl = "https://img.kitapyurdu.com/v1/getImage/fn:1163262/wi:120/wh:5f404667a"
                        },
                        new Yazar()
                        {
                            Ad = "Antoine De",
                            Soyad = "Saint Exupery",
                            Biyografi = "Antoine de Saint-Exupéry (29 Haziran 1900, Lyon - 31 Temmuz 1944), Fransız pilot, yazar ve şairdir.",
                            ResimUrl = "https://img.kitapyurdu.com/v1/getImage/fn:1155825/wi:120/wh:5d3009b3f"
                        },
                        new Yazar()
                        {
                            Ad = "Franz",
                            Soyad = "Kafka",
                            Biyografi = "Modern dünya edebiyatının ikonik ve özgün yazarlarından biridir.",
                            ResimUrl = "https://img.kitapyurdu.com/v1/getImage/fn:8862719/wi:120/wh:46053a569"
                        },
                        new Yazar()
                        {
                            Ad = "Lev N.",
                            Soyad = "Tolstoy",
                            Biyografi = "Tolstoy, Shakespeare'den sonra dünya dillerine en çok tercümesi yapılan yazardır. Yirminci yüzyılın en önemli ahlakçı yazarlarındandır.",
                            ResimUrl = "https://img.kitapyurdu.com/v1/getImage/fn:1158870/wi:120/wh:3df201ef3"
                        },
                        new Yazar()
                        {
                            Ad = "Michel",
                            Soyad = "de Montaigne",
                            Biyografi = "Michel de Montaigne",
                            ResimUrl = "https://img.kitapyurdu.com/v1/getImage/fn:1164112/wi:120/wh:bc982e117"
                        }
                    });

                    context.SaveChanges();
                }

                //Yayinevleri
                if (!context.Yayinevleri.Any())
                {
                    context.Yayinevleri.AddRange(new List<Yayinevi>()
                    {
                        new Yayinevi()
                        {
                            Adi = "Can Çocuk Yayınları"

                        },
                        new Yayinevi()
                        {
                            Adi = "Türkiye İş Bankası Yayınları"
                        },
                        new Yayinevi()
                        {
                            Adi = "Can Yayınları"
                        },
                        new Yayinevi()
                        {
                            Adi = "Antik Yayınları"
                        },
                        new Yayinevi()
                        {
                            Adi = "İthaki Yayınları"
                        },new Yayinevi()
                        {
                            Adi = "Yapı Kredi Yayınları"

                        },
                        new Yayinevi()
                        {
                            Adi = "Doğan Kitap"
                        },
                        new Yayinevi()
                        {
                            Adi = "İnkılap Kitapevi"
                        },
                        new Yayinevi()
                        {
                            Adi = "Nobel Akademik Yayınevi"
                        },
                        new Yayinevi()
                        {
                            Adi = "Pegem Akademi Yayınları"
                        },
                        new Yayinevi()
                        {
                            Adi = "Yargı Yayınevi"

                        },
                        new Yayinevi()
                        {
                            Adi = "Pegasus Yayınları"
                        },
                        new Yayinevi()
                        {
                            Adi = "Milli Eğitim Bakanlığı Yayınevi"
                        },
                        new Yayinevi()
                        {
                            Adi = "Sakarya Üniversitesi Yayınları"
                        },
                        new Yayinevi()
                        {
                            Adi = "Düzce Üniversitesi Yayınları"
                        }
                    });

                    context.SaveChanges();
                }

                //Kitap
                if (!context.Kitaplar.Any())
                {
                    context.Kitaplar.AddRange(new List<Kitap>()
                    {
                        new Kitap()
                        {
                            Ad = "Sefiller",
                            OzgunAd = "Les Miserables",
                            Dil = "Türkçe",
                            Barkod = "9786054985326",
                            SayfaSayisi = 512,
                            BaskiYili = 2019,
                            Ceviren = "Pedagog Ali Çankırılı",
                            KategoriId = context.Kategoriler.Where(x=>x.KategoriAdi == "Edebiyat").Select(s => s.KategoriId).First(),
                            YazarId = context.Yazarlar.Where(x=>x.Ad == "Victor").Select(s=>s.YazarId).First(),
                            YayineviId = context.Yayinevleri.Where(x=>x.Adi == "Türkiye İş Bankası Yayınları").Select(s=>s.YayineviId).First(),
                            Adet = new Random().Next(1,10),
                            EdinmeBedeli = new Random().Next(10,50),
                            TeminBicimi = "Satın Alma",
                            DemirbasNo = "0000001",
                            ISBN = "9786054985326",
                            KapakResmi = null,
                            YerBilgisi = "B840-R5-S8"
                        }, new Kitap()
                        {
                            Ad = "Küçük Prens",
                            OzgunAd = "Küçük Prens",
                            Dil = "Türkçe",
                            Barkod = "9786054985327",
                            SayfaSayisi = 112,
                            BaskiYili = 2019,
                            Ceviren = "Tomris Uyar ve Cemal Süreya",
                            KategoriId = context.Kategoriler.Where(x=>x.KategoriAdi == "Çocuk").Select(s => s.KategoriId).First(),
                            YazarId = context.Yazarlar.Where(x=>x.Ad == "Antoine De").Select(s=>s.YazarId).First(),
                            YayineviId = context.Yayinevleri.Where(x=>x.Adi == "Can Çocuk Yayınları").Select(s=>s.YayineviId).First(),
                            Adet = new Random().Next(1,10),
                            EdinmeBedeli = new Random().Next(10,100),
                            TeminBicimi = "Satın Alma",
                            DemirbasNo = "0000002",
                            ISBN = "9786054985327",
                            KapakResmi = null,
                            YerBilgisi = "B840-R5-S9"
                        }, new Kitap()
                        {
                            Ad = "Dönüşüm",
                            OzgunAd = "Dönüşüm",
                            Dil = "Türkçe",
                            Barkod = "9786054985323",
                            SayfaSayisi = 102,
                            BaskiYili = 2019,
                            Ceviren = "",
                            KategoriId = context.Kategoriler.Where(x=>x.KategoriAdi == "Edebiyat").Select(s => s.KategoriId).First(),
                            YazarId = context.Yazarlar.Where(x=>x.Ad == "Franz").Select(s=>s.YazarId).First(),
                            YayineviId = context.Yayinevleri.Where(x=>x.Adi == "Can Yayınları").Select(s=>s.YayineviId).First(),
                            Adet = new Random().Next(1,10),
                            EdinmeBedeli = new Random().Next(10,28),
                            TeminBicimi = "Satın Alma",
                            DemirbasNo = "0000003",
                            ISBN = "9786054985323",
                            KapakResmi = null,
                            YerBilgisi = "B840-R5-S7"
                        },
                    });

                    context.SaveChanges();
                }
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(
                        new AppRole() { Name = "Admin", NormalizedName = "Admin", OlusturulmaTarihi = DateTime.Now }
                        );
                if (!await roleManager.RoleExistsAsync("Üye"))
                    await roleManager.CreateAsync(
                        new AppRole() { Name = "Üye", NormalizedName = "Üye", OlusturulmaTarihi = DateTime.Now }
                        );

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "b141210306@sakarya.edu.tr";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        Adi = "Emre",
                        Soyadi = "Bodur",
                        UserName = "b141210306@sakarya.edu.tr",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        KayitTarihi = DateTime.Now,
                        Cinsiyet = true,
                        NormalizedEmail = adminUserEmail,
                        NormalizedUserName = adminUserEmail,
                        PhoneNumber = "5547293383",
                        PhoneNumberConfirmed = true,
                        Ceza = 0,
                        TCKimlik = "24640426886"
                    };

                    await userManager.CreateAsync(newAdminUser, "123");
                    await userManager.AddToRoleAsync(newAdminUser, "Admin");
                }

                string adminUserEmail2 = "g191210300@sakarya.edu.tr";

                var adminUser2 = await userManager.FindByEmailAsync(adminUserEmail2);
                if (adminUser2 == null)
                {
                    var newAdminUser2 = new AppUser()
                    {
                        Adi = "Sadık",
                        Soyadi = "Senai",
                        UserName = "g191210300@sakarya.edu.tr",
                        Email = adminUserEmail2,
                        EmailConfirmed = true,
                        KayitTarihi = DateTime.Now,
                        Cinsiyet = true,
                        NormalizedEmail = adminUserEmail2,
                        NormalizedUserName = adminUserEmail2,
                        PhoneNumber = "5424056566",
                        PhoneNumberConfirmed = true,
                        Ceza = 0,
                        TCKimlik = "24640426882"
                    };

                    await userManager.CreateAsync(newAdminUser2, "123");
                    await userManager.AddToRoleAsync(newAdminUser2, "Admin");
                }


                string appUserEmail = "ahmettuna@emrebodur.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        Adi = "Ahmet",
                        Soyadi = "Tuna",
                        UserName = "ahmettuna@emrebodur.com",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        KayitTarihi = DateTime.Now,
                        Cinsiyet = true,
                        NormalizedEmail = adminUserEmail2,
                        NormalizedUserName = adminUserEmail2,
                        PhoneNumber = "5424056566",
                        PhoneNumberConfirmed = true,
                        Ceza = 0,
                        TCKimlik = "24640426880"
                    };

                    await userManager.CreateAsync(newAppUser, "123");
                    await userManager.AddToRoleAsync(newAppUser, "Üye");
                }
            }
        }

        public static void SeedOduncKitap(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<KutuphaneDbContext>();

                context.Database.EnsureCreated();

                // OduncKitaplar
                if (!context.OduncKitaplar.Any())
                {
                    context.OduncKitaplar.AddRange(new List<OduncKitap>()
                    {
                        new OduncKitap()
                        {
                            KitapId = 1,
                            UserId = context.Users.Where(x => x.UserName == "b141210306@sakarya.edu.tr").Select(s=>s.Id).First(),
                            AlisTarihi = DateTime.Now,
                            GetirecegiTarih = DateTime.Now.AddDays(10)
                        }, new OduncKitap()
                        {
                            KitapId = 2,
                            UserId = context.Users.Where(x => x.UserName == "ahmettuna@emrebodur.com").Select(s=>s.Id).First(),
                            AlisTarihi = DateTime.Now,
                            GetirecegiTarih = DateTime.Now.AddDays(10)
                        }
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}