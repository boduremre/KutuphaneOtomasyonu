using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Models
{
    [Table("Yayinevi")]
    public class Yayinevi
    {
        [Key]
        public int YayineviId { get; set; }

        [Required(ErrorMessage = "Yayınevi Adı alanı zorunludur!")]
        [Display(Name = "Yayınevi Adı")]
        public string Adi { get; set; }

        public List<Kitap> Kitaplar { get; set; }
    }
}
