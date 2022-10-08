using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneOtomasyonu.Models
{
    [Table("OduncKitap")]
    public class OduncKitap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Kitap")]
        public int KitapId { get; set; }
        public Kitap Kitap { get; set; }

        [Display(Name = "Üye")]
        public Guid UserId { get; set; }

        [Display(Name = "Üye")]
        public AppUser User { get; set; }

        [Required]
        [Display(Name = "Alış Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]

        public DateTime AlisTarihi { get; set; }

        [Required]
        [Display(Name = "Getireceği Tarih")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime GetirecegiTarih { get; set; }

        [Display(Name = "Getirdiği Tarih")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? GetirdigiTarih { get; set; }
    }
}
