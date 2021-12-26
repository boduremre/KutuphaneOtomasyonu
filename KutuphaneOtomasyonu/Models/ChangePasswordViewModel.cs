using System.ComponentModel.DataAnnotations;

namespace KutuphaneOtomasyonu.Models
{
    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Mevcut Şifre")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre (Tekrar)")]
        [Required(ErrorMessage = "Zorunlu Alan")]
        [Compare("NewPassword", ErrorMessage = "Yeni Şifre ve Yeni şifre (Tekrar) eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
