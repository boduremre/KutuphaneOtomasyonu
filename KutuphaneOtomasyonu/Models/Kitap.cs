using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    [Table("Kitap")]
    public class Kitap
    {
        [Key]
        public int KitapId { get; set; }

        [Required]
        [Display(Name = "Kitap Adı")]
        public string Ad { get; set; }

        [Display(Name = "Kitap Özgün Adı")]
        public string OzgunAd { get; set; }

        [Required]
        [Display(Name = "Sayfa Sayısı")]
        public int SayfaSayisi { get; set; }

        [Required]
        [Display(Name = "Adet")]
        public int Adet { get; set; }

        [Required]
        [Display(Name = "İlk Baskı Yılı")]
        public int BaskiYili { get; set; }

        [Required]
        [Display(Name = "Dil")]
        public string Dil { get; set; } = "Türkçe";

        [Required]
        [Display(Name = "Barkod")]
        public string Barkod { get; set; }

        [Required]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Display(Name = "Çeviren")]
        public string Ceviren { get; set; }

        [Display(Name = "Temin Biçimi")]
        public string TeminBicimi { get; set; }

        [Display(Name = "Edinme Bedeli")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float? EdinmeBedeli { get; set; }

        [Required]
        [Display(Name = "Kayıt Tarihi")]
        DateTime KayitTarihi { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Yazar")]
        public int YazarId { get; set; }
        public Yazar Yazar { get; set; }

        [Required]
        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }

        [Required]
        [Display(Name = "Yayınevi")]
        public int YayineviId { get; set; }
        public Yayinevi Yayinevi { get; set; }

        [Display(Name = "Kapak Resmi (Resim URL Giriniz)")]
        public string KapakResmi { get; set; }
    }
}
