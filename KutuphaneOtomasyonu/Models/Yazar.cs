using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    [Table("Yazar")]
    public class Yazar
    {
        [Key]
        public int YazarId { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Yazar Ad")]
        public string Ad { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Yazar Soyad")]
        public string Soyad { get; set; }

        [Display(Name = "Biyografi")]
        [DataType(DataType.MultilineText)]
        public string Biyografi { get; set; }

        [Display(Name = "Resim")]
        public string ResimUrl { get; set; }
        public List<Kitap> Kitaplar { get; set; }
    }
}
