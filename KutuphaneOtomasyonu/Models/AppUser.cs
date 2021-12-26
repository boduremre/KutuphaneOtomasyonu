using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneOtomasyonu.Models
{

    public class AppUser : IdentityUser<Guid>
    {
        [Required]
        [MaxLength(15)]
        [Display(Name = "Adı")]
        public string Adi { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Soyadı")]
        public string Soyadi { get; set; }

        [Display(Name = "Cinsiyet")]
        public bool Cinsiyet { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DogumTarihi { get; set; }

        [MaxLength(11)]
        [Display(Name = "T.C.")]
        public string TCKimlik { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Kayıt Tarihi")]
        public DateTime KayitTarihi { get; set; } = DateTime.Now;

        [Display(Name = "Ceza")]
        public int Ceza { get; set; } = 0;

        public List<OduncKitap> OduncKitaplar { get; set; }
    }
}
