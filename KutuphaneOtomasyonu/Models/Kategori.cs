using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }

        [Required(ErrorMessage = "Kategori Adı alanı zorunludur!")]
        [Display(Name = "Kategori Adı")]
        public string KategoriAdi { get; set; }

        public List<Kitap> Kitaplar { get; set; }
    }
}
